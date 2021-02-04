using System;
using GameConfigs;
using GamePool;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelManagerConfig levelManagerConfig = default;
        
        private PoolManager _poolManager = default;
        private Player _player = default;
        private float _spawn = default;

        
        
        [Inject]
        public void Setup(PoolManager poolManager, Player player)
        {
            _poolManager = poolManager;
            _player = player;
        }
        
        public void Initialize()
        {
            _spawn = 0f;

            for (int i = 0; i < levelManagerConfig.MapLength; i++)
            {
                Spawn();
            }
        }


        private void Spawn()
        {
            //lately change this somehow to const mayby
            int chunkPrefabVariant = Random.Range(0,levelManagerConfig.ChunkPrefabAmount);
            //string poolTag = "Map_Tile_" + (chunkPrefabVariant + 1);
            PoolItem chunk = _poolManager.GetItemFromPool("Map_Tile_" + (chunkPrefabVariant + 1));
            chunk.transform.position = Vector3.forward*_spawn;
            _spawn += levelManagerConfig.ChunkSize;
        }

        private void Update()
        {
            if (_player.transform.position.z - levelManagerConfig.StartZone > 
                _spawn - levelManagerConfig.MapLength * levelManagerConfig.ChunkSize)
            {
                Spawn();
            }
        }
    }
}

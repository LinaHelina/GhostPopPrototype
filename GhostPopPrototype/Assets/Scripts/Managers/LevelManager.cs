using System;
using System.Collections.Generic;
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
        private List<PoolItem> _chunksList = default;
        
        
        [Inject]
        public void Setup(PoolManager poolManager, Player player)
        {
            _poolManager = poolManager;
            _player = player;
        }

        private void Start()
        {
            _chunksList = new List<PoolItem>();
        }

        public void Initialize()
        {
            _spawn = 0f;
            _chunksList.Clear();
            
            for (int i = 0; i < levelManagerConfig.MapLength; i++)
            {
                Spawn();
            }
        }


        private void Spawn()
        {
            int chunkPrefabVariant = Random.Range(0, levelManagerConfig.ChunkPrefabAmount);
            PoolItem chunk = _poolManager.GetItemFromPool("Map_Tile_" + (chunkPrefabVariant + 1));
            _chunksList.Add(chunk);
            chunk.transform.position = Vector3.forward*_spawn;
            _spawn += levelManagerConfig.ChunkSize;
        }

        private void CoinSpawner()
        {
            
        }

        private void EnemySpawn()
        {
            PoolItem enemy = _poolManager.GetItemFromPool("Enemy");
            enemy.transform.position = _chunksList[_chunksList.Count - 1].transform.position;
        }

        private void Update()
        {
            if (_player.transform.position.z - levelManagerConfig.StartZone > 
                _spawn - levelManagerConfig.MapLength * levelManagerConfig.ChunkSize)
            {
                Spawn();
                EnemySpawn();
                _chunksList[0].ReturnToPool();
                _chunksList.RemoveAt(0);
            }
        }
    }
}

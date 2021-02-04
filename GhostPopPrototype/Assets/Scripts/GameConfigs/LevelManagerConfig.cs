using UnityEngine;

namespace GameConfigs
{
    [CreateAssetMenu(menuName = "Configs/Level Config",fileName = "LevelConfig")]
    public class LevelManagerConfig : ScriptableObject
    {
        [SerializeField] private float chunkSize = default;
        [SerializeField] private int mapLength = default;
        [SerializeField] private int chunkPrefabAmount = default;
        [SerializeField] private float startZone = default;

        public float ChunkSize => chunkSize;
        public int MapLength => mapLength;
        public int ChunkPrefabAmount => chunkPrefabAmount;

        public float StartZone => startZone;
    }
}

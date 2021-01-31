using UnityEngine;

namespace GamePool
{
    [System.Serializable]
    public class PoolData
    {
        [SerializeField] private string _tag = default;
        [SerializeField] private PoolItem _poolItem = default;
        [SerializeField] private int _count = default;

        public string Tag => _tag;
        public PoolItem PoolItem => _poolItem;
        public int Count => _count;

        public PoolData(string tag,PoolItem poolItem,int count)
        {
            _tag = tag;
            _poolItem = poolItem;
            _count = count;
        }
    
    }
}
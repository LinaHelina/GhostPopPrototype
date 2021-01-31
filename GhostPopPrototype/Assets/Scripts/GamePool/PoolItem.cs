using UnityEngine;

namespace GamePool
{
    public class PoolItem : MonoBehaviour
    {
        private string _poolTag = default;
        private SimplePool<PoolItem> _pool = null;

        public string PoolTag
        {
            get => _poolTag;
            set
            {
                _poolTag = value;
                _pool = SimplePoolHelper.GetPool<PoolItem>(_poolTag);
            }
        }

        public void ReturnToPool()
        {
            _pool.Push(this);
        }
    }
}
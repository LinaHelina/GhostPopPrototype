using GameConfigs;
using GamePool;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        private PoolConfig _poolConfig = default;

        public PoolConfig PoolConfig
        {
            get => _poolConfig;
            set => _poolConfig = value;
        }

        public void InitGamePools()
        {
            for (int i = 0; i < _poolConfig.GamePoolsData.Count; i++)
            {
                SetPool(_poolConfig.GamePoolsData[i]);
            }
        }

        public SimplePool<PoolItem> GetPoolWithTag(string tag)
        {
            SimplePool<PoolItem> pool = SimplePoolHelper.GetPool<PoolItem>(tag);
            return pool;
        }

        public PoolItem GetItemFromPool(string tag)
        {
            return SimplePoolHelper.GetPool<PoolItem>(tag).Pop();
        }
    

        public void SetPool(PoolData poolData)
        {
            SimplePool<PoolItem> simplePool = SimplePoolHelper.GetPool<PoolItem>(poolData.Tag);
        
            GameObject parentObject = new GameObject("Pool_" + poolData.Tag);

            simplePool.CreateFunction = (item) =>
            {
                PoolItem temp = Instantiate(poolData.PoolItem, parentObject.transform, true);
                temp.PoolTag = poolData.Tag;
                temp.gameObject.SetActive(false);
                return temp;
            };

            simplePool.OnPush = (item) =>
            {
                item.transform.SetParent(parentObject.transform);
                item.gameObject.SetActive(false);
            };
            simplePool.OnPop = (item) => { item.gameObject.SetActive(true); };

            simplePool.Populate(poolData.Count);
        }

    }
}
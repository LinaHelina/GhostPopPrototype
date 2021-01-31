using System.Collections.Generic;
using GamePool;
using UnityEngine;

namespace GameConfigs
{
    [CreateAssetMenu(menuName = "Configs/Pool Config",fileName = "PoolConfig")]
    public class PoolConfig : ScriptableObject
    {
        [SerializeField] private List<PoolData> _gamePoolsData = default;

        public List<PoolData> GamePoolsData => _gamePoolsData;
    }
}

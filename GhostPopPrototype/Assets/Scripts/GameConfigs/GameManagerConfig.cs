using UnityEngine;

namespace GameConfigs
{
    [CreateAssetMenu(menuName = "Configs/GameManager Config",fileName = "GameManagerConfig")]
    public class GameManagerConfig : ScriptableObject
    {
        [SerializeField] private PoolConfig _poolConfig = default;
        
        public PoolConfig PoolConfig => _poolConfig;
    }
}

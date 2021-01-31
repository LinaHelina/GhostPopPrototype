using UnityEngine;

namespace GameConfigs
{
    [CreateAssetMenu(menuName = "Configs/Enemy Config",fileName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private int lifeTime = default;
        [SerializeField] private float speed = default;

        public int LifeTime => lifeTime;
        public float Speed => speed;
    }
}

using UnityEngine;

namespace GameConfigs
{
    [CreateAssetMenu(menuName = "Configs/Character Config",fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private int startCoinAmount = default;
        [SerializeField] private float speed = default;
        [SerializeField] private Vector3 startPosition = default;

        public int StartCoinAmount => startCoinAmount;
        public float Speed => speed;
        public Vector3 StartPosition => startPosition;
    }
}

using UnityEngine;

namespace GameConfigs
{
    [CreateAssetMenu(menuName = "Configs/Character Config",fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private int startCoinAmount = default;
        [SerializeField] private float speed = default;

        public int StartCoinAmount => startCoinAmount;
        public float Speed => speed;
    }
}

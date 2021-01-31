using UnityEngine;

namespace GameConfigs
{
    [CreateAssetMenu(menuName = "Configs/Bonus Config",fileName = "BonusConfig")]
    public class BonusConfig : ScriptableObject
    {
        [SerializeField] private int bonusSize = default;
        [SerializeField] private Material bonusColour = default;

        public int BonusSize => bonusSize;
        public Material BonusColour => bonusColour;
    }
}

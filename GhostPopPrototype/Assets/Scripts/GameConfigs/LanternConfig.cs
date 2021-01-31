using UnityEngine;

namespace GameConfigs
{
    [CreateAssetMenu(menuName = "Configs/Lantern Config",fileName = "LanternConfig")]
    public class LanternConfig : ScriptableObject
    {
        [SerializeField] private int startCharge = default;
        [SerializeField] private int chargeCost = default;
        [SerializeField] private int chargeIncrease = default;

        [SerializeField] private int startDamage = default;
        [SerializeField] private int damageCost = default;
        [SerializeField] private int damageIncrease = default;

        [SerializeField] private float startLength = default;
        [SerializeField] private int lengthCost = default;
        [SerializeField] private float lengthIncrease = default;


        public int StartCharge => startCharge;
        public int ChargeCost => chargeCost;
        public int ChargeIncrease => chargeIncrease;

        public int StartDamage => startDamage;
        public int DamageCost => damageCost;
        public int DamageIncrease => damageIncrease;

        public float StartLength => startLength;
        public int LengthCost => lengthCost;
        public float LengthIncrease => lengthIncrease;
        
    }
}

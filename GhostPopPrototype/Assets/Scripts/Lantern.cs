using System;
using GameConfigs;
using Lean.Touch;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour
{
    [SerializeField] private LanternConfig lanternConfig = default;
    [SerializeField] private Transform lanternTransform = default;
    [SerializeField] private Button buyBatteryButton = default;
    [SerializeField] private Button buyDamageButton = default;
    [SerializeField] private Button buyLengthButton = default;
    
    private float _charge = default;
    private sbyte _isRecharging = default;
    private int _coinsAmount = default;
    
    private float _currentBatteryCharge = default;
    private int _currentDamage = default;
    private float _currentLanternLength = default;
    
    
    public event  Action<int> OnChargeUpdate = delegate {  };
    public event Action<int> OnButtonChargeUpdate = delegate(int i) {  };
    
    private void Start()
    {
        _charge = lanternConfig.StartCharge;
        buyBatteryButton.onClick.AddListener(() => BuyImprovement("BatteryCharge"));
        buyDamageButton.onClick.AddListener(() => BuyImprovement("LanternDamage"));
        buyLengthButton.onClick.AddListener(() => BuyImprovement("LanternLength"));
        _currentBatteryCharge = lanternConfig.StartCharge;
        _currentDamage = lanternConfig.StartDamage;
        _currentLanternLength = lanternConfig.StartLength;
        _isRecharging = 0;
        _coinsAmount = 0;
        OnButtonChargeUpdate += UpdateButton;
    }

    public void Initialize()
    {
        lanternTransform.gameObject.SetActive(true);
        _charge = lanternConfig.StartCharge;
    }

    private void OnEnable()
    {
        LeanTouch.OnFingerUpdate += LanternOn;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerUpdate -= LanternOn;
    }
    
    private void LanternOn(LeanFinger finger)
    {
        if (finger.Down)
        {
            lanternTransform.gameObject.SetActive(true);

                _isRecharging = -1;
        }
        
        if (finger.Up)
        {
            lanternTransform.gameObject.SetActive(false);   
            _isRecharging = 1;
        }
 
    }

    private void Update()
    {
        _charge += _isRecharging*0.05f;
        OnChargeUpdate.Invoke((int)_charge);
       // Debug.Log(_charge);
        if (_charge > _currentBatteryCharge || _charge < 0)
            _isRecharging = 0;
    }

    private void BuyImprovement(string improvementName)
    {
        switch (improvementName)
        {
            case "BatteryCharge":
                _currentBatteryCharge += lanternConfig.ChargeIncrease;
                _coinsAmount -= lanternConfig.ChargeCost;
                OnButtonChargeUpdate.Invoke((int)_currentBatteryCharge);
                break;
            case "LanternDamage":
                _currentDamage += lanternConfig.DamageIncrease;
                _coinsAmount -= lanternConfig.DamageCost;
                break;
            case "LanternLength":
                _currentLanternLength += lanternConfig.LengthIncrease;
                _coinsAmount -= lanternConfig.LengthCost;
                break;
            
        }
    }
    
    
    private void UpdateButton(int num)
    {
        Debug.Log(num);
    }
}

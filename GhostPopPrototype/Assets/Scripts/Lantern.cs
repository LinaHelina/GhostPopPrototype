using System;
using GameConfigs;
using Lean.Touch;
using TMPro;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private LanternConfig lanternConfig = default;
    [SerializeField] private Transform lanternTransform = default;
    [SerializeField] private TextMeshPro lanternCharge = default;
    private int _charge = default;
    private sbyte _isRecharging = default;
    
    public event  Action<int> OnChargeUpdate = delegate {  };

    private void Start()
    {
        _charge = lanternConfig.StartCharge;
        _isRecharging = 0;
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
        _charge +=  _isRecharging;
        OnChargeUpdate.Invoke(_charge);
        Debug.Log(_charge);
        if (_charge > 99 || _charge < 1)
            _isRecharging = 0;
    }
}

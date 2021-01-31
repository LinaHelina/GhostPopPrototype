using GameConfigs;
using Lean.Touch;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private LanternConfig lanternConfig = default;
    [SerializeField] private Transform lanternTransform = default;
    
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
        
    }
}

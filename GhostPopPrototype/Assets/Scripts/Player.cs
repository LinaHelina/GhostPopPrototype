using System;
using GameConfigs;
using Lean.Touch;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterConfig characterConfig = default;
    [SerializeField] private Rigidbody playerRb = default;
    [SerializeField] private Button _button = default;

    private bool _isMoving = default;
    
    private void OnEnable()
    {
        LeanTouch.OnFingerUpdate += HandleFingerUpdate;

    }
    private void OnDisable()
    {
        LeanTouch.OnFingerUpdate -= HandleFingerUpdate;
    }

    public void Initialize()
    {
        transform.position = characterConfig.StartPosition;
        _isMoving = false;
    }


    public void GameConfirm(bool isStart)
    {
        if (isStart)
            _isMoving = true;
        else
            _isMoving = false;
    }
    
    private void Update()
    {
        if(_isMoving)
            playerRb.velocity = new Vector3(0, 0,  characterConfig.Speed);
    }

    private void HandleFingerUpdate(LeanFinger finger)
    {
        Vector3 rotation = Vector3.zero;
        rotation.y = -(finger.ScreenDelta.x + finger.ScreenDelta.y );
        transform.Rotate(rotation);
    }
}

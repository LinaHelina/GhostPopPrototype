using System.Collections;
using System.Collections.Generic;
using GameConfigs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterConfig characterConfig = default;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * characterConfig.Speed));
    }
}

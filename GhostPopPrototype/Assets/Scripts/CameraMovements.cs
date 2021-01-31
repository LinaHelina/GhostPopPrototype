using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] private Transform characterTarget = default;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,characterTarget.position.z-8);
    }
}

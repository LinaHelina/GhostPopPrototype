using System;
using System.Collections;
using System.Collections.Generic;
using GameConfigs;
using UnityEngine;

public abstract class Bonus : GamePool.PoolItem
{
    [SerializeField] private BonusConfig bonusConfig = default;
    
    private void OnCollisionEnter(Collision other)
    { 
        if (other.gameObject.tag.Equals("Lantern"))
        {
            ReturnToPool();    
        }
    }
}

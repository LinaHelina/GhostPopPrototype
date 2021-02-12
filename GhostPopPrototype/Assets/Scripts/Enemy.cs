using GameConfigs;
using GamePool;
using UnityEngine;
using Zenject;

public class Enemy : PoolItem
{
    [SerializeField] private EnemyConfig enemyConfig = default;

    private Player _player = default;

    [Inject]
    private void Setup(Player player)
    {
        _player = player;
    }
    
    // private void Update()
    // {
    //     float step = enemyConfig.Speed * Time.deltaTime;
    //     transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, step);
    // }
}

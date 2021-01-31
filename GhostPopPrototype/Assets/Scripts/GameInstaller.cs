using Managers;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    [SerializeField] private PoolManager _poolManager = default;
    [SerializeField] private LevelManager _levelManager = default;
    [SerializeField] private UIManager _uiManager = default;

    public override void InstallBindings()
    {
    }
}

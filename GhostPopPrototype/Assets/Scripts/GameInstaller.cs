using Managers;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    [SerializeField] private PoolManager poolManager = default;
    [SerializeField] private LevelManager levelManager = default;
    [SerializeField] private UIManager uiManager = default;
    [SerializeField] private Player player = default;

    public override void InstallBindings()
    {

        //Container.Bind<Player>().FromInstance(player).AsCached();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<UIManager>().FromInstance(uiManager).AsCached();

        Container.BindInstance(poolManager).AsSingle();
        Container.QueueForInject(poolManager);
        //Container.Bind<LevelManager>().FromInstance(levelManager).AsCached();
        //Container.BindInstance(levelManager).AsSingle();
        //Container.QueueForInject(levelManager);
        Container.Bind<LevelManager>().FromComponentInHierarchy().AsSingle();
    }
}

using GameConfigs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameManagerConfig gameManagerConfig = default;
        [SerializeField] private Button newGameButton = default;
        [SerializeField] private Button restartButton = default;
        
        private PoolManager _poolManager = default;
        private Lantern _lantern = default;
        private Player _player = default;
        private LevelManager _levelManager = default;
        private UIManager _uiManager = default;

        [Inject]
        public void Setup(PoolManager poolManager,Lantern lantern, Player player, LevelManager levelManager,UIManager uiManager)
        {
            _poolManager = poolManager;
            _lantern = lantern;
            _player = player;
            _uiManager = uiManager;
            _levelManager = levelManager;
        }

        private void Start()
        {
            newGameButton.onClick.AddListener(OnGameStartConfirmed);
            restartButton.onClick.AddListener(OnGameOverConfirmed);
            
            _poolManager.PoolConfig = gameManagerConfig.PoolConfig;
            _poolManager.InitGamePools();
            _lantern.Initialize();
            _player.Initialize();
            //_uiManager.Initialize();
            _levelManager.Initialize();
        }

        private void OnGameStartConfirmed()
        {
            _player.GameConfirm(true);  
        }

        private void OnGameOverConfirmed()
        {
            _player.GameConfirm(false); 
        }
    }
}

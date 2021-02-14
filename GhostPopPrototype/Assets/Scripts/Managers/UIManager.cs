using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPage = default;
        [SerializeField] private GameObject gameStartPage = default;
        [SerializeField] private Button newGameButton = default;
        [SerializeField] private Button restartButton = default;
        [SerializeField] private TextMeshProUGUI lanternChargeText = default;
        [SerializeField] private Button buyBatteryButton = default;
        [SerializeField] private Button buyDamageButton = default;
        [SerializeField] private Button buyLengthButton = default;
        private Lantern _lantern = default;
        
        
        public enum PageState
        {
            None,
            StartGame,
            GameOver
        }

        [Inject]
        public void Setup(Lantern lantern)
        {
            _lantern = lantern;
        }

        public void SetPageState(PageState state)
        {
            switch (state)
            {
                case PageState.None:
                    gameOverPage.SetActive(false);
                    gameStartPage.SetActive(false);
                    break;
                case PageState.StartGame:
                    gameOverPage.SetActive(false);
                    gameStartPage.SetActive(true);
                    break;
                case PageState.GameOver:
                    gameOverPage.SetActive(true);
                    gameStartPage.SetActive(false);
                    break;
            }
        }

        private void Start()
        {
            SetPageState(UIManager.PageState.StartGame);
            newGameButton.onClick.AddListener(NewGameConfirmed);
            restartButton.onClick.AddListener(RestartGameConfirmed);
            _lantern.OnChargeUpdate += UpdateCurrentCharge;
        }


        private void NewGameConfirmed()
        {
            SetPageState(PageState.None);
        }

        private void RestartGameConfirmed()
        {
            SetPageState(PageState.StartGame);
        }
        
        private void UpdateCurrentCharge(int charge)
        {
            lanternChargeText.text = "Charge: " + charge;
        }
        
    }
}

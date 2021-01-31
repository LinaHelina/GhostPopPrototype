using System;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPage = default;
        [SerializeField] private GameObject gameStartPage = default;
        [SerializeField] private Button newGameButton = default;
        [SerializeField] private Button restartButton = default;
        
        private enum PageState
        {
            None,
            StartGame,
            GameOver
        }
    
        private void SetPageState(PageState state)
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
            newGameButton.onClick.AddListener(NewGameConfirmed);
            restartButton.onClick.AddListener(RestartGameConfirmed);
        }


        private void NewGameConfirmed()
        {
            SetPageState(PageState.None);
        }

        private void RestartGameConfirmed()
        {
            SetPageState(PageState.StartGame);
        }
    }
}

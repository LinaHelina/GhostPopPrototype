using System;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public event  Action<int> OnScoreUpdate = delegate {  };
        private int _coinScore = default;

        public int CoinScore
        {
            get => _coinScore;
            set => _coinScore = value;
        }

        public void AddScore(int coinAmount)
        {
            CoinScore += coinAmount;
            OnScoreUpdate.Invoke(_coinScore);
        }
    }
}

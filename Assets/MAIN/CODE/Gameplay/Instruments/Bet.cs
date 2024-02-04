using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class Bet : MonoBehaviour
    {
        [Inject] private Bank _bank;
        [SerializeField] private TMP_Text _betNumText;

        private int _betNum;
        public Action<int> OnBetChange;
        public int BetNum => _betNum;
        private void Start()
        {
            _betNum = 10;
            _betNumText.text = _betNum.ToString();
            _bank.OnCoinsChange += CheckValidBet;
        }

        public void ChangeInvestingNum(bool isUp)
        {
            _betNum = (int)Math.Clamp(_betNum * (isUp ? 2f : 0.5f), 10, _bank.Currency);
            BetChanged();
        }
        private void CheckValidBet()
        {
            if (_bank.Currency < _betNum)
            {
                _betNum = _bank.Currency;
                BetChanged();
            }
        }

        private void BetChanged()
        {
            _betNumText.text = _betNum.ToString();
            OnBetChange?.Invoke(_betNum);
        }
    }
}
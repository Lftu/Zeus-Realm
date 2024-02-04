using System;
using UnityEngine;

namespace Game
{
    public class Bank
    {
        public int Currency { get; private set; }
        private const string Key = "Currency";
        public Action OnCoinsChange;

        public Bank()
        {
            Currency = PlayerPrefs.GetInt(Key, 0);
        }
        
        public void CurrencyChange(int coinsDelta)
        {
            Currency += coinsDelta;
            PlayerPrefs.SetInt(Key, Currency);
            OnCoinsChange?.Invoke();
        }
    }
}
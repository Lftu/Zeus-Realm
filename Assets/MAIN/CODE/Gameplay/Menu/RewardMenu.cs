using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class RewardMenu : MonoBehaviour
    {
        [Inject] private Bank _bank;
        private Button _button;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private TMP_Text _coinsText;

        private void Awake()
        {
            _button = GetComponentInChildren<Button>();
        }

        public void Open(int coins)
        {
            gameObject.Animate(true);
            _audioSource.Play();
            _coinsText.text = coins.ToString();
            _button.onClick.AddListener((() =>
            {
                Claim(coins);
            }));
        }

        private void Claim(int coins)
        {
            gameObject.Animate(false);
            gameObject.SetActive(false);
            _bank.CurrencyChange(coins);
            _button.onClick.RemoveAllListeners();
        }
    }
}
using UnityEngine;
using TMPro;
using Zenject;


namespace Game {
    public class CoinsView : MonoBehaviour
    {
        
        [Inject] private Bank _bank;
        private TMP_Text _coinsText;
        private void OnEnable()
        {
            _bank.OnCoinsChange += UpdateText;
            UpdateText();
        }

        private void OnDisable()
        {
            _bank.OnCoinsChange -= UpdateText;
        }
        private void UpdateText()
        {
            _coinsText ??= GetComponentInChildren<TMP_Text>();
            _coinsText.text = _bank.Currency.ToString();
        }
    }
}

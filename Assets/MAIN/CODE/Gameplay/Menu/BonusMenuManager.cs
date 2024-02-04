using UnityEngine;
using Zenject;

namespace Game
{
    public class BonusMenuManager : MonoBehaviour
    {
        [Inject] private Bank currency;
        
        private int moneyTogetRevard = 250;
        private bool _isRevardClaimed;
        public void Open()  
        {
            if(currency.Currency < moneyTogetRevard)
            {
                gameObject.Animate(true);
            }
        }

        public void ClaimRevard()
        {
            if (_isRevardClaimed) return;

            currency.CurrencyChange(moneyTogetRevard);
            gameObject.Animate(false);
            _isRevardClaimed = true;
        }
    }
}
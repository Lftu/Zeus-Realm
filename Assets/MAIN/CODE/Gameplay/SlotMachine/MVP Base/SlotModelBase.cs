using System.Collections.Generic;
using Zenject;

namespace Game
{
    public abstract class SlotModelBase : ModelBase<SlotViewBase>
    {
        public const int BoardSize = 5;

        [Inject] private GameSessionData _gameSessionData;
        [Inject] private GameData _gameData;
        [Inject] private PlaySymbolsSprites _playSymbolsSprites;
        [Inject] private Bank _bank;
       
        protected int[,] _slotValues = new int[BoardSize, BoardSize];
        protected int _spinsCount;
        protected bool _isSpinning;
        private int _spinsOnThisSession;
   
        public int betNum { get; protected set; }
        public bool IsAllowedSpin => !_isSpinning && _spinsCount < _spinsOnThisSession;
        public int[,] SlotValues => _slotValues;
        public int _slotsNum => _playSymbolsSprites.TotalSymbols;
        public float AddCoefficient => _gameData.BaseCoefficient;
        
        protected SlotModelBase(SlotViewBase view) : base(view)
        {
        }
       
        public override void Start()
        {
            _spinsOnThisSession = _gameData.Spins;
            _view.DisplaySpinsNum(_spinsOnThisSession - _spinsCount);
            _view.ChangeCoefficientText(_gameData.BaseCoefficient);   
        }
        
        public void SpinningStarted(int bet)
        {
            betNum = bet;
            _isSpinning = true;
            _spinsCount++;
            _view.DisplaySpinsNum(_spinsOnThisSession - _spinsCount);
            _view.ChangeCoefficientText(_gameData.BaseCoefficient);   
            _bank.CurrencyChange(-bet);
        }

        public void ComboAppeared(int comboLength)
        {
            _gameSessionData.combos++;
            switch (comboLength)
            {
                case 3:
                    _gameSessionData.combosX3++;
                    break;
                case 4:
                    _gameSessionData.combosX4++;
                    break;
                case 5:
                    _gameSessionData.combosX5++;
                    break;
            }
        }

        public void SetWinResult(int coinsWon)
        {
            _isSpinning = false;
            _bank.CurrencyChange(coinsWon);
            _view.DisplayWinCoins(coinsWon);
            if (coinsWon > 0)
            {
                _gameSessionData.winsInARow++;
            }
            else
            {
                _gameSessionData.winsInARow = 0;
                _bank.CurrencyChange((int)(betNum * _gameData.CashBack));
            }

            _gameSessionData.coinsWinTotal += coinsWon;
            
            if (_gameSessionData.coinsMaxWinAtOnce < coinsWon)
            {
                _gameSessionData.coinsMaxWinAtOnce = coinsWon;
            }
            _gameSessionData.DataChanged();
            

            if (_spinsOnThisSession - _spinsCount == 0)
            {
                _view.End();
            }
        }
        public void HighlightCombo(List<int> combo)
        {
            _view.HighlightComboSlots(combo);
        }

        public void DisplayCoefficient(float coefficient)
        {
            _view.DisplayCoefficientWithAnim(coefficient);
        }

        public void ValuesChanged(float timeOnSpin = 0)
        {
            _view.DisplaySpinResult(_slotValues, timeOnSpin);
        }
    }
}


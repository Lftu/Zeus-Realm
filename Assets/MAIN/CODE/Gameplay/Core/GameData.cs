using UnityEngine;
using Zenject;

namespace Game
{
    public class GameData
    {
        [Inject] public Bank _bank;
        private int _spins;
        private float _baseCoefficient;
        private float _cashBack;

        public int Spins => _spins;
        public float BaseCoefficient => _baseCoefficient;
        public float CashBack => _cashBack;
        
        public GameData(GameConfig gameConfig)
        {
            _spins += gameConfig._baseSpins;
            _baseCoefficient += gameConfig.BaseCoefficient;
        }

        public void AddSpin(int spinsToAdd)
        {
            _spins += spinsToAdd;
        }
        
        public void AddCoefficient(float coefficient)
        {
            _baseCoefficient += coefficient;
        }
        
        public void AddChasBack(float cashBack)
        {
            _cashBack += cashBack;
        }
    }
}
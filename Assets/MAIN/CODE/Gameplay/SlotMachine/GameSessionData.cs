using System;

namespace Game
{
    public class GameSessionData
    {
        public Action OnDataChanged;
        public int coinsWinTotal { get; set; }
        public int winsInARow { get; set; }
        public int coinsMaxWinAtOnce { get; set; }
        public int combos { get; set; }
        public int combosX3 { get; set; }
        public int combosX4 { get; set; }
        public int combosX5 { get; set; }

        public void DataChanged()
        {
            OnDataChanged?.Invoke();
        }
    }
}
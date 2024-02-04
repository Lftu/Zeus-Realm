namespace Game
{
    public class CoinsReward : RewardBase
    {
        private int _coinsReward;
        public override void GetReward(GameData gameData)
        {
            gameData._bank.CurrencyChange(_coinsReward);
        }

        public CoinsReward(int rewardNum) : base()
        {
            _coinsReward = rewardNum;
            _textLine = "+" + _coinsReward + " Coins";
        }
    }
}
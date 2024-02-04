namespace Game
{
    public class CashbackReward : RewardBase
    {
        private float _cashbackReward;
        public override void GetReward(GameData gameData)
        {
            gameData.AddChasBack(_cashbackReward);
        }

        public CashbackReward(float rewardNum) : base()
        {
            _isReclaimable = true;
            _cashbackReward = rewardNum;
            _textLine = "Returns " + (_cashbackReward).ToString("0%") + " of lost coins";
        }
    }
}
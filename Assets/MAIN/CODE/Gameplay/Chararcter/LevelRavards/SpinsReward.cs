namespace Game
{
    public class SpinsReward : RewardBase
    {
        private int _spinsReward;
        public override void GetReward(GameData gameData)
        {
            gameData.AddSpin(_spinsReward);
        }

        public SpinsReward(int rewardNum) : base()
        {
            _isReclaimable = true;
            _spinsReward = rewardNum;
            _textLine = "+" + _spinsReward + " Spins";
        }
    }
}
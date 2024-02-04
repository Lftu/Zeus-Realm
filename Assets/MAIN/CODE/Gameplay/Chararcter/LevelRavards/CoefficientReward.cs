namespace Game
{
    public class CoefficientReward : RewardBase
    {
        private float _coefficientReward;
        public override void GetReward(GameData gameData)
        {
            gameData.AddCoefficient(_coefficientReward);
        }

        public CoefficientReward(float rewardNum) : base()
        {
            _isReclaimable = true;
            _coefficientReward = rewardNum;
            _textLine = "+" + _coefficientReward.ToString("0.0") + "X to multiplier";
        }
    }
}
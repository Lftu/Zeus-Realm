namespace Game
{
    public class EmptyReward : RewardBase
    {
        public EmptyReward()
        {
            _textLine = "";
        }
        
        public override void GetReward(GameData gameData)
        {
            
        }
    }
}
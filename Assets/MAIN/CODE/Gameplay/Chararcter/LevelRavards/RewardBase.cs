namespace Game
{
    public abstract class RewardBase
    {
        protected string _textLine; 
        protected bool _isReclaimable;

        public string Text => _textLine;
        public bool IsReclaimable => _isReclaimable;
        
        protected RewardBase()
        {
        }
        public abstract void GetReward(GameData gameData);
    }
}
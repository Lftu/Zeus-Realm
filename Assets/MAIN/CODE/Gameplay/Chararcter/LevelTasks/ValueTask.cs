namespace Game
{
    public abstract class ValueTask : TaskBase
    {
        protected int _sessionValue;
        protected int _neededValue;

        protected ValueTask(GameSessionData gameSessionData, int neededValue) : base(gameSessionData)
        {
            _neededValue = neededValue;
        }
        
        protected override void CheckOnCompletion()
        {
            int gameValue = ValueToCompare();
            if (_sessionValue != gameValue)
            {
                _sessionValue = gameValue;
                OnTaskProgressChanged?.Invoke();
            }
            if (gameValue >= _neededValue)
            {
                TaskCompleted();
            }
        }

        protected abstract int ValueToCompare();
        
       
    }
}
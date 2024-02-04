namespace Game
{
    class WinInARowTask : ValueTask
    {
        public WinInARowTask(GameSessionData gameSessionData, int neededValue) : base(gameSessionData, neededValue)
        {
        }

        public override string GetTaskInfo()
        {
            return $"Win {_neededValue} times in a row";
        }

        public override string GetGameTaskProgress()
        {
            return $"Your win streak is {_sessionValue}/{_neededValue}";
        }
        protected override int ValueToCompare()
        {
            return _gameSessionData.winsInARow;
        }
    }
}
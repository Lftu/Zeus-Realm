namespace Game
{
    class CoinsMaxWinTask : ValueTask
    {
        public CoinsMaxWinTask(GameSessionData gameSessionData, int neededValue) : base(gameSessionData, neededValue)
        {
        }

        public override string GetTaskInfo()
        {
            return $"Win {_neededValue} coins in one spin";
        }

        public override string GetGameTaskProgress()
        {
            return $"Max coins won {_sessionValue}/{_neededValue}";
        }
        protected override int ValueToCompare()
        {
            return _gameSessionData.coinsMaxWinAtOnce;
        }
    }
}
namespace Game
{
    class CoinsWinTask : ValueTask
    {
        public CoinsWinTask(GameSessionData gameSessionData, int neededValue) : base(gameSessionData, neededValue)
        {
        }

        public override string GetTaskInfo()
        {
            return $"Win {_neededValue} coins in one session";
        }

        public override string GetGameTaskProgress()
        {
            return $"Coins won {_sessionValue}/{_neededValue}";
        }
        protected override int ValueToCompare()
        {
            return _gameSessionData.coinsWinTotal;
        }
    }
}
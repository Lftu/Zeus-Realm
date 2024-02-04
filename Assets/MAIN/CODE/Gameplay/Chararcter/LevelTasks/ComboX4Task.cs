namespace Game
{
    class ComboX4Task : ValueTask
    {
        public ComboX4Task(GameSessionData gameSessionData, int neededValue) : base(gameSessionData, neededValue)
        {
        }

        public override string GetTaskInfo()
        {
            return $"Get {_neededValue} X4 combos in one session";
        }

        public override string GetGameTaskProgress()
        {
            return $"X4 combos: {_sessionValue}/{_neededValue}";
        }
        protected override int ValueToCompare()
        {
            return _gameSessionData.combosX4;
        }
    }
}
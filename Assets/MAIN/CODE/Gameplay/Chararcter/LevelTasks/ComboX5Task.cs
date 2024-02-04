namespace Game
{
    class ComboX5Task : ValueTask
    {
        public ComboX5Task(GameSessionData gameSessionData, int neededValue) : base(gameSessionData, neededValue)
        {
        }

        public override string GetTaskInfo()
        {
            return $"Get {_neededValue} X5 combos in one session";
        }

        public override string GetGameTaskProgress()
        {
            return $"X5 combos: {_sessionValue}/{_neededValue}";
        }
        protected override int ValueToCompare()
        {
            return _gameSessionData.combosX5;
        }
    }
}
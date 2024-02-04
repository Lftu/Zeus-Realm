namespace Game
{
    class ComboX3Task : ValueTask
    {
        public ComboX3Task(GameSessionData gameSessionData, int neededValue) : base(gameSessionData, neededValue)
        {
        }

        public override string GetTaskInfo()
        {
            return $"Get {_neededValue} X3 combos in one session";
        }

        public override string GetGameTaskProgress()
        {
            return $"X3 combos: {_sessionValue}/{_neededValue}";
        }
        protected override int ValueToCompare()
        {
            return _gameSessionData.combosX3;
        }
    }
}
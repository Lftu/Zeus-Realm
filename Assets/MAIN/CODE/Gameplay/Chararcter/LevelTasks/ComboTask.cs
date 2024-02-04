namespace Game
{
    class ComboTask : ValueTask
    {
        public ComboTask(GameSessionData gameSessionData, int neededValue) : base(gameSessionData, neededValue)
        {
        }

        public override string GetTaskInfo()
        {
            return $"Get {_neededValue} combos in one session";
        }

        public override string GetGameTaskProgress()
        {
            return $"Combos: {_sessionValue}/{_neededValue}";
        }
        protected override int ValueToCompare()
        {
            return _gameSessionData.combos;
        }
    }
}
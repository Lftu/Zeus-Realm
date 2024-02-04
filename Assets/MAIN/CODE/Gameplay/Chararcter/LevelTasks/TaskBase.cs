using System;

namespace Game
{
    public abstract class TaskBase
    {
        public Action OnTaskProgressChanged;
        private bool _isCompleted;
        protected GameSessionData _gameSessionData;
        public bool IsCompleted => _isCompleted;

        protected TaskBase(GameSessionData gameSessionData)
        {
            _gameSessionData = gameSessionData;
        }
        public void EnableTask()
        {
            _gameSessionData.OnDataChanged += CheckOnCompletion;
        }
        protected abstract void CheckOnCompletion();
        protected void TaskCompleted()
        {
            _gameSessionData.OnDataChanged -= CheckOnCompletion;
            _isCompleted = true;
        }
        public abstract string GetTaskInfo();
        public abstract string GetGameTaskProgress();
    }
}
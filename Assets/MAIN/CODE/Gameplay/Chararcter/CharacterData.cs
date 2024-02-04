using UnityEngine;
using Zenject;

namespace Game
{
    public class CharacterData
    {
        public readonly string TaskComplitedText = "All tasks completed! I appreciate your work.";
        private string Key => "CharacterKey" + _characterConfig.Name;
        private int _friendLevel;
        private readonly CharacterConfig _characterConfig;
        private RewardBase[] _levelRewards;
        private TaskBase[] _taskBases;
        private GameData _gameData;
        public CharacterConfig CharacterConfig => _characterConfig;
        public TaskBase CurrentTask => _friendLevel < 7 ? _taskBases[_friendLevel] : null;
        public RewardBase[] LevelRewards => _levelRewards;
        public int FriendLevel => _friendLevel;

        public CharacterData(CharacterConfig characterConfig, RewardBase[] levelRewards, TaskBase[] tasks)
        {
            _taskBases = tasks;
            _levelRewards = levelRewards;
            _characterConfig = characterConfig;
            _friendLevel = PlayerPrefs.GetInt(Key, 0);
        }
        
        [Inject]
        private void Construct(GameData gameData, GameSessionData gameSessionData)
        {
            _gameData = gameData;
            for (int i = 0; i < _friendLevel; i++)
            {
                if (_levelRewards[i] != null && _levelRewards[i].IsReclaimable)
                {
                    _levelRewards[i].GetReward(_gameData);
                }
            }
        }

        public void LevelIncreased()
        {
            _levelRewards[_friendLevel].GetReward(_gameData);
            _friendLevel++;
            PlayerPrefs.SetInt(Key, _friendLevel);
        }

        public void EnableTask()
        {
            if (_friendLevel < 7)
            {
                _taskBases[_friendLevel].EnableTask();
            }
           
        }
    }
}
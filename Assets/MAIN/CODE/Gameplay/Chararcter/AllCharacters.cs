using System.Collections.Generic;
using Zenject;

namespace Game
{
    public class AllCharacters
    {
        private int _charactersInitialized;
        [Inject] private GameSessionData _gameSessionData;
        private readonly List<CharacterData> _characterData = new ();
        private readonly List<CharacterConfig> _characterConfigs;

        public List<CharacterData> CharacterData => _characterData;

        public AllCharacters(List<CharacterConfig> characterConfigs)
        {
            _characterConfigs = characterConfigs;
        }
        
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            foreach (var characterConfig in _characterConfigs)
            {
                CharacterData characterData = new CharacterData(characterConfig, GetPackOfRewards(), GetPackOfTasks());
                _characterData.Add(characterData);
                diContainer.Inject(characterData);
                _charactersInitialized++;
            }
        }
        
        private RewardBase[] GetPackOfRewards()
        {
            RewardBase[] rewardBases = new RewardBase[7];
            switch (_charactersInitialized)
            {
                case 0:
                    rewardBases[0] = new EmptyReward();
                    rewardBases[1] = new CoinsReward(500);
                    rewardBases[2] = new EmptyReward();
                    rewardBases[3] = new SpinsReward(1);
                    rewardBases[4] = new CoinsReward(1000);
                    rewardBases[5] = new EmptyReward();
                    rewardBases[6] = new CoinsReward(2000);
                    break;
                case 1:
                    rewardBases[0] = new EmptyReward();
                    rewardBases[1] = new SpinsReward(1);
                    rewardBases[2] = new EmptyReward();
                    rewardBases[3] = new CoinsReward(500);
                    rewardBases[4] = new SpinsReward(1);
                    rewardBases[5] = new EmptyReward();
                    rewardBases[6] = new SpinsReward(2);
                    break;
                case 2:
                    rewardBases[0] = new EmptyReward();
                    rewardBases[1] = new CoefficientReward(0.1f);
                    rewardBases[2] = new EmptyReward();
                    rewardBases[3] = new CashbackReward(0.1f);
                    rewardBases[4] = new CoefficientReward(0.1f);
                    rewardBases[5] = new EmptyReward();
                    rewardBases[6] = new CoefficientReward(0.2f);
                    break;
                case 3:
                    rewardBases[0] = new EmptyReward();
                    rewardBases[1] = new CashbackReward(0.1f);
                    rewardBases[2] = new EmptyReward();
                    rewardBases[3] = new CoefficientReward(0.1f);
                    rewardBases[4] = new CashbackReward(0.1f);
                    rewardBases[5] = new EmptyReward();
                    rewardBases[6] = new CashbackReward(0.2f);
                    break;
            }
            return rewardBases;
        }

        private TaskBase[] GetPackOfTasks()
        {
            TaskBase[] tasks = new TaskBase[7];
            switch (_charactersInitialized)
            {
                case 0:
                    tasks[0] = new ComboTask(_gameSessionData,3);
                    tasks[1] = new CoinsWinTask(_gameSessionData,1000);
                    tasks[2] = new ComboX3Task(_gameSessionData,4);
                    tasks[3] = new ComboX4Task(_gameSessionData,2);
                    tasks[4] = new CoinsMaxWinTask(_gameSessionData,800);
                    tasks[5] = new WinInARowTask(_gameSessionData,5);
                    tasks[6] = new ComboX5Task(_gameSessionData,2);
                    break;
                case 1:
              
                    tasks[0] = new CoinsMaxWinTask(_gameSessionData,200);
                    tasks[1] = new CoinsWinTask(_gameSessionData,1000);
                    tasks[2] = new ComboX4Task(_gameSessionData,1);
                    tasks[3] = new WinInARowTask(_gameSessionData,3);
                    tasks[4] = new ComboX3Task(_gameSessionData,4);
                    tasks[5] = new ComboX5Task(_gameSessionData,2);
                    tasks[6] = new ComboTask(_gameSessionData,7);
                    break;
                case 2:
                    tasks[0] = new ComboX4Task(_gameSessionData,1);
                    tasks[1] = new ComboX5Task(_gameSessionData,1);
                    tasks[2] = new ComboX3Task(_gameSessionData,3);
                    tasks[3] = new ComboTask(_gameSessionData,5);
                    tasks[4] = new CoinsMaxWinTask(_gameSessionData,1000);
                    tasks[5] = new WinInARowTask(_gameSessionData,5);
                    tasks[6] = new CoinsWinTask(_gameSessionData,4000);
                    break;
                case 3:
                    tasks[0] = new ComboX5Task(_gameSessionData,1);
                    tasks[1] = new WinInARowTask(_gameSessionData,2);
                    tasks[2] = new CoinsMaxWinTask(_gameSessionData,500);
                    tasks[3] = new ComboX4Task(_gameSessionData,2);
                    tasks[4] = new ComboX3Task(_gameSessionData,4);
                    tasks[5] = new CoinsWinTask(_gameSessionData,1000);
                    tasks[6] = new ComboTask(_gameSessionData,3);
                    break;
            }
            return tasks;
        }
    }
}
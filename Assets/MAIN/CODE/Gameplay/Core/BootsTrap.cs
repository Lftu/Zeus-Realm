using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class BootsTrap : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private List<Sprite> _slotSprites;
        [SerializeField] private List<CharacterConfig> _characterConfigs;

        public override void InstallBindings()
        {
            GameData gameData = new GameData(_gameConfig);
            AllCharacters allCharacters = new AllCharacters(_characterConfigs);
            PlaySymbolsSprites playSymbolsSprites = new PlaySymbolsSprites(_slotSprites);
            Bank bank = new Bank();
            
            Container.Bind<GameData>().FromInstance(gameData).AsSingle();
            Container.Bind<PlaySymbolsSprites>().FromInstance(playSymbolsSprites).AsSingle();
            Container.Bind<AllCharacters>().FromInstance(allCharacters).AsSingle();
            Container.Bind<Bank>().FromInstance(bank).AsSingle();
            
            Container.Inject(gameData);
            Container.Inject(allCharacters);
        }
    }
}
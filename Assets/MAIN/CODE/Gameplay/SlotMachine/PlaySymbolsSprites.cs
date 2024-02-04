using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlaySymbolsSprites
    {
        public int TotalSymbols => Sprites.Count;
        public List<Sprite> Sprites { get; private set; }

        public PlaySymbolsSprites(List<Sprite> sprites)
        {
            Sprites = sprites;
        }
    }
}
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Character")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _sprite;
        public string Name => _name;
        public Sprite Sprite => _sprite;
    }
}
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int _spinsBase = 5;
        [SerializeField] private float _baseCoefficient;
        
        public int _baseSpins => _spinsBase;
        public float BaseCoefficient => _baseCoefficient;
    }
}
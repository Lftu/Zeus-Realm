using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Raw : MonoBehaviour
    {
        [SerializeField] private List<Slot> _slots;
        public List<Slot> Slots => _slots;
    }
}
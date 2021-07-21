using UnityEngine;

namespace Level.Collectables
{
    /// <summary>
    ///This class stores and manages the collectible.
    /// </summary>
    public class CollectableManager : MonoBehaviour, ICollectable
    {
        private int _storedCollectables; // Collectables stored Bpy the player.

        public void AddCollectable()
        {
            _storedCollectables += 1;
        }
        public int GetStoredCollectablesValue() // Return total of collectables piked up.
        {
            return _storedCollectables;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///This class stores and manages the collectible.
/// </summary>
public class CollectableManager : MonoBehaviour, ICollectable
{
    private int _StoredCollectables; // Collectables stored Bpy the player.

    public void AddColectable()
    {
        _StoredCollectables += 1;
    }
    public int GetStoredCollectablesValue() // Return total of collectables piked up.
    {
        return _StoredCollectables;
    }
}

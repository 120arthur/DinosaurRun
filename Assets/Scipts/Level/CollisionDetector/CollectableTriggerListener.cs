using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableTriggerListener : AbstractDetectTrigger
{
    /// <summary>
    ///This function is called  when the player pick up a collectable.
    /// </summary>
    /// <param name="collisionObject"></param>
    protected override void Execute(GameObject collisionObject)
    {
        GameManager.gameManagerInstance.CollectableManager.AddColectable();

        UiGame.uiInstance.UpdateCollectables();
        gameObject.SetActive(false);
    }
}

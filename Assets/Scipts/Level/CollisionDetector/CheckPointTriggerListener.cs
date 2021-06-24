using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPointTriggerListener : AbstractDetectTrigger
{
    /// <summary>
    ///When called This function updates LastCheckPoint.
    /// </summary>
    /// <param name="collisionObject"></param>
    protected override void Execute(UnityEngine.GameObject collisionObject)
    {
        GameManager.gameManagerInstance.CheckPointManager.SetNewCheckPoint(gameObject.transform);
    }
}

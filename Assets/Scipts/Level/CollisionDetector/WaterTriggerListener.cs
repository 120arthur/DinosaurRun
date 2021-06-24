using UnityEngine;
using UnityEngine.Analytics;
public class WaterTriggerListener : AbstractDetectTrigger
{
    /// <summary>
    ///When called This function ends the game.
    /// </summary>
    /// <param name="collisionObject"></param>
    protected override void Execute(UnityEngine.GameObject collisionObject)
    {
        Timer.timeInstnce.PauseTime();
        UiGame.uiInstance.LoseIn();

        PlayerMovment playerMovment = collisionObject.GetComponent<PlayerMovment>();
        playerMovment.AnimationParameter.SetAnimationParameterBool("IsDead", true);

        AnalyticsManager.analyticsManagerInstance.AnalyticsEvent("PlayerDeathLocation", collisionObject.gameObject.transform.position);

    }
}

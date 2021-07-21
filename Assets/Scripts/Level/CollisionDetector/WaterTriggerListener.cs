using Analytics;
using Level.TimeScore;
using Player.Movement;

namespace Level.CollisionDetector
{
    public class WaterTriggerListener : AbstractDetectTrigger
    {
        /// <summary>
        ///When called This function ends the game.
        /// </summary>
        /// <param name="collisionObject"></param>
        protected override void Execute(UnityEngine.GameObject collisionObject)
        {
            Timer.timeInstance.PauseTime();
            UiGame.uiInstance.LoseIn();

            var playerMovement = collisionObject.GetComponent<PlayerMovement>();
            playerMovement.AnimationParameter.SetAnimationParameterBool("IsDead", true);

            AnalyticsManager.analyticsManagerInstance.AnalyticsEvent("PlayerDeathLocation", collisionObject.gameObject.transform.position);

        }
    }
}

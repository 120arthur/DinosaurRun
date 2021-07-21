using Analytics;
using Level.TimeScore;

namespace Level.CollisionDetector
{
    public class WinTriggerListener : AbstractDetectTrigger
    {
        /// <summary>
        ///when this function is called the player wins the game.
        /// </summary>
        /// <param name="collisionObject"></param>
        protected override void Execute(UnityEngine.GameObject collisionObject)
        {
            UiGame.uiInstance.WinIn();
            Timer.timeInstance.PauseTime();

            AnalyticsManager.analyticsManagerInstance.AnalyticsEvent("PlayerWon");
        }

    }
}

namespace Level.CollisionDetector
{
    public class CheckPointTriggerListener : AbstractDetectTrigger
    {
        /// <summary>
        ///When called This function updates LastCheckPoint.
        /// </summary>
        /// <param name="collisionObject"></param>
        protected override void Execute(UnityEngine.GameObject collisionObject)
        {
            GameManager.gameManagerInstance.checkPointManager.SetNewCheckPoint(gameObject.transform);
        }
    }
}

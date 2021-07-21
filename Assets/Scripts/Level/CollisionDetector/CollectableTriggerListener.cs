using UnityEngine;

namespace Level.CollisionDetector
{
    public class CollectableTriggerListener : AbstractDetectTrigger
    {
        /// <summary>
        ///This function is called  when the player pick up a collectable.
        /// </summary>
        /// <param name="collisionObject"></param>
        protected override void Execute(GameObject collisionObject)
        {
            GameManager.gameManagerInstance.collectableManager.AddCollectable();

            UiGame.uiInstance.UpdateCollectables();
            gameObject.SetActive(false);
        }
    }
}

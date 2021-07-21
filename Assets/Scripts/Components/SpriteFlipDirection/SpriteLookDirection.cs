using UnityEngine;


namespace Components.SpriteFlipDirection
{
    public class SpriteLookDirection : MonoBehaviour, ISpriteLookDirection
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        
        // Check direction;
        public void CheckDirection(float direction)
        {
            if (direction > 0.01)
            {
                FlipImage(false);
            }
            else if (direction < -0.01)
            {
                FlipImage(true);
            }
        }
        private void FlipImage(bool canFlip)
        {
            spriteRenderer.flipX = canFlip;
        }
    }
}

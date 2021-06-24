using UnityEngine;

/// <summary>
//this clas verify and flips the image in a specific direction.
/// </summary>
public class SpriteLookDirection : MonoBehaviour, ISpriteLookDirection
{
    [SerializeField]
    private SpriteRenderer _SpriteRenderer;

   
    
    // Check direction;
    public void CheckLoockDirection(float Direction)
    {
        if (Direction > 0.01)
        {
            FlipImage(false);
        }
        else if (Direction < -0.01)
        {
            FlipImage(true);
        }
    }
    private void FlipImage(bool canFlip)
    {
        _SpriteRenderer.flipX = canFlip;
    }
}

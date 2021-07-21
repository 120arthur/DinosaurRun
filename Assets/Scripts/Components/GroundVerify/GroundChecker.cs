using UnityEngine;

namespace Components.GroundVerify
{
    /// <summary>
    /// Check if the object is on the ground and do something;
    /// </summary>
    public class GroundChecker : MonoBehaviour, IGroundChecker
    {
        [SerializeField]
        private Transform groundChecker;

        [Header("Pass the floor layer")]
        [SerializeField]
        private string whatIsGround;

        //Check if the object is on the floor.
        public bool Verify()
        {
            return Physics2D.Linecast(transform.position, groundChecker.position, 1 <<  LayerMask.NameToLayer(whatIsGround));
        }

    }
}

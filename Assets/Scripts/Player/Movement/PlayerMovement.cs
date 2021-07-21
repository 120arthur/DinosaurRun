using Components.AnimationParameter;
using Components.GroundVerify;
using Components.SpriteFlipDirection;
using UnityEngine;

namespace Player.Movement
{
    /// <summary>
    /// this class controls all player movements.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [Range(0.0f, 500.0f)]
        [SerializeField]
        private float speedMovement;

        [Range(0.0f, 50.0f)]
        [SerializeField]
        private float jumpForce;

        [Range(0.0f, 10.0f)]
        [SerializeField]
        private int fallMultiplier;

        [SerializeField]
        private Rigidbody2D rb;

        [SerializeField]
        private Joystick joystick;

        private IGroundChecker _groundChecker;
        private ISpriteLookDirection _spriteLookDirection;


        private void Start()
        {
            _groundChecker = GetComponent<IGroundChecker>();
            _spriteLookDirection = GetComponent<ISpriteLookDirection>();
            AnimationParameter = GetComponent<IAnimationParameter>();
        }

        private void FixedUpdate()
        {
            MoveHorizontal();

            AnimationParameter.SetAnimationParameterFloat("VelocityY", Mathf.Abs(rb.velocity.y));

            AnimationParameter.SetAnimationParameterFloat("Speed", Mathf.Abs(joystick.Horizontal));

            // If player is falling 
            if (rb.velocity.y < 0 && _groundChecker.Verify() == false)
            {
                FallSpeedIntensifier();
                AnimationParameter.SetAnimationParameterBool("IsFall", true);
            }
            //If player is in the grownd
            else if (rb.velocity.y < 0.4 && _groundChecker.Verify())
            {
                AnimationParameter.SetAnimationParameterBool("IsJumping", false);
                AnimationParameter.SetAnimationParameterBool("IsFall", false);
            }
        }
        private void MoveHorizontal()
        {
            if (joystick.Horizontal != 0)
            {
                // When the player uses the Joystick, this funcion will flip the player to the direction of joystick.
                _spriteLookDirection.CheckDirection(joystick.Horizontal);

                rb.velocity = (new Vector2(speedMovement * Time.fixedDeltaTime * joystick.Horizontal, rb.velocity.y));
            }
            //when the player stops moving, this condition prevents the player from moving in vector X.
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

        }
        public void Jump()
        {
            if (!_groundChecker.Verify()) return;
            rb.velocity = Vector2.up * jumpForce;
            AnimationParameter.SetAnimationParameterBool("IsJumping", true);
        }
        //This class changes the player's falling speed.
        private void FallSpeedIntensifier()
        {
            rb.velocity += Vector2.up * (Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        }

        public IAnimationParameter AnimationParameter { get; private set; }
    }
}

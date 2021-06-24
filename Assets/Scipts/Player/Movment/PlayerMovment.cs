using UnityEngine;

/// <summary>
/// this class controls all player movements.
/// </summary>
public class PlayerMovment : MonoBehaviour
{
    [Range(0.0f, 500.0f)]
    [SerializeField]
    private float _SpeedMovment;

    [Range(0.0f, 50.0f)]
    [SerializeField]
    private float _JumpForce;

    [Range(0.0f, 10.0f)]
    [SerializeField]
    private int _FallMultiplier;

    [SerializeField]
    private Rigidbody2D _Rb;

    [SerializeField]
    private Joystick _Joystick;

    private IGrowndChecker _GrowndChecker;
    private ISpriteLookDirection _SpriteLookDirection;
    [HideInInspector]
    private IAnimationParameter animationParameter;


    private void Start()
    {
        _GrowndChecker = GetComponent<IGrowndChecker>();
        _SpriteLookDirection = GetComponent<ISpriteLookDirection>();
        animationParameter = GetComponent<IAnimationParameter>();
    }

    private void FixedUpdate()
    {
        MoveHorizontal();

        animationParameter.SetAnimationParameterFloat("VelocityY", Mathf.Abs(_Rb.velocity.y));

        animationParameter.SetAnimationParameterFloat("Speed", Mathf.Abs(_Joystick.Horizontal));

        // If player is falling 
        if (_Rb.velocity.y < 0 && _GrowndChecker.Verify() == false)
        {
            FallSpeedIntensifier();
            animationParameter.SetAnimationParameterBool("IsFall", true);
        }
        //If player is in the grownd
        else if (_Rb.velocity.y < 0.4 && _GrowndChecker.Verify() == true)
        {
            animationParameter.SetAnimationParameterBool("IsJumping", false);
            animationParameter.SetAnimationParameterBool("IsFall", false);
        }
    }
    private void MoveHorizontal()
    {
        if (_Joystick.Horizontal != 0)
        {
            // When the player uses the Joystick, this funcion will flip the player to the direction of joystick.
            _SpriteLookDirection.CheckLoockDirection(_Joystick.Horizontal);

            _Rb.velocity = (new Vector2(_SpeedMovment * Time.fixedDeltaTime * _Joystick.Horizontal, _Rb.velocity.y));
        }
        //when the player stops moving, this condition prevents the player from moving in vector X.
        else
        {
            _Rb.velocity = new Vector2(0, _Rb.velocity.y);
        }

    }
    public void Jump()
    {
        if (_GrowndChecker.Verify())
        {
            _Rb.velocity = Vector2.up * _JumpForce;
            animationParameter.SetAnimationParameterBool("IsJumping", true);
        }
    }
    //This class changes the player's falling speed.
    private void FallSpeedIntensifier()
    {
        _Rb.velocity += Vector2.up * Physics.gravity.y * (_FallMultiplier - 1) * Time.deltaTime;
    }

    public IAnimationParameter AnimationParameter { get => animationParameter; private set => animationParameter = value; }
}

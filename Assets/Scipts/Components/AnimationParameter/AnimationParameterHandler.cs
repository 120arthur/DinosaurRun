using UnityEngine;

/// <summary>
/// this class is in charge of controlling animation parameters.
/// </summary>
public class AnimationParameterHandler : MonoBehaviour , IAnimationParameter
{
    [Tooltip("assign the component animator.")]
    [SerializeField]
    private Animator _Animator;
    public Animator Animator { get => Animator; set => Animator = value; }

    public void SetAnimationParameterBool(string ParameterName, bool ParameterCheck)
    {
        _Animator.SetBool(ParameterName, ParameterCheck);
    }
    public void SetAnimationParameterFloat(string ParameterName, float ParameterValue)
    {
        _Animator.SetFloat(ParameterName, ParameterValue);
    }

}

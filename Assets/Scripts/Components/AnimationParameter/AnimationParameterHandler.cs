using UnityEngine;

namespace Components.AnimationParameter
{
    /// <summary>
    /// this class is in charge of controlling animation parameters.
    /// </summary>
    public class AnimationParameterHandler : MonoBehaviour , IAnimationParameter
    {
        [Tooltip("assign the component animator.")]
        [SerializeField] private Animator animator;
        public Animator Animator { get => Animator; set => Animator = value; }

        public void SetAnimationParameterBool(string parameterName, bool parameterCheck)
        {
            animator.SetBool(parameterName, parameterCheck);
        }
        public void SetAnimationParameterFloat(string parameterName, float parameterValue)
        {
            animator.SetFloat(parameterName, parameterValue);
        }

    }
}

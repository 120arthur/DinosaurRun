using UnityEngine;

namespace Components.AnimationParameter
{
    public interface IAnimationParameter
    {
        Animator Animator { get; set; }

        void SetAnimationParameterBool(string parameterName, bool parameterCheck);
        void SetAnimationParameterFloat(string parameterName, float parameterValue);
    }
}
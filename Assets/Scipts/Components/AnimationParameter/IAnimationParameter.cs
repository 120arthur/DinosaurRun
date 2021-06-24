using UnityEngine;

public interface IAnimationParameter
{
    Animator Animator { get; set; }

    void SetAnimationParameterBool(string ParameterName, bool ParameterCheck);
    void SetAnimationParameterFloat(string ParameterName, float ParameterValue);
}
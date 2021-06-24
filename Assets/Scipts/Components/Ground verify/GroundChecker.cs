using UnityEngine;
/// <summary>
/// Check if the object is on the ground and do something;
/// </summary>
public class GroundChecker : MonoBehaviour, IGrowndChecker
{
    [SerializeField]
    private Transform _GroundoChecker;

    [Header("Pass the floor layer")]
    [SerializeField]
    private string _WhatIsGround;

    //Check if the object is on the floor.
    public bool Verify()
    {
        return Physics2D.Linecast(transform.position, _GroundoChecker.position, 1 <<  LayerMask.NameToLayer(_WhatIsGround));
    }

}

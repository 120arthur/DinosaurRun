using UnityEngine;
/// <summary>
/// Responsible for storing the last checkpoint and sending objects to the last checkpoint.
/// </summary>
public class CheckPointManager : MonoBehaviour, ICheckPointManager
{
    private Vector2 _LastCheckPoint; // Stores the last checkpoint the player passed.
    public void SetNewCheckPoint(Transform newCheckPoint)
    {
        _LastCheckPoint = newCheckPoint.position;
    }
    public Vector2 GetLastCheckPoint()
    {
        return _LastCheckPoint;
    }
    public void SendObjectToLastCheckPoint(Transform objt)
    {
        objt.position = new Vector3(_LastCheckPoint.x, _LastCheckPoint.y);
    }
}

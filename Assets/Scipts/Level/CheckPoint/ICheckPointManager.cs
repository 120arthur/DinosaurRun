using UnityEngine;

public interface ICheckPointManager
{
    Vector2 GetLastCheckPoint();
    void SetNewCheckPoint(Transform newCheckPoint);
    void SendObjectToLastCheckPoint(Transform objt);
}
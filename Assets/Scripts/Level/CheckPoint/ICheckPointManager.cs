using UnityEngine;

namespace Level.CheckPoint
{
    public interface ICheckPointManager
    {
        Vector2 GetLastCheckPoint();
        void SetNewCheckPoint(Transform newCheckPoint);
        void SendObjectToLastCheckPoint(Transform objet);
    }
}
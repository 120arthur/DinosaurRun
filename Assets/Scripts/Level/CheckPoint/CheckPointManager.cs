using UnityEngine;

namespace Level.CheckPoint
{
    /// <summary>
    /// Responsible for storing the last checkpoint and sending objects to the last checkpoint.
    /// </summary>
    public class CheckPointManager : MonoBehaviour, ICheckPointManager
    {
        private Vector2 _lastCheckPoint; // Stores the last checkpoint the player passed.
        public void SetNewCheckPoint(Transform newCheckPoint)
        {
            _lastCheckPoint = newCheckPoint.position;
        }
        public Vector2 GetLastCheckPoint()
        {
            return _lastCheckPoint;
        }
        public void SendObjectToLastCheckPoint(Transform objet)
        {
            objet.position = new Vector3(_lastCheckPoint.x, _lastCheckPoint.y);
        }
    }
}

using System.Collections;
using UnityEngine;

namespace Level.TimeScore
{
    /// <summary>
    /// This class mananges the Timer In Game.
    /// </summary>
    public class Timer : MonoBehaviour, ITimer
    {
        public static Timer timeInstance;

        private float _currentTime = 0;
        private bool _finish = false;
        private string _minutes;
        private string _seconds;

        private void Awake()
        {
            timeInstance = this;
        }
        void Start()
        {
            StartCoroutine(UpdateTime());
        }

        // Retun the Current time as a string.
        public string CurrentTimeText()
        {
            if (_finish == true)
                return _minutes + ":" + _seconds;

            UpdateTime();
            ConvertTimeToString();

            return _minutes + ":" + _seconds;
        }

        //Update the current time.
        private IEnumerator UpdateTime()
        {
            if (_finish == false)
            {
                _currentTime += 0.1f;
            }
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(UpdateTime());
        }
   
        //Convert Time to Tow strings.  
        private void ConvertTimeToString()
        {
            _minutes = ((int)_currentTime / 60).ToString();
            _seconds = (_currentTime % 60).ToString("f1");
        }
        public void PauseTime()
        {
            _finish = true; ;
        }
        public void ContinueTime()
        {
            _finish = false;
        }
    }
}

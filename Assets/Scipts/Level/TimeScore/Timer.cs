using System.Collections;
using UnityEngine;

/// <summary>
/// This class mananges the Timer In Game.
/// </summary>
public class Timer : MonoBehaviour, ITimer
{
    public static Timer timeInstnce;

    private float _CurrentTime = 0;
    private bool _Finish = false;
    private string _Minutes;
    private string _Seconds;

    private void Awake()
    {
        timeInstnce = this;
    }
    void Start()
    {
        StartCoroutine(UpdateTime());
    }

    // Retun the Current time as a string.
    public string CurrentTimeText()
    {
        if (_Finish == true)
            return _Minutes + ":" + _Seconds;

        UpdateTime();
        ConvertTimeToString();

        return _Minutes + ":" + _Seconds;
    }

    //Update the current time.
    private IEnumerator UpdateTime()
    {
        if (_Finish == false)
        {
            _CurrentTime += 0.1f;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(UpdateTime());
    }
   
    //Convert Time to Tow strings.  
    private void ConvertTimeToString()
    {
        _Minutes = ((int)_CurrentTime / 60).ToString();
        _Seconds = (_CurrentTime % 60).ToString("f1");
    }
    public void PauseTime()
    {
        _Finish = true; ;
    }
    public void ContinueTime()
    {
        _Finish = false;
    }
}

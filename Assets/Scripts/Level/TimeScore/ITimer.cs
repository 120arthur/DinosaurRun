namespace Level.TimeScore
{
    public interface ITimer
    {
        string CurrentTimeText();
        void PauseTime();
        void ContinueTime();
    }
}
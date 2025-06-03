using System.Collections;
using UnityEngine;

public abstract class TimerView : MonoBehaviour
{
    protected Timer Timer;
    private Coroutine _timerViewProcess;

    private void OnDestroy()
    {
        Timer.Started -= OnTimerStarted;
        Timer.Finished -= OnTimerFinished;
    }

    public void Initialize(Timer timer)
    {
        Timer = timer;
        Timer.Started += OnTimerStarted;
        Timer.Finished += OnTimerFinished;
    }

    protected virtual IEnumerator ShowTimer()
    {
        while (Timer.IsRunning)
        {
            UpdateView();
            yield return null;
        }
    }

    protected abstract void UpdateView();

    private void OnTimerStarted() => _timerViewProcess = StartCoroutine(ShowTimer());

    private void OnTimerFinished()
    {
        if (_timerViewProcess != null)
        {
            StopCoroutine(_timerViewProcess);
            _timerViewProcess = null;
        }

        UpdateView();
    }
}

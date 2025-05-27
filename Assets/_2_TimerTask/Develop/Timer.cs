using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private MonoBehaviour _monoBehaviour;
    private Coroutine _process;

    private float _duration;
    private float _elapsedTime;

    public Timer(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
    }

    public event Action Started;
    public event Action Finished;

    public float ElapsedTime => _elapsedTime;

    public float CurrentProgress => _elapsedTime / _duration;

    public bool IsRunning => _process != null;

    public bool IsPause { get; private set; }

    public void Start(float duration)
    {
        Reset();

        _duration = duration;

        _process = _monoBehaviour.StartCoroutine(TimerProcess());

        Started?.Invoke();
    }

    /// <returns>Timer was paused or not. </returns>
    public bool TooglePause()
    {
        if (IsRunning)
            IsPause = IsPause == false;

        return IsRunning && IsPause;
    }

    public void Reset()
    {
        if (_process != null)
        {
            _monoBehaviour.StopCoroutine(_process);
            Finished?.Invoke();
        }

        _process = null;
        IsPause = false;
        _elapsedTime = _duration;
    }

    private IEnumerator TimerProcess()
    {
        _elapsedTime = _duration;

        while (_elapsedTime > 0)
        {
            if (IsPause == false)
                _elapsedTime -= Time.deltaTime;

            yield return null;
        }

        _elapsedTime = 0;

        Reset();
    }
}

using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private MonoBehaviour _monoBehaviour;
    private Coroutine _process;

    private ReactiveVariable<float> _duration;
    private ReactiveVariable<float> _elapsedTime;

    public Timer(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
        _duration = new();
        _elapsedTime = new();
    }

    public event Action Started;
    public event Action Finished;

    public IReadonlyVariable<float> ElapsedTime => _elapsedTime;

    public float CurrentProgress => _elapsedTime.Value / _duration.Value;

    public bool IsRunning => _process != null;

    public bool IsPause { get; private set; }

    public void Start(float duration)
    {
        Reset();

        _duration.Value = duration;

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

            _process = null;
            IsPause = false;
            _elapsedTime.Value = 0;

            Finished?.Invoke();
        }
    }

    private IEnumerator TimerProcess()
    {
        _elapsedTime.Value = _duration.Value;

        while (_elapsedTime.Value > 0)
        {
            if (IsPause == false)
                _elapsedTime.Value -= Time.deltaTime;

            yield return null;
        }

        _elapsedTime.Value = 0;

        Reset();
    }
}

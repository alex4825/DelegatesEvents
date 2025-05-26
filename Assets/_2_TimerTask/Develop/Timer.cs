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
    public event Action Paused;
    public event Action Unpaused;
    public event Action Finished;
    public event Action Resetted;

    public float ElapsedTime => _elapsedTime;

    public bool IsRunning => _process != null;

    public bool IsPause { get; private set; }

    public void Start(float duration)
    {
        if (IsRunning)
            Reset();

        _duration = duration;

        _process = _monoBehaviour.StartCoroutine(TimerProcess());

        Started?.Invoke();
    }

    public void Pause() => IsPause = true;

    public void Resume() => IsPause = false;

    public void Reset()
    {
        _monoBehaviour.StopCoroutine(_process);
        _process = null;
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

        Finished?.Invoke();
    }
}

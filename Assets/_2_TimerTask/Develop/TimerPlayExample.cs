using System;
using UnityEngine;

public class TimerPlayExample : MonoBehaviour
{
    [SerializeField] private StartButton _startButton;
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private ResetButton _resetButton;

    private Timer _timer;

    public event Action<Timer> TimerInitiated;

    private void Start()
    {
        _timer = new Timer(this);

        TimerInitiated?.Invoke(_timer);

        _startButton.Clicked += StartTimer;
        _pauseButton.Clicked += TryTooglePauseTimer;
        _resetButton.Clicked += ResetTimer;
    }

    private void OnDisable()
    {
        _startButton.Clicked -= StartTimer;
        _pauseButton.Clicked -= TryTooglePauseTimer;
        _resetButton.Clicked -= ResetTimer;
    }

    private void StartTimer(int duration)
    {
        _timer.Start(duration);
    }

    private bool TryTooglePauseTimer() => _timer.TooglePause();

    private void ResetTimer()
    {
        _timer.Reset();
    }
}

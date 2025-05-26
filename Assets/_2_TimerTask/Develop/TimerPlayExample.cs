using System;
using UnityEngine;

public class TimerPlayExample : MonoBehaviour
{
    [SerializeField] private PlayButton _playButton;
    [SerializeField] private PauseButton _pauseButton;

    private Timer _timer;

    public event Action<Timer> TimerInitiated;

    private void Start()
    {
        _timer = new Timer(this);

        TimerInitiated?.Invoke(_timer);

        _playButton.Clicked += StartTimer;
        _pauseButton.Clicked += TryTooglePauseTimer;
    }

    private void OnDisable()
    {
        _playButton.Clicked -= StartTimer;
        _pauseButton.Clicked -= TryTooglePauseTimer;
    }

    private void StartTimer(int duration)
    {
        _timer.Start(duration);
    }

    private bool TryTooglePauseTimer() => _timer.TooglePause();
}

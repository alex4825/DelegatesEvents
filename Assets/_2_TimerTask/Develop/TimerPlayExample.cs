using System;
using UnityEngine;

public class TimerPlayExample : MonoBehaviour
{
    [SerializeField] private PlayButton _playButton;

    private Timer _timer;

    public event Action<Timer> TimerInitiated;

    private void Start()
    {
        _timer = new Timer(this);

        TimerInitiated?.Invoke(_timer);

        _playButton.Clicked += StartTimer;
    }

    private void StartTimer(int duration)
    {
        _timer.Start(duration);
    }
}

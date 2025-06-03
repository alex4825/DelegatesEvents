using UnityEngine;

public class TimerPlayExample : MonoBehaviour
{
    [SerializeField] private TimerView[] _timerViews;

    [SerializeField] private StartButton _startButton;
    [SerializeField] private PauseButton _pauseButton;
    [SerializeField] private ResetButton _resetButton;

    private Timer _timer;

    private void Start()
    {
        _timer = new Timer(this);

        foreach (TimerView timerView in _timerViews)
            timerView.Initialize(_timer);

        _pauseButton.Initialize(_timer);

        _startButton.Clicked += StartTimer;
        _pauseButton.Clicked += TryTooglePauseTimer;
        _resetButton.Clicked += ResetTimer;
    }

    private void OnDestroy()
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

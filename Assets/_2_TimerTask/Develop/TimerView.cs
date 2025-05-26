using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TimerPlayExample _example;
    [SerializeField] private TextMeshProUGUI _timerLabel;

    private Timer _timer;


    private void Awake()
    {
        _example.TimerInitiated += OnTimerInitiated;
    }

    private void OnDisable()
    {
        _example.TimerInitiated -= OnTimerInitiated;
        _timer.Started -= OnTimerStarted;
    }

    private void OnTimerInitiated(Timer timer)
    {
        _timer = timer;
        _timer.Started += OnTimerStarted;
    }

    private void OnTimerStarted() => StartCoroutine(ShowTimer());

    private IEnumerator ShowTimer()
    {
        while (_timer.IsRunning)
        {
            _timerLabel.text = _timer.ElapsedTime.ToString("0.00");
            yield return null;
        }
    }
}

using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TimerPlayExample _example;
    [SerializeField] private TextMeshProUGUI _timerLabel;
    [SerializeField] private Slider _timerSlider;
    [SerializeField] private Image _heartsImage;

    private const string StartHeartsAmountKey = "_StartHeartsAmount";
    private const string HeartsAmountKey = "_HeartsAmount";

    private Timer _timer;
    private Coroutine _timerViewProcess;

    private void Awake()
    {
        _example.TimerInitiated += OnTimerInitiated;
    }

    private void OnDisable()
    {
        _example.TimerInitiated -= OnTimerInitiated;
        _timer.Started -= OnTimerStarted;
        _timer.Finished -= OnTimerFinished;
    }

    private void OnTimerInitiated(Timer timer)
    {
        _timer = timer;
        _timer.Started += OnTimerStarted;
        _timer.Finished += OnTimerFinished;
    }

    private void OnTimerStarted() => _timerViewProcess = StartCoroutine(ShowTimer());

    private IEnumerator ShowTimer()
    {
        SetStartHeartsAmount();

        while (_timer.IsRunning)
        {
            UpdateViews();
            yield return null;
        }
    }

    private void SetStartHeartsAmount()
        => _heartsImage.material.SetFloat(StartHeartsAmountKey, (int)Math.Ceiling(_timer.ElapsedTime));

    private void UpdateHearts()
        => _heartsImage.material.SetFloat(HeartsAmountKey, (int)Math.Ceiling(_timer.ElapsedTime));

    private void OnTimerFinished()
    {
        if (_timerViewProcess != null)
            StopCoroutine(_timerViewProcess);

        UpdateViews();
    }

    private void UpdateViews()
    {
        _timerLabel.text = _timer.ElapsedTime.ToString("0.00");
        _timerSlider.value = _timer.CurrentProgress;
        UpdateHearts();
    }
}

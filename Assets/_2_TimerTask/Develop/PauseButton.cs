using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _buttonLabel;
    [SerializeField] private TimerPlayExample _example;

    private const string PauseText = "Pause";
    private const string ResumeText = "Resume";

    public event Func<bool> Clicked;

    private Timer _timer;

    private void Start()
    {
        _example.TimerInitiated += OnTimerInitiated;
    }

    private void OnDisable()
    {
        _example.TimerInitiated -= OnTimerInitiated;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Clicked == null)
            return;

        bool isPaused = Clicked.Invoke();

        _buttonLabel.text = isPaused ? ResumeText : PauseText;
    }

    private void OnTimerInitiated(Timer timer)
    {
        _timer = timer;
        _timer.Started += () => _buttonLabel.text = PauseText;
        _timer.Finished += () => _buttonLabel.text = PauseText;
    }
}

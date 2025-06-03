using TMPro;
using UnityEngine;

public class TimerLabelView : TimerView
{
    [SerializeField] private TextMeshProUGUI _timerLabel;

    protected override void UpdateView()
        => _timerLabel.text = Timer.ElapsedTime.ToString("0.00");
}

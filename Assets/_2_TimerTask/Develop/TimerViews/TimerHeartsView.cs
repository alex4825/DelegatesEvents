using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerHeartsView : TimerView
{
    private const string StartHeartsAmountKey = "_StartHeartsAmount";
    private const string HeartsAmountKey = "_HeartsAmount";

    [SerializeField] private Image _heartsImage;

    protected override IEnumerator ShowTimer()
    {
        SetStartHeartsAmount();
        return base.ShowTimer();
    }

    protected override void UpdateView() => UpdateHearts();

    private void SetStartHeartsAmount()
        => _heartsImage.material.SetFloat(StartHeartsAmountKey, (int)Math.Ceiling(Timer.ElapsedTime));

    private void UpdateHearts()
        => _heartsImage.material.SetFloat(HeartsAmountKey, (int)Math.Ceiling(Timer.ElapsedTime));
}

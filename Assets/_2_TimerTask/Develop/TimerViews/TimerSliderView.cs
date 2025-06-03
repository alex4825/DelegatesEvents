using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : TimerView
{
    [SerializeField] private Slider _timerSlider;

    protected override void UpdateView()
        => _timerSlider.value = Timer.CurrentProgress;
}

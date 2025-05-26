using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _buttonLabel;

    private const string PauseText = "Pause";
    private const string ResumeText = "Resume";

    public event Func<bool> Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Clicked == null)
            return;

        bool isPaused = Clicked.Invoke();

        _buttonLabel.text = isPaused ? ResumeText : PauseText;
    }
}

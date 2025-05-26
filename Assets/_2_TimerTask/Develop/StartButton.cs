using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_InputField _inputField;

    public event Action<int> Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (int.TryParse(_inputField.text, out int inputValue) && inputValue > 0)
            Clicked?.Invoke(inputValue);
        else
            Debug.LogWarning($"{_inputField.text} isn't correct value");

        _inputField.text = string.Empty;
    }
}

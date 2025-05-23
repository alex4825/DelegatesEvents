using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrencyChangeButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Currencies _currency;

    public event Action<Currencies, int> Clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (int.TryParse(_inputField.text, out int inputValue))
            Clicked?.Invoke(_currency, inputValue);
        else
            Debug.LogWarning($"{_inputField.text} isn't correct value");        

        _inputField.text = string.Empty;
    }
}

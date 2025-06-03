using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private GameObject _walletContainer;

    [SerializeField] private List<CurrencyTextWrapper> _currencyTexts;

    private Dictionary<CurrencyTypes, TextMeshProUGUI> _currencyTextDictionary;
    private Wallet _wallet;
    
    private void OnDestroy()
    {
        _wallet.Changed -= UpdateCurrencyView;
    }

    public void Initialize(Wallet wallet)
    {
        _walletContainer.SetActive(true);
        _wallet = wallet;

        _currencyTextDictionary = new();

        foreach (var listPair in _currencyTexts)
            _currencyTextDictionary.TryAdd(listPair.currencyType, listPair.currencyText);

        _wallet.Changed += UpdateCurrencyView;

        foreach (var pair in _currencyTextDictionary)
            UpdateCurrencyView(pair.Key);
    }

    private void UpdateCurrencyView(CurrencyTypes currencyType)
        => _currencyTextDictionary[currencyType].text = _wallet.GetAmountFrom(currencyType).ToString();

    [Serializable]
    private class CurrencyTextWrapper
    {
        public CurrencyTypes currencyType;
        public TextMeshProUGUI currencyText;
    }
}

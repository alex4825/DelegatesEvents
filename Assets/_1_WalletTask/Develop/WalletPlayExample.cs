using System;
using System.Collections.Generic;
using UnityEngine;

public class WalletPlayExample : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private CurrencyChangeButton[] _addCurrancyButtons;
    [SerializeField] private CurrencyChangeButton[] _subtractCurrancyButtons;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet(
            new KeyValuePair<CurrencyTypes, int>(CurrencyTypes.Coin, 0),
            new KeyValuePair<CurrencyTypes, int>(CurrencyTypes.Diamond, 0),
            new KeyValuePair<CurrencyTypes, int>(CurrencyTypes.Energy, 0)
            );

        _walletView.Initialize(_wallet);

        foreach (CurrencyChangeButton button in _addCurrancyButtons)
            button.Clicked += AddCurrency;

        foreach (CurrencyChangeButton button in _subtractCurrancyButtons)
            button.Clicked += SubtractCurrency;
    }

    private void OnDestroy()
    {
        foreach (CurrencyChangeButton button in _addCurrancyButtons)
            button.Clicked -= AddCurrency;

        foreach (CurrencyChangeButton button in _subtractCurrancyButtons)
            button.Clicked -= SubtractCurrency;
    }

    private void AddCurrency(CurrencyTypes currencyName, int amount) => _wallet.AddCurancy(currencyName, amount);

    private void SubtractCurrency(CurrencyTypes currencyName, int amount) => _wallet.SubtractCurancy(currencyName, amount);
}

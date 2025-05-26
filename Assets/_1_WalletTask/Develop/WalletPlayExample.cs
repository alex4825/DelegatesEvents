using System;
using UnityEngine;

public class WalletPlayExample : MonoBehaviour
{
    [SerializeField] private CurrencyChangeButton[] _addCurrancyButtons;
    [SerializeField] private CurrencyChangeButton[] _subtractCurrancyButtons;

    private Wallet _wallet;

    public event Action<Wallet> WalletCreated;

    private void Awake()
    {
        _wallet = new Wallet(
            new Currency(Currencies.Coin, 0),
            new Currency(Currencies.Diamond, 0),
            new Currency(Currencies.Energy, 0)
            );

        WalletCreated?.Invoke(_wallet);

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

    private void AddCurrency(Currencies currencyName, int amount) => _wallet.AddCurancy(currencyName, amount);

    private void SubtractCurrency(Currencies currencyName, int amount) => _wallet.SubtractCurancy(currencyName, amount);
}

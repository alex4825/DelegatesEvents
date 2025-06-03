using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CurrencyTypes, Currency> _currencies;

    public Wallet(params KeyValuePair<CurrencyTypes, int>[] currencies)
    {
        _currencies = new Dictionary<CurrencyTypes, Currency>();

        foreach (var currency in currencies)
            if (_currencies.TryAdd(currency.Key, new Currency(currency.Value)) == false)
                Debug.Log($"{currency.Key} is already exists");
    }

    public event Action<CurrencyTypes> Changed;

    public void AddCurancy(CurrencyTypes name, int amount)
    {
        _currencies[name].Add(amount);
        Changed?.Invoke(name);
    }

    public void SubtractCurancy(CurrencyTypes name, int amount)
    {
        _currencies[name].Subtract(amount);
        Changed?.Invoke(name);
    }

    public int GetAmountFrom(CurrencyTypes name) => _currencies[name].Amount;
}

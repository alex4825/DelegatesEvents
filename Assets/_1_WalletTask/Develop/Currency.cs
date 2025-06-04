using System;
using UnityEngine;


public class Currency
{
    private CurrencyTypes _type;
    private ReactiveVariable<int> _amount;

    public Currency(CurrencyTypes type, ReactiveVariable<int> amount)
    {
        _type = type;
        _amount = amount;
    }

    public event Action<Currency> Changed;

    public CurrencyTypes Type => _type;

    public IReadonlyVariable<int> Amount => _amount;

    public void Add(int amount)
    {
        if (_amount.Value + amount < 0)
        {
            Debug.LogWarning($"Currency can't be negative");
            return;
        }

        _amount.Value += amount;
        Changed?.Invoke(this);
    }

    public void Subtract(int amount)
    {
        if (_amount.Value - amount < 0)
        {
            Debug.LogWarning($"Currency can't be negative");
            return;
        }

        _amount.Value -= amount;
        Changed?.Invoke(this);
    }
}

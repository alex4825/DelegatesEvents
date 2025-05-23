using System;

public class Wallet
{
    private Currency[] _currencies;

    public Wallet(params Currency[] currencies)
    {
        _currencies = currencies;
    }

    public event Action Changed;

    public void AddCurancy(Currencies name, int amount)
    {
        GetCurrencyBy(name).Add(amount);
        Changed?.Invoke();
    }

    public void SubtractCurancy(Currencies name, int amount)
    {
        GetCurrencyBy(name).Subtract(amount);
        Changed?.Invoke();
    }

    public int? GetAmountFrom(Currencies name)
    {
        foreach (Currency currency in _currencies)
            if (currency.Name == name)
                return currency.Amount;

        return null;
    }

    private Currency GetCurrencyBy(Currencies name)
    {
        foreach (Currency currency in _currencies)
            if (currency.Name == name)
            {
                return currency;
            }

        return null;
    }
}

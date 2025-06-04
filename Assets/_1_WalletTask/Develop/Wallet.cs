using System.Collections.Generic;
using System.Linq;

public class Wallet
{
    private List<Currency> _currencies;

    public Wallet(params KeyValuePair<CurrencyTypes, ReactiveVariable<int>>[] currencies)
    {
        _currencies = new();

        foreach (var currency in currencies)
            _currencies.Add(new Currency(currency.Key, currency.Value));
    }

    public List<Currency> Currencies => _currencies;

    public Currency GetCurrencyBy(CurrencyTypes type)
        => _currencies.First(item => item.Type == type);
}

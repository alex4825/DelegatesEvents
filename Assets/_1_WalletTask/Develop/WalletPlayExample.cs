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
            new (CurrencyTypes.Coin, new ReactiveVariable<int>(0)),
            new (CurrencyTypes.Diamond, new ReactiveVariable<int>(0)),
            new (CurrencyTypes.Energy, new ReactiveVariable<int>(0))
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

    private void AddCurrency(CurrencyTypes currencyType, int amount) => _wallet.GetCurrencyBy(currencyType).Add(amount);

    private void SubtractCurrency(CurrencyTypes currencyType, int amount) => _wallet.GetCurrencyBy(currencyType).Subtract(amount);
}

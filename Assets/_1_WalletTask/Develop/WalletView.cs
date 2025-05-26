using System;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private WalletPlayExample _playExample;
    [SerializeField] private GameObject _walletContainer;

    [SerializeField] private TextMeshProUGUI _coinsUIText;
    [SerializeField] private TextMeshProUGUI _diamondsUIText;
    [SerializeField] private TextMeshProUGUI _energyUIText;

    private Wallet _wallet;

    private void Awake()
    {
        _playExample.WalletCreated += Enable;
    }
    
    private void OnDestroy()
    {
        _playExample.WalletCreated -= Enable;
        _wallet.Changed -= UpdateCurrencyTexts;
    }

    private void Enable(Wallet wallet)
    {
        _walletContainer.SetActive(true);
        _wallet = wallet;

        _wallet.Changed += UpdateCurrencyTexts;

        UpdateCurrencyTexts();
    }

    private void UpdateCurrencyTexts()
    {
        _coinsUIText.text = _wallet.GetAmountFrom(Currencies.Coin).ToString();
        _diamondsUIText.text = _wallet.GetAmountFrom(Currencies.Diamond).ToString();
        _energyUIText.text = _wallet.GetAmountFrom(Currencies.Energy).ToString();
    }
}

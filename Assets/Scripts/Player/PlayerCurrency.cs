using Idler.Currency;
using Idler.Presenters;
using UnityEngine;

namespace Idler
{
    public class PlayerCurrency : MonoBehaviour, IPlayerCurrency
    {
        private SoftCurrency _softCurrency;
        private IPresenter<string> _softCurrencyPresenter;

        SoftCurrency IPlayerCurrency.SoftCurrency => _softCurrency;

        public void Init(IPresenter<string> softCurrencyPresenter)
        {
            _softCurrencyPresenter = softCurrencyPresenter;
            _softCurrency = new SoftCurrency();
            _softCurrency.onValueChanged += SoftCurrencyChangedCallback;
            _softCurrency.SetValue(0);
        }

        private void SoftCurrencyChangedCallback(double value)
        {
            _softCurrencyPresenter.Present(_softCurrency.ToString());
        }
    }
}

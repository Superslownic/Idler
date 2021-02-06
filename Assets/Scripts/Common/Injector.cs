using Idler.Presenters;
using Idler.Windows;
using UnityEngine;

namespace Idler
{
    public class Injector : MonoBehaviour
    {
        [SerializeField] private PlayerCurrency _playerCurrency;
        [SerializeField] private BuildingManager _buildingManager;
        [SerializeField] private ResourcesManager _resourcesManager;
        [SerializeField] private ClientSpawner _clientSpawner;
        [SerializeField] private WindowManager _windowManager;
        [SerializeField] private TextPresenter _softCurrencyPresenter;

        private void Start()
        {
            _playerCurrency.Init(_softCurrencyPresenter);
            _windowManager.Init();
            _buildingManager.Init(_resourcesManager, _playerCurrency, _windowManager);
            _clientSpawner.Init(_resourcesManager, _buildingManager);
        }
    }
}

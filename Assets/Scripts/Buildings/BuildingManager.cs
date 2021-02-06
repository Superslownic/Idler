using Idler.Currency;
using Idler.Windows;
using UnityEngine;

namespace Idler
{
    public class BuildingManager : MonoBehaviour, IBuildingManager
    {
        [SerializeField] private Building[] _buildings;

        private IPlayerCurrency _playerCurrency;
        private IWindowManager _windowManager;

        public void Init(IBuildingResources buildingResources, IPlayerCurrency playerCurrency, IWindowManager windowManager)
        {
            _playerCurrency = playerCurrency;
            _windowManager = windowManager;

            IBuildingData[] buildingDataArr = buildingResources.GetBuildingsData();

            for (int i = 0; i < _buildings.Length; i++)
            {
                _buildings[i].Init(buildingDataArr[i]);
                _buildings[i].OnClientAccepted += ClientAcceptedCallback;
                _buildings[i].OnTouch += BuildingTouchCallback;
            }
        }
        
        public IBuilding[] GetBuildings()
        {
            return _buildings;
        }

        bool IBuildingUpgrader.TryUpgrade(IBuilding building)
        {
            if (building.IsMaxLevel) return false;
            if (_playerCurrency.SoftCurrency.TryRemove(building.Data.GetUpgradeCost(building.Level)))
            {
                building.Upgrade();
                return true;
            }
            else return false;
        }

        private void ClientAcceptedCallback(double income)
        {
            _playerCurrency.SoftCurrency.Add(income);
        }

        private void BuildingTouchCallback(IBuilding building)
        {
            UpgradeBuildingWindowArgs windowData = new UpgradeBuildingWindowArgs(building, this);
            _windowManager.GetWindow<UpgradeBuildingWindow>().Open(windowData);
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _buildings.Length; i++)
            {
                _buildings[i].OnClientAccepted -= ClientAcceptedCallback;
                _buildings[i].OnTouch -= BuildingTouchCallback;
            }
        }
    }
}

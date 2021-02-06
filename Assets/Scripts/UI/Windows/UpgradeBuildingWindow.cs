using Idler.Presenters;
using UnityEngine;

namespace Idler.Windows
{
    public class UpgradeBuildingWindow : Window<UpgradeBuildingWindowArgs>
    {
        [SerializeField] private TextPresenter _levelPresenter;
        [SerializeField] private TextPresenter _incomePresenter;
        [SerializeField] private TextPresenter _upgradeCostPresenter;

        private IBuilding _building;
        private IBuildingUpgrader _buildingUpgrader;

        public override void Open(UpgradeBuildingWindowArgs args)
        {
            _building = args.building;
            _buildingUpgrader = args.buildingUpgrader;
            Refresh();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }

        public void Upgrade()
        {
            if (_buildingUpgrader.TryUpgrade(_building)) Refresh();
        }

        private void Refresh()
        {
            _levelPresenter.Present((_building.Level + 1).ToString());
            _incomePresenter.Present(_building.Data.GetIncome(_building.Level).ToString());

            if (_building.IsMaxLevel)
                _upgradeCostPresenter.gameObject.SetActive(false);
            else
            {
                _upgradeCostPresenter.gameObject.SetActive(true);
                _upgradeCostPresenter.Present(_building.Data.GetUpgradeCost(_building.Level).ToString());
            }
        }
    }
}

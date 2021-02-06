namespace Idler.Windows
{
    public class UpgradeBuildingWindowArgs : IWindowData
    {
        public IBuilding building;
        public IBuildingUpgrader buildingUpgrader;

        public UpgradeBuildingWindowArgs(IBuilding building, IBuildingUpgrader buildingUpgrader)
        {
            this.building = building;
            this.buildingUpgrader = buildingUpgrader;
        }
    }
}

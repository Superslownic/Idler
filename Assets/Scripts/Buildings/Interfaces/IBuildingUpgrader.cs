namespace Idler
{
    public interface IBuildingUpgrader
    {
        bool TryUpgrade(IBuilding building);
    }
}
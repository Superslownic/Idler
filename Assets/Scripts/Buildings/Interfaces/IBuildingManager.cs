namespace Idler
{
    public interface IBuildingManager : IBuildingUpgrader
    {
        IBuilding[] GetBuildings();
    }
}

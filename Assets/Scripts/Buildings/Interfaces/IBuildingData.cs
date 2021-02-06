namespace Idler
{
    public interface IBuildingData
    {
        double GetUpgradeCost(ushort level);
        double GetIncome(ushort level);
        ushort MaxLevel { get; }
    }
}
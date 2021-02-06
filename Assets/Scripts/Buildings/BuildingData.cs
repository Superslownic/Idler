using UnityEngine;

namespace Idler
{
    [CreateAssetMenu(fileName = "new BuildingData", menuName = "BuildingData")]
    public class BuildingData : ScriptableObject, IBuildingData
    {
        [SerializeField] private double[] _upgradeCost;
        [SerializeField] private double[] _income;

        public ushort MaxLevel => (ushort)_income.Length;

        public double GetIncome(ushort level)
        {
            return _income[level];
        }

        public double GetUpgradeCost(ushort level)
        {
            return _upgradeCost[level];
        }
    }
}

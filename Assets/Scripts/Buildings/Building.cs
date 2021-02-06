using Idler.TouchDetection;
using System;
using UnityEngine;

namespace Idler
{
    public class Building : MonoBehaviour, IBuilding, ITouchHandler
    {
        [SerializeField] private Transform _acceptPoint;

        public Vector3 AcceptPoint => _acceptPoint.position;
        public event Action<double> OnClientAccepted;
        public event Action<IBuilding> OnTouch;
        public IBuildingData Data { get; private set; }
        public ushort Level { get; private set; }
        public bool IsMaxLevel => Level + 1 >= Data.MaxLevel;

        public void Init(IBuildingData data)
        {
            Data = data;
            Level = 0;
        }

        void IBuilding.AcceptClient()
        {
            OnClientAccepted?.Invoke(Data.GetIncome(Level));
        }

        void IBuilding.Upgrade()
        {
            Level++;
        }

        void ITouchHandler.OnTouch()
        {
            OnTouch?.Invoke(this);
        }
    }
}

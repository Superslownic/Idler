using System;
using UnityEngine;

namespace Idler
{
    public interface IBuilding
    {
        event Action<double> OnClientAccepted;
        event Action<IBuilding> OnTouch;

        Vector3 AcceptPoint { get; }
        IBuildingData Data { get; }
        ushort Level { get; }
        bool IsMaxLevel { get; }

        void AcceptClient();
        void Upgrade();
    }
}

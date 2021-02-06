using System;
using UnityEngine;

namespace Idler
{
    public interface IActor
    {
        void Init(IActorData data);
        void MoveTo(Vector3 position, Action<IActor> reachedCallback);
        void Show();
        void Hide();
        void SetPosition(Vector3 position);
    }
}
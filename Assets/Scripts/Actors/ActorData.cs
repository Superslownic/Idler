using UnityEngine;

namespace Idler
{
    [CreateAssetMenu(fileName = "new ActorData", menuName = "ActorData")]
    public class ActorData : ScriptableObject, IActorData
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _stopingDistance;

        float IActorData.Speed => _speed;
        float IActorData.StopingDistance => _stopingDistance;
    }
}

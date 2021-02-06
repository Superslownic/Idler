using UnityEngine;

namespace Idler
{
    [CreateAssetMenu(fileName = "new ClientSpawnerData", menuName = "ClientSpawnerData")]
    public class ClientSpawnerData : ScriptableObject, IActorSpawnerData
    {
        [SerializeField] private Range _spawnTime;
        [SerializeField] private ushort _actorsLimit;

        public Range SpawnTime => _spawnTime;
        public ushort ActorsLimit => _actorsLimit;
    }
}

using UnityEngine;

namespace Idler
{
    public class ResourcesManager : MonoBehaviour, IBuildingResources, IActorResources
    {
        [SerializeField] private BuildingData[] _buildingData;
        [SerializeField] private ClientSpawnerData _spawnerData;
        [SerializeField] private ActorData _actorData;
        
        IBuildingData[] IBuildingResources.GetBuildingsData()
        {
            return _buildingData;
        }
        
        IActorSpawnerData IActorResources.GetActorSpawnerData()
        {
            return _spawnerData;
        }

        IActorData IActorResources.GetActorData()
        {
            return _actorData;
        }
    }
}

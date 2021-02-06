using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Idler
{
    public class ClientSpawner : MonoBehaviour
    {
        [SerializeField] private Client _clientPrefab;
        [SerializeField] private Transform[] _spawnPoints;

        private IActorSpawnerData _data;
        private IActorData _actorData;
        private IBuilding[] _buildings;
        private List<IActor> _busyActors;
        private Stack<IActor> _freeActors;
        private Dictionary<IActor, IBuilding> _targets;

        public void Init(IActorResources resources, IBuildingManager buildingManager)
        {
            _data = resources.GetActorSpawnerData();
            _actorData = resources.GetActorData();
            _buildings = buildingManager.GetBuildings();

            _busyActors = new List<IActor>();
            _freeActors = new Stack<IActor>();
            _targets = new Dictionary<IActor, IBuilding>();

            StartCoroutine(SpawnCycle());
        }

        private Vector3 GetRandomSpawnPoint()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        }

        private IBuilding GetRandomBuilding()
        {
            return _buildings[Random.Range(0, _buildings.Length)];
        }

        private IEnumerator SpawnCycle()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_data.SpawnTime.min, _data.SpawnTime.max));

                IActor actor = null;

                if (_busyActors.Count + _freeActors.Count >= _data.ActorsLimit)
                {
                    if (_freeActors.Count > 0)
                    {
                        actor = _freeActors.Pop();
                        _busyActors.Add(actor);
                        actor.Show();
                    }
                }
                else
                {
                    actor = Instantiate(_clientPrefab);
                    actor.Init(_actorData);
                    _busyActors.Add(actor);
                }

                if (actor != null)
                {
                    actor.SetPosition(GetRandomSpawnPoint());
                    IBuilding target = GetRandomBuilding();
                    _targets.Add(actor, target);
                    actor.MoveTo(target.AcceptPoint, OnActorReachedBuilding);
                }
            }
        }

        private void OnActorReachedBuilding(IActor actor)
        {
            _targets[actor].AcceptClient();
            _targets.Remove(actor);
            actor.MoveTo(GetRandomSpawnPoint(), DisposeActor);
        }

        private void DisposeActor(IActor actor)
        {
            _busyActors.Remove(actor);
            _freeActors.Push(actor);
            actor.Hide();
        }
    }
}

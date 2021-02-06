using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Idler
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Client : MonoBehaviour, IActor
    {
        private NavMeshAgent _agent;
        private IActorData _data;

        public void Init(IActorData data)
        {
            _data = data;
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = data.Speed;
        }
        
        void IActor.MoveTo(Vector3 position, Action<IActor> reachedCallback)
        {
            _agent.SetDestination(position);
            StartCoroutine(WaitForReached(reachedCallback));
        }

        void IActor.SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        void IActor.Show()
        {
            gameObject.SetActive(true);
        }

        void IActor.Hide()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator WaitForReached(Action<IActor> callback)
        {
            while (Vector3.Distance(_agent.destination, _agent.transform.position) >= _data.StopingDistance)
                yield return null;
            
            callback?.Invoke(this);
        }
    }
}

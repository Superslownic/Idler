using UnityEngine;

namespace Idler.TouchDetection
{
    public class TouchDetector : MonoBehaviour
    {
        [SerializeField] private float _maxDistance;
        [SerializeField] private LayerMask _layers;
        [SerializeField] private Camera _camera;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, _maxDistance, _layers))
                {
                    if (hit.transform.TryGetComponent<ITouchHandler>(out ITouchHandler touchHandler))
                    {
                        touchHandler.OnTouch();
                    }
                }
            }
        }
    }
}

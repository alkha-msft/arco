using UnityEngine;

namespace Assets.Scripts
{
    public class BillboardService : MonoBehaviour
    {
        public void Update()
        {
            var camera = Camera.main;
            var cameraPosition = camera.transform.position;
            var lookDirection = cameraPosition - transform.position;
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PointOfInterestService : MonoBehaviour
    {
        private List<PointOfInterest> _pointsOfInterest = new List<PointOfInterest>();

        [SerializeField]
        private GameObject _parentObject;

        [SerializeField]
        private GameObject _pinPrefab;

        public void Start()
        {
            _pointsOfInterest.Add(new PointOfInterest
            {
                Latitude = 47.665015f,
                Longitude = -122.116829f,
                Name = "Redmond",
            });

            _pointsOfInterest.Add(new PointOfInterest
            {
                Longitude = 31.244882292013024f,
                Latitude = 30.029642952733806f,
                Name = "Cairo",
            });

            _pointsOfInterest.Add(new PointOfInterest
            {
                Longitude = 0,
                Latitude = 0,
                Name = "ZERO",
            });

            foreach (var poi in _pointsOfInterest)
            {
                var position = ConvertPolarToCartesian(Mathf.Deg2Rad * (poi.Latitude), Mathf.Deg2Rad * poi.Longitude, 1);
                var pinInstance = Instantiate(_pinPrefab);
                pinInstance.transform.parent = _parentObject.transform;
                pinInstance.transform.localPosition = position;
            }
        }

        public Vector3 ConvertPolarToCartesian(float phi, float theta, float radius = 1)
        {
            return new Vector3
            {
                x = radius * Mathf.Cos(phi) * Mathf.Cos(theta),
                z = radius * Mathf.Cos(phi) * Mathf.Sin(theta), 
                y = radius * Mathf.Sin(phi),
            };
        }
    }
}

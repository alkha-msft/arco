using System.Collections;
using UnityEngine;

namespace Assets
{
    public class RotateGlobe : MonoBehaviour
    {
        /// <summary>
        /// The rotation of the earth in degrees per second around its axis
        /// </summary>
        [SerializeField]
        private float angularRotationSpeed = 90;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up, angularRotationSpeed * Time.deltaTime);
        }
    }
}
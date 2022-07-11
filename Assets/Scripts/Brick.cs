using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class Brick : MonoBehaviour
    {
        private float brickLength;
        public float m_offset => brickLength;

        void Start()
        {
            brickLength = transform.localScale.z;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

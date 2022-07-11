using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class AutoCleaner : MonoBehaviour
    {

        [SerializeField] private CameraControler m_camera;

        private Transform camTransform;

        [SerializeField] private float camPos;

        [SerializeField] private float deleteAfter;


        //
        private float extraTimer;
        private bool isCubeSpot = false;
        private CubeSpotCleaner cubeSpot;

        void Start()
        {
            if(GetComponent<Rigidbody>()!=null)
            {
                deleteAfter = 5f;
            }
            else
            {
                deleteAfter = 10f;
                if (GetComponent<CubeSpotCleaner>() != null)
                {
                    isCubeSpot = true;
                    cubeSpot = GetComponent<CubeSpotCleaner>();
                    extraTimer = deleteAfter;
                }
            }

            m_camera = FindObjectOfType<CameraControler>().GetComponent<CameraControler>();
            camTransform = m_camera.transform;

            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            camPos = camTransform.position.z;
            if(transform.position.z+deleteAfter< camPos)
            {
                if(isCubeSpot==false)
                {
                    Destroy(gameObject);
                }
                else
                {
                    extraTimer -= Time.fixedDeltaTime;
                    if (extraTimer < 0) CubeCleaning();
                }
            }
        }

        private void CubeCleaning()
        {
            cubeSpot.CheckMissing();
            extraTimer = deleteAfter;
        }

    }
}

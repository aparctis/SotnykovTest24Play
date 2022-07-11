using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class PlayerMover : MonoBehaviour
    {

        //jump on Cube
        [SerializeField] private float cubeHigh = 1;
        private bool newCube = false;
        private bool lostCube = false;
        private Vector3 cobePos;

        private int onFlore = 0;


        #region Unity Events
        void Start()
        {

        }

        void FixedUpdate()
        {
            if (newCube)
            {
                transform.position = cobePos;
                newCube = false;
            }

            else if(lostCube)
            {
                transform.position = cobePos;

                lostCube = false;
            }



        }
        #endregion


        public void CubeUp(Vector3 cubePosition)
        {
            onFlore++;

            cobePos = new Vector3(cubePosition.x, transform.position.y+cubeHigh, transform.position.z);
            newCube = true;
            Debug.Log("Cube Up");
        }

        public void CubeDown()
        {
            onFlore--;

            NewFlore();

            //cobePos = new Vector3(transform.position.x, transform.position.y - cubeHigh, transform.position.z);
            lostCube = true;
            Debug.Log("Cube Down. Player y = "+ cobePos.y + " . flore  = " + onFlore);
        }


        private void NewFlore()
        {
            float nextY = onFlore * cubeHigh;
            cobePos = new Vector3(transform.position.x,nextY, transform.position.z);
        }


    }

}
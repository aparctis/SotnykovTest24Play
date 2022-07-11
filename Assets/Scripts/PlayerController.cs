using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController controller;
        
        //Direction vector
        private Vector3 dir;
        //speed
        [SerializeField] private float speed;

        //for Jump and FixedUpdate
        [SerializeField] private float jumpForce;
        [SerializeField] private float gravity;

        //Lines (0=left, 1=midle, 2=right)
        private int lineToMove = 1;
        public float lineDistance = 4;


        //for test
        private bool newCube = false;
        [SerializeField] private float cubeHigh = 2;
        private Vector3 cubePos;


        #region Unity Events
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            //checking speed
            dir.z = speed;

            //starter Jump
            //dir.y += gravity * Time.fixedDeltaTime;

            //Moving character
            controller.Move(dir * Time.fixedDeltaTime);

            
        }

        void Update()
        {
            if(SwipeController.swipeRight)
            {
                if (lineToMove < 2)
                    lineToMove++;
            }

            else if (SwipeController.swipeLeft)
            {
                if (lineToMove >0)
                    lineToMove--;
            }

            if(newCube)
            {
                transform.position = new Vector3(cubePos.x, cubePos.y+cubeHigh, cubePos.z);
                newCube = false;
            }

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if(lineToMove==0)
            {
                targetPosition += Vector3.left * lineDistance;
            }
            else if(lineToMove==2)
            {
                targetPosition += Vector3.right * lineDistance;
            }

            transform.position = targetPosition;
        }
        #endregion

        //rewrite!
        private void Jump()
        {
            if(controller.isGrounded)
                dir.y = jumpForce;
        }

        //my code
        public void CubeUp(Vector3 cubePosition)
        {
            cubePos = cubePosition;
            newCube = true;
        }


    }
}

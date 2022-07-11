using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class Cube : MonoBehaviour
    {
        private bool isFollowing = false;
        public bool m_isFollowing => isFollowing;

        private bool isStoped = false;
        private float stopOffset;

        private CubeCatcher m_catcher;
        public CubeCatcher catcher => m_catcher;

        private Transform catcherTrans;

        [SerializeField] private GameObject sparks;


        //flores
        private float startY;
        private float cubeHigh;
        [SerializeField]private int level = 0;
        private float newY;

        //if stopped
        private float currentOffset;
        private bool deleted = false;
        private float cubeLength;

        private void Start()
        {
            startY = transform.position.y;
            cubeHigh = transform.localScale.y;
            cubeLength = transform.localScale.z*1.2f;

        }


        void FixedUpdate()
        {
            if (isFollowing)
            {
                newY = startY + (cubeHigh * level);
                transform.position = new Vector3(catcherTrans.position.x, newY, catcherTrans.position.z);
            }

            else if (isStoped)
            {
                currentOffset = transform.position.z + stopOffset + cubeLength;

                if (deleted == false)
                {
                    if(currentOffset<catcherTrans.position.z)
                    {

                        catcher.MissCube(this);
                        deleted = true;
                        DestroyCube();
                    }
                }

            }
        }

        //cube catcher
        public void FollowCatcher(CubeCatcher newCatcher)
        {
            if(isFollowing==false)
            {
                m_catcher = newCatcher;
                catcherTrans = m_catcher.transform;
                isFollowing = true;
                MakeSparks();
            }


        }




        public void SetLevel(int newLvl)
        {
            level = newLvl;

        }

        //collect new cube
        public void OnCollisionEnter(Collision collision)
        {
            if (isFollowing)
            {
                if (collision.transform.GetComponent<Cube>() != null)
                {

                    Cube newCube = collision.transform.GetComponent<Cube>();
                    if (newCube.m_isFollowing == false)                     
                    {
                        newCube.FollowCatcher(catcher);
                        m_catcher.NewCube(newCube);
                    }




                }

                else if (collision.transform.GetComponent<Brick>() != null)
                {
                    Brick m_brick = collision.transform.GetComponent<Brick>();

                    stopOffset = m_brick.m_offset+catcher.fallingOffset;
                    isStoped = true;
                    isFollowing = false;

                }


            }


        }

        public void DestroyCube()
        {
            MakeSparks();
            Destroy(gameObject);
        }



        public void MakeSparks()
        {
            GameObject sparkEffect = Instantiate(sparks);
            sparkEffect.transform.position = gameObject.transform.position;
        }


    }
}

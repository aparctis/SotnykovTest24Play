using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class CubeCatcher : MonoBehaviour
    {
        private float cubeHigh = 1;
        [SerializeField] private PlayerMover playerM;

        public List<Cube> allCubes = new List<Cube>();

        [SerializeField] private float m_fallingOffset;
        public float fallingOffset => m_fallingOffset;


        [SerializeField] private float m_cubeDestroyOffset = 1;
        public float cubebeDestroyOffset => m_cubeDestroyOffset;


        //changing speed by cube count
        [SerializeField] private InvisibleCar car;

        //jumping
        [SerializeField] private PlayerBody playerB;

        //Cube count control
        [SerializeField] private int maxCubesCount = 12;



        //DELETE LATER
        private int logNumber = 0;


        void Start()
        {

        }

        public void OnCollisionEnter(Collision collision)
        {

            if (collision.transform.GetComponent<Cube>() != null)
            {
                Cube m_cube = collision.transform.GetComponent<Cube>();




                if(m_cube.m_isFollowing == false)
                {
                    m_cube.FollowCatcher(this);
                    playerM.CubeUp(collision.transform.position);

                    allCubes.Add(m_cube);

                    //jumping
                    playerB.Jump();
                }





            }

            else if(collision.transform.GetComponent<Brick>() != null)
            {
                playerB.Fall();
            }

        }

        public void NewCube(Cube newCube)
        {
            if (allCubes.Count < maxCubesCount)
            {
                allCubes.Add(newCube);
                playerM.CubeUp(newCube.transform.position);

                CheckLevels();
            }

            else
                newCube.DestroyCube();

        }

        public void MissCube(Cube missingCube)
        {
            allCubes.Remove(missingCube);
            CheckLevels();
            playerM.CubeDown();
            ShakeCamera();


        }

        private void CheckLevels()
        {
            for (int i = 0; i < allCubes.Count; i++)
            {
                int lvl = allCubes.Count - (i + 1);
                allCubes[i].SetLevel(lvl);
            }
            playerB.Jump();
            car.SetSpeed(allCubes.Count);

            //Delete later
            Debuging();
        }


        private void ShakeCamera()
        {
            Handheld.Vibrate();
        }

        //Delete later
        private void Debuging()
        {
            Debug.Log(logNumber + "Cubes must be - " + allCubes.Count);
            logNumber++;
        }

    }
}

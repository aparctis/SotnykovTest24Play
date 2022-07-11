using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class CubeSpotCleaner : MonoBehaviour
    {
        private Cube[] cubes;

        private int inList;


        private void Start()
        {
            Invoke("InitialCubes", 0.5f);
        }

        private void InitialCubes()
        {
            cubes = GetComponentsInChildren<Cube>();
            inList = cubes.Length;
        }


        //If all cubes in CubeSpot are missing, it would be destroyed 
        public void CheckMissing()
        {
            int cubeMissing = 0;
            for (int i =0; i<inList; i++)
            {
                if(cubes[i]==null)
                {
                    cubeMissing++;
                    if(cubeMissing==inList)
                    {
                        Debug.Log("Spot DESTROY");
                        Destroy(gameObject);
                    }
                }
            }
        }

    }

}
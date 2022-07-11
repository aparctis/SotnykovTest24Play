using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class Spumer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> spumlist = new List<GameObject>();
        
        
        private GameObject spumedObj;

        private bool orphan = false;
        private float timer = 2.0f;

        void Start()
        {
            int objectIndex = Random.Range(0, (spumlist.Count - 1));
            spumedObj = Instantiate(spumlist[objectIndex]);
            spumedObj.transform.position = transform.position;

            orphan = true;
        }

        private void Update()
        {
            if (orphan == false)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    NoParrent();
                }
            }
        }

        private void NoParrent()
        {
            spumedObj.transform.root.parent = null;
            Debug.Log("No parrent done");
            orphan = true;
        }
        
    }
}

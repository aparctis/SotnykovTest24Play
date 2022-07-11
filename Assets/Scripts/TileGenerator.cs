using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer24
{
    public class TileGenerator : MonoBehaviour
    {

        public GameObject[] TilePrefubs;
        private float spawnPos = 50;
        [SerializeField]private float tileLength = 50;

        [SerializeField] private Transform player;
        [SerializeField] private int startTileCount;
        private int prefubNumber = 0;





        //delete platforms
        private List<GameObject> activeTiles = new List<GameObject>();
        [SerializeField]private int deleteAfter = 60;

        void Start()
        {

            for (int i =0; i<startTileCount; i++)
            {                
                SpawnTile(prefubNumber);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (player.position.z- deleteAfter > spawnPos - (startTileCount * tileLength))
            {
                SpawnTile(prefubNumber);
                DeleteTile();

            }

        }

        private void SpawnTile(int tileIndex)
        {
            GameObject nextTile = Instantiate(TilePrefubs[tileIndex], transform.forward * spawnPos, transform.rotation);
            activeTiles.Add(nextTile);
            spawnPos += tileLength;
            prefubNumber++;
            if (prefubNumber == TilePrefubs.Length)
                prefubNumber = 0;
        }

        private void DeleteTile()
        {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
    }
}
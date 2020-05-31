using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Control
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] items;
        [SerializeField] float minSec;
        [SerializeField] float maxSec;
        [SerializeField] float minX;
        [SerializeField] float maxX;
        [SerializeField] float minY;
        [SerializeField] float maxY;
        private bool spawnReady = false;
        public int randIndex;
        public float settedDelayDuration = 0f;
        public float currWaitSec = 0f;

        // Start is called before the first frame update
        void Start()
        {
            settedDelayDuration = Random.Range(minSec, maxSec);
        }

        // Update is called once per frame
        void Update()
        {
            if(!spawnReady)
            {
                TikTokTilNextSpawn();
                return;
            }

            SpawnRandomItem();
        }

        private void TikTokTilNextSpawn()
        {
            currWaitSec += Time.deltaTime;

            if(currWaitSec >= settedDelayDuration)
            {
                currWaitSec = 0f;
                spawnReady = true;
            }
        }

        private void SpawnRandomItem()
        {
            randIndex = UnityEngine.Random.Range(0, items.Length);
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);
            Vector2 instPos = new Vector2(randX, randY);

            Instantiate(items[randIndex], instPos, Quaternion.identity);

            spawnReady = false;
            settedDelayDuration = Random.Range(minSec, maxSec);

        }
    }
}

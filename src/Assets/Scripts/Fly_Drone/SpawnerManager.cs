using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    Vector3[] positions = new Vector3[5];
    public GameObject obj;
    public bool isSpawn = true;
    public float spawnDelay = 0f;
    float spawnTimer = 2.0f;
    public float wait = 4.0f;
    float spawnNumber = 10;
    // float functionDelay = 15.0f;

    // Use this for initialization
    void Start () {
        // CreatePositions();
        StartCoroutine("SpawnDrone", 2);

    }

    // Update is called once per frame
    void Update () {
        // SpawnDrone();
        //StartCoroutine("SpawnDrone", functionDelay);
    }

    IEnumerator SpawnDrone()
    {
         // yield return new WaitForSeconds(wait); //4.0초간 실행을 보류한다.

        for (int i = 0; i < spawnNumber; i++)
        {
            if (isSpawn == true)
            {
                if (spawnTimer > spawnDelay)
                {
                    int rand = Random.Range(0, positions.Length);
                    Instantiate(obj, positions[rand], Quaternion.identity);
                    spawnTimer = 0f;
                }
                spawnTimer += Time.deltaTime;
            }          
        }
        yield return null;
    }

    /*
    void CreatePositions()
    {
        float viewPosY = 1.2f;
        float viewPosX = 0f;
        float gapX = 1f / 6f;

        for (int i = 0; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.z = 0f;
            positions[i] = worldPos;
            print(worldPos);
        }
    }
    */

}

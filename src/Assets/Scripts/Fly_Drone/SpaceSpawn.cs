using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSpawn : MonoBehaviour {

    public Transform[] point;

    public GameObject drone;

    public float createTime = 2.0f;

    public int maxDrone = 10;

    public bool isGameOver = false;

	// Use this for initialization
	void Start () {

        point = GameObject.Find("SpawnerManager").GetComponentsInChildren<Transform>();

        if (point.Length > 0)
        {
            StartCoroutine(this.CreateDrone());
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CreateDrone()
    {
        while (!isGameOver)
        {
            int droneCount = (int)GameObject.FindGameObjectsWithTag("Player").Length;

            if (droneCount < maxDrone)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, point.Length);

                Instantiate(drone, point[idx].position, point[idx].rotation);
            }
            else
                yield return null;
        }
    }
}

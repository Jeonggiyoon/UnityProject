using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour 
{
    public PlayerHealth playerHealth;
    public GameObject goEnemy;          // 프리팹 받을 공간
    public float fSpawnTime = 3f;       // 젠 시간
    public Transform[] spawnPints;      // 스폰장소 Transform 배열

	// Use this for initialization
	void Start () 
    {
        // "Spawn"이라는 함수를 fSpawnTime시간 뒤에 실행하고, fSpawnTime시간뒤에 다시 실행해라
        InvokeRepeating("Spawn", fSpawnTime, fSpawnTime);
	}

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
            return;

        int spawnPointIndex = 0;

        Instantiate(goEnemy,
            spawnPints[spawnPointIndex].position,
            spawnPints[spawnPointIndex].rotation);
    }

}

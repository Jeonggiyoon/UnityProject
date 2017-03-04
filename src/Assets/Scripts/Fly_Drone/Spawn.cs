using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour {

    public bool enableSpawn = false;
    public GameObject obj; //Prefab을 받을 public 변수 입니다.

    //ArrayProf other; //데이터 타입은 사용할 스크립트 명
    //other = gameObject.GetComponent("ArrayProf") as ScriptName;


    //this.gameObject.GetComponent<ScriptName>();

    void SpawnEnemy()
    {
        // float randomX = Random.Range(-10f, 10f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        //float randomZ = Random.Range(-10f, 10f); //적이 나타날 Z좌표를 랜덤으로 생성해 줍니다.
        
        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(obj, new Vector3(0f, 0f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
        }
    }
    void Start()
    {
        //ArrayProf.locationxyz[0];

        //GameObject.Find("Spawn").GetComponent("ArrayProf").func1();
        //GetComponent("ArrayProf").func1();
        // GameObject.Find("ArrayPof").SendMessage("func1", 0);
        gameObject.SendMessage("func1", 0);
        //Script = GetComponent("ArrayProf");

        // GetComponent("ArrayProf").func1();

        SpawnEnemy();


        //GameObject.Find("ArrayPof").SendMessage("func1", 1);
        gameObject.SendMessage("func1", 1);

        SpawnEnemy();
        
       //InvokeRepeating("SpawnEnemy", 3, 3); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
    }
    void Update()
    {

    }
}

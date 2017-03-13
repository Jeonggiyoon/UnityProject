using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMove : MonoBehaviour
{

    public Transform tr;
    //private float fAngleY = 0.0f;
    public float fSpeed = 1.0f;

    //public TextAsset textFile;   //텍스트 파일 모두 지정

    //public Vector3[] vectors;   //백터 배열 

   // public float wait = Random.Range(0f, 10f);

    float randomY = Random.Range(5f, 30f); //적이 나타날 Z좌표를 랜덤으로 생성해 줍니다.
    float randomX = Random.Range(-30f, 30f);
    float randomZ = Random.Range(-30f, 30f);
    float landing = 0.0f;

    

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();

        StartCoroutine(StartRutine());

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator StartRutine()
    {

        //transform.Translate(Vector3.up, Space.Self);
        //yield return null;

         //yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

         while (tr.localPosition.y <=  randomY)
         {
              transform.Translate(0, randomY * fSpeed * Time.deltaTime, 0, Space.Self); 
              yield return null;
         }

        //yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

        while (tr.localPosition.x <= randomX)
        {
            transform.Translate(randomX * fSpeed * Time.deltaTime, 0, 0, Space.Self);
            yield return null;
        }

        //yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

        while (tr.localPosition.z <= randomZ)
        {
            transform.Translate(0, 0, randomZ * fSpeed * Time.deltaTime,  Space.Self);
            yield return null;
        }

        //yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

        while (tr.localPosition.y >= landing )
        {
            transform.Translate(Vector3.down, Space.Self);
            yield return null;
        }

    }
}


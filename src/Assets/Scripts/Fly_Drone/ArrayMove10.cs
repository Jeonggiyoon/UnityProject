using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayMove10 : MonoBehaviour
{
    private Transform tr;
    //private float fAngleY = 0.0f;
    private float fSpeed = 2.0f;

    private float node = 3;   //x, y, z, 좌표의 노드 개수 ( 0~ 3까지 총 4개), 배열문의 반복횟수를 변수에 지정

    private float[] arrayX = { 15, 15, 0, 0 };    //x 좌표 배열 값
    private float[] arrayY = { 0, 10, 10, 0 };    //y 좌표 배열 값
    private float[] arrayZ = { 0, 10, 0, 0 };    // z 좌표 배열 값

    private float wait = 1.0f;   // 딜레이 변수 

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(StartRutine());
    }

    /* Update is called once per frame
	void Update () {
		
	}
    */

    IEnumerator StartRutine()
    {
        yield return new WaitForSeconds(wait); //1.0초간 실행을 보류한다.

        for (int i = 0; i <= node; i++)
        {
            if (tr.position.x < arrayX[i])
            {
                while (tr.position.x <= arrayX[i])
                {
                    tr.position += tr.right * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.x > arrayX[i])
            {
                while (tr.position.x >= arrayX[i])
                {
                    tr.position -= tr.right * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.x == arrayX[i])
            {
                yield return null;
            }

            if (tr.position.y < arrayY[i])
            {
                while (tr.position.y <= arrayY[i])
                {
                    tr.position += tr.up * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.y > arrayY[i])
            {
                while (tr.position.y >= arrayY[i])
                {
                    tr.position -= tr.up * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.y == arrayY[i])
            {
                yield return null;
            }

            if (tr.position.z < arrayZ[i])
            {
                while (tr.position.z <= arrayZ[i])
                {
                    tr.position += tr.forward * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.z > arrayZ[i])
            {
                while (tr.position.z >= arrayZ[i])
                {
                    tr.position -= tr.forward * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.z == arrayZ[i])
            {
                yield return null;
            }

        }

    }
}

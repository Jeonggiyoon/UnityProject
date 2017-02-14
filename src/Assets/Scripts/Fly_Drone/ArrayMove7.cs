using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayMove7 : MonoBehaviour
{
    private Transform tr;
    //private float fAngleY = 0.0f;
    private float fSpeed = 2.0f;

    private float node = 3;

    private float[] arrayX = { 40, 40, 50, 50 };
    private float[] arrayY = { 0, 10, 10, 0 };
    private float[] arrayZ = { 40, 40, 50, 50 };

    private float wait = 0.0f;

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
        yield return new WaitForSeconds(wait); //0.0초간 실행을 보류한다.

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

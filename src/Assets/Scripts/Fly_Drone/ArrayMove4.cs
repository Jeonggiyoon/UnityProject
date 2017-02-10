﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayMove4 : MonoBehaviour
{
    private Transform tr;
    //private float fAngleY = 0.0f;
    private float fSpeed = 2.0f;

    private float node = 3;

    private float[] arrayX = { 20, 20, 10, 10 };
    private float[] arrayY = { 0, 25, 25, 0 };
    private float[] arrayZ = { 20, 20, 5, 5 };

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayProf : MonoBehaviour
{

    
    private Transform tr;
    //private float fAngleY = 0.0f;
    private float fSpeed = 2.0f;

    private float node = 3;

    public static int path_no;

    
    //private float[] arrayX = { 10, 10, 10, 10 };
    //private float[] arrayY = { 0, 10, 10, 0 };
    //private float[] arrayZ = { 0, 0, 10, 10 };

    // private float[,] locationxyz = { { 10, 0, 0 }, { 10, 10, 0 }, { 10, 10, 10 }, { 10, 0, 10 }  };
    public static float[,,] locationxyz = { { { 10, 0, 0 }, { 10, 10, 0 }, { 10, 10, 10 }, { 10, 0, 10 } },
                                      { { 20, 0, 0 }, { 20, 10, 0 }, { 200, 10, 10 }, { 20, 0, 10 } } };


    public Transform[] nodes;

    private float wait = 4.0f;

    public void func1( int i)
    {
        path_no = i;
    }


    // Use this for initialization
    void Start()
    {
        //nodes[0].position;
        tr = GetComponent<Transform>();
     

        StartCoroutine(StartRutine());
    }

    /* Update is called once per frame
	void Update () {
		
	}
    */

    IEnumerator StartRutine()
    {
        yield return new WaitForSeconds(wait); //4.0초간 실행을 보류한다.

        for (int i = 0; i <= node; i++)
        {
            if (tr.position.x < locationxyz[path_no, i, 0])
            {
                while (tr.position.x <= locationxyz[path_no, i, 0])
                {
                    tr.position += tr.right * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.x > locationxyz[path_no, i, 0])
            {
                while (tr.position.x >= locationxyz[path_no, i, 0])
                {
                    tr.position -= tr.right * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.x == locationxyz[path_no, i, 0])
            {
                yield return null;
            }

            if (tr.position.y < locationxyz[path_no, i, 1])
            {
                while (tr.position.y <= locationxyz[path_no, i, 1])
                {
                    tr.position += tr.up * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.y > locationxyz[path_no, i, 1])
            {
                while (tr.position.y >= locationxyz[path_no, i, 1])
                {
                    tr.position -= tr.up * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.y == locationxyz[path_no, i, 1])
            {
                yield return null;
            }

            if (tr.position.z < locationxyz[path_no, i, 2])
            {
                while (tr.position.z <= locationxyz[path_no, i, 2])
                {
                    tr.position += tr.forward * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.z > locationxyz[path_no, i, 2])
            {
                while (tr.position.z >= locationxyz[path_no, i, 2])
                {
                    tr.position -= tr.forward * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.position.z == locationxyz[path_no, i, 2])
            {
                yield return null;
            }

        }

    }
}

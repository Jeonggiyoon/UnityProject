using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayMove : MonoBehaviour {

    public Transform tr;
    //private float fAngleY = 0.0f;
    public float fSpeed = 2.0f;

    public TextAsset textFile;   //텍스트 파일 모두 지정

    public Vector3[] vectors;   //백터 배열 

    public float wait = 2.0f;


    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();

        StartCoroutine(StartRutine());

        /*
        if (vectors.Length > 0)
            Debug.Log(vectors[0].x);
        */
        if (textFile != null)           // 만약 텍스트 파일이 null 값이 아니라면 리드 텍스트 
        {
            //ReadText();
            ReadText1();
        }

    }
	
	/* Update is called once per frame
	void Update () {
		
	}
    */
    /*
    public void ReadText()                       //리드 텍스트 매서드 
    {
        string allText = textFile.text;

        string[] allLines = allText.Split('\n');

        for (int i = 0; i < allLines.Length; i++)
        {
            // allLines[i].Replace(" ", " ");
            //string[] words = allLines[i].Split(',');

            // vectors[i].x = float.Parse(allLines[i]);

            Debug.Log(allLines[i]);
            
            //Debug.Log(vectors[i].x);
        }
    }
    */

    public void ReadText1 ()

    {
        string allText = textFile.text;

        for (int i = 0; i < allText.Length; i++)
        {
            for (int j = 0; j < allText.Length; j++)
            {
                Debug.Log(allText[i]);
            }
        }

    }

    IEnumerator StartRutine()
    {

        for (int i = 0; i <= vectors.Length; i++)              // 0 ~ vector.length  배열 사이즈 까지  ++
        {
            if (tr.localPosition.x < vectors[i].x)           //만약 x가 vectorElement[i] 의 x값 보다 작거나 같을떄까지 오른쪽으로 이동
            {                                                // 로칼 포지션(로컬 좌표) ,
                yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다. 
                
                while (tr.localPosition.x <= vectors[i].x)
                {
                    tr.localPosition += tr.right * fSpeed * Time.deltaTime;
                    yield return null;
                }
            }
            else if (tr.localPosition.x > vectors[i].x)
            {

                yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

                while (tr.localPosition.x >= vectors[i].x)
                {
                    tr.localPosition -= tr.right * fSpeed * Time.deltaTime;       //왼쪽으로 이동
                    yield return null;
                }
            }
            else if (tr.localPosition.x == vectors[i].x)                             //같으면 리턴
            {
                yield return null;
            }

            if (tr.localPosition.y < vectors[i].y)
            {

                yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

                while (tr.localPosition.y <= vectors[i].y)
                {
                    tr.localPosition += tr.up * fSpeed * Time.deltaTime;       //위로 이동
                    yield return null;
                }
            }
            else if (tr.localPosition.y > vectors[i].y)
            {
                yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

                while (tr.localPosition.y >= vectors[i].y)
                {
                    tr.localPosition -= tr.up * fSpeed * Time.deltaTime;     //아래로이동
                    yield return null;
                }
            }
            else if (tr.localPosition.y == vectors[i].y)
            {
                yield return null;
            }

            if (tr.localPosition.z < vectors[i].z)
            {
                yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

                while (tr.localPosition.z <= vectors[i].z)
                {
                    tr.localPosition += tr.forward * fSpeed * Time.deltaTime;    // 앞으로 이동
                    yield return null;
                }
            }
            else if(tr.localPosition.z > vectors[i].z)
            {
                yield return new WaitForSeconds(wait); //2.0초간 실행을 보류한다.

                while (tr.localPosition.z >= vectors[i].z)
                {
                    tr.localPosition -= tr.forward * fSpeed * Time.deltaTime;   //뒤로 이동
                    yield return null;
                }
            }
            else if (tr.localPosition.z == vectors[i].z)
            {
                yield return null;
            }

        }

    }
}

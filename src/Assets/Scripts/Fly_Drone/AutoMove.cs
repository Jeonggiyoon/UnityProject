using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {
    private Transform tr;      //오브젝트 포지션값 넣을 변수선언
    // private float fAngleY = 0.0f;  // y높이값
    private float fSpeed = 2.0f;   // 속도값

    // Use this for initialization
    void Start() {
        tr = GetComponent<Transform>();   // 오브젝트의 포지션값을 불러와 tr이란 변수에 넣기 
        StartCoroutine(StartRutine());    // 코루틴 함수 호출
    }

    IEnumerator StartRutine()
    {
        while (tr.position.y <= 10)
        {
            tr.position += tr.up * fSpeed * Time.deltaTime;
            yield return null;
        }

        while (tr.position.x <= 25)
        {
            tr.position += tr.right * fSpeed * Time.deltaTime;
            yield return null;
        }

        while (tr.position.y >= 0)
        {
            tr.position -= tr.up * fSpeed * Time.deltaTime;
            yield return null;
        }


        
        while (tr.position.y <= 10)
        {
            tr.position += tr.up * fSpeed * Time.deltaTime;
            yield return null;
        }

        while (tr.position.x >= 15)
        {
            tr.position -= tr.right * fSpeed * Time.deltaTime;
            yield return null;
        }

        while (tr.position.y >= 0)
        {
            tr.position -= tr.up * fSpeed * Time.deltaTime;
            yield return null;
        }
     

    }

    /*
	// Update is called once per frame
	void Update () {

        if (tr.position.y <= 10)
        {
            /*Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);

            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);
           


            tr.position += tr.up * fSpeed * Time.deltaTime;

        }    

        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);

            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);


            tr.position -= tr.right * fSpeed * Time.deltaTime;

        }
       
        else if (tr.position.x <= 25)
        {
          
            Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);

            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);
           


            tr.position += tr.right * fSpeed * Time.deltaTime;


        }

        else  if (tr.position.y >= 0)
        {
            /*
            Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);

            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);
          

            tr.position -= tr.up * fSpeed * Time.deltaTime;

        }
        */

}

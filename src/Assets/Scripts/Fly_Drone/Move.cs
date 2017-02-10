using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    private Transform tr;    
    private float fAngleY = 0.0f;
    private float fSpeed = 5.0f;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            fAngleY -= 5.0f;
            tr.rotation = Quaternion.Euler(0.0f, fAngleY, 0.0f);
        }


        if (Input.GetKey(KeyCode.D))
        {
            fAngleY += 5.0f;
            tr.rotation = Quaternion.Euler(0.0f, fAngleY, 0.0f);
        }


        if (Input.GetKey(KeyCode.W))
        {
            Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);

            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);


            tr.position += tr.up * fSpeed * Time.deltaTime;

        }


        if (Input.GetKey(KeyCode.S))
        {
            Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);

            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);


            tr.position -= tr.up * fSpeed * Time.deltaTime;

        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);


            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);

            tr.position += tr.forward * fSpeed * Time.deltaTime;

        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 vLookDir = Vector3.zero;
            vLookDir.z = Mathf.Cos(fAngleY * Mathf.PI / 180);
            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);

            Debug.Log(vLookDir);
            tr.position -= vLookDir * fSpeed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);

            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);


            tr.position -= tr.right * fSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 vLookDir = Vector3.zero;//(0.0f, 0.0f, 0.0f)

            vLookDir.z = Mathf.Cos(fAngleY * Mathf.Deg2Rad);

            vLookDir.x = Mathf.Cos((90.0f - fAngleY) * Mathf.Deg2Rad);
            Debug.Log(vLookDir);


            tr.position += tr.right * fSpeed * Time.deltaTime;

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Transform target;
    public Vector3 offset;
    public float smooth_speed = 5f;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // 카메라가 있어야 하는 지점을 계산한다.
        Vector3 camPos = target.position + offset;

        // 부드럽게 움직인다.
        transform.position = Vector3.Lerp
            (transform.position, camPos, 
            smooth_speed * Time.deltaTime);

        //transform.position = camPos;
		
	}
}

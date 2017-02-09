using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour 
{
    // 변수들
    public Vector3 vDirection;
    public float fMoveSpeed = 5f;
    public Rigidbody rigidbody;

	// Use this for initialization
	void Start () 
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        doMove();
        doRotate();
	}

    // Hero 이동관리 method
    public void doMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동 방향 정의
        vDirection.Set(h, 0, v);
        Vector3 vMovement = vDirection * fMoveSpeed * Time.deltaTime;

        //transform.Translate(vDirection * MoveSpeed * Time.deltaTime);
        
        // 해당 하는 물체를 특정 좌표로 이동
        rigidbody.MovePosition(transform.position + vMovement);
    }

    // Hero 회전관리 method
    public void doRotate()
    {
        // 화면에서 빛을 쏜다
        Ray camera_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //빛이 닿는 곳에 대한 정보
        RaycastHit hit;

        //Physic
        //                  빛 정보     충돌저장  광선 길이
        if(Physics.Raycast(camera_ray, out hit, Mathf.Infinity))
        {
            // 바라볼 방향 = 레이저 포인트 위치 - 내 위치
            Vector3 dir = hit.point - transform.position;
            dir.y = 0;
            
            // 방향값 적용
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}

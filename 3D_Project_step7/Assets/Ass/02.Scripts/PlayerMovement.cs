using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    public float fSpeed = 6f;       // 이동속도
    private Vector3 vMovement;      // 이동방향 벡터
    Animator cAnim;                 // 애니메이터 컴포넌트
    Rigidbody cPlayerRigidBody;     // Rigidbody 컴포넌트

    int iFloorMask;                 // 해당 층의 값을 담을 공간
    float fCamRayLength = 100f;     // 광선의 길이
    
    void Awake()
    {
        iFloorMask = LayerMask.GetMask("Floor");
        cAnim = GetComponent<Animator>();
        cPlayerRigidBody = GetComponent<Rigidbody>();
    }

    private void Move(float h, float v)
    {
        vMovement.Set(h, 0f, v);
        vMovement = vMovement.normalized * fSpeed * Time.deltaTime;
        // 이동할 거리 = 방향 * 속도 * 시간
        cPlayerRigidBody.MovePosition(transform.position + vMovement);
    }

    private void Turning()
    {
        // 광선 만들기 (마우스포인터 -> 보이는 화면으로)
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 광선에 맞은 오브젝트의 정보를 담을 공간 선언
        RaycastHit floorHit;

        // 광선 쏘기
        // Physics.Raycast(광선시작지점, 담을공간, 광선최대길이, 충돌할층(Layer)
        if(Physics.Raycast(camRay, out floorHit, fCamRayLength, iFloorMask))
        {
            Vector3 vPlayerToMouse = floorHit.point - transform.position;

            vPlayerToMouse.y = 0f;

            // LookRotation(Vector3); 쳐다보는 방향에따라 회전각을 만들어주는 함수
            Quaternion newRotation = Quaternion.LookRotation(vPlayerToMouse);

            cPlayerRigidBody.MoveRotation(newRotation);
        }
    }

    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        // h, v 둘 중 하나라도 0이 아니면, true 반환

        cAnim.SetBool("IsWalking", walking);
    }

    void FixedUpdate()
    {
        // -1.f ~ 1.0f 서서히 진행됬지만,
        // GetAxisRaw : -1, 0, 1
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 이동
        Move(h, v);

        // 회전
        Turning();

        // 애니메이션 연출
        Animating(h, v);
    }
}

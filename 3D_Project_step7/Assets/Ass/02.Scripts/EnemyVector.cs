using UnityEngine;
using System.Collections;

public class EnemyVector : MonoBehaviour 
{
    public Transform trPlayer;
    public float fSpeed = 2.0f;
	
	// Update is called once per frame
	void Update () 
    {
        // 이동
        // 몬스터가 -> 플레이어를 처다보는 방향의 벡터
        Vector3 vDir = trPlayer.position - transform.position;
        
        // 방향만 얻어오기위해 벡터 정규화
        vDir.Normalize();

                    // 변위 += 방향 * 시간 * 속도
        transform.position += vDir * Time.deltaTime * fSpeed;

        // 회전
        // A Dot B = |A|*|B|*cos(theta)
        // fResult = cos(theta);
        // Theta = acos(fResult);
        float fResult = Vector3.Dot(vDir, Vector3.forward);
        float fTheata = Mathf.Acos(fResult);    // 라디안값 0 ~ 2PI

        float fAngle = Mathf.Rad2Deg * fTheata; // 호도법 0 ~ 360도

        if (transform.position.x > trPlayer.position.x)
            fAngle = 360.0f - fAngle;

        transform.rotation = Quaternion.Euler(0.0f, fAngle, 0.0f);
	}
}

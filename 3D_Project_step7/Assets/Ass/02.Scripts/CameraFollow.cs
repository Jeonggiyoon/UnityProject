using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public Transform target;        // 타겟의 정보
    public float smoothing = 5f;    // 보간치

    Vector3 offset;

	void Start () 
    {
        offset = transform.position - target.position;
	}
	
	void FixedUpdate () 
    {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetCamPos,
            smoothing * Time.deltaTime);
	}
}

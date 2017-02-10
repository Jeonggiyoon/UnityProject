using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform Target;      // 타겟의 정보 
    public float smoothing = 5f;  //보간치

    Vector3 offset;

    void Start()
    {
        offset = transform.position - Target.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCampos = Target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position, 
            targetCampos,
            smoothing * Time.deltaTime);

    }
}

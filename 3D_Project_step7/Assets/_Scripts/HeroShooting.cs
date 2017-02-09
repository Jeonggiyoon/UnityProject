using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShooting : MonoBehaviour 
{
    public Transform FireHole;
    public GameObject bullet_prefab;
    public float fPower = 100f;
    public Light hole_light;

	// Use this for initialization
	void Start () 
    {
        //      transform.FindChild("FireHole");
        //hole_light = GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        doShoot();
	}

    // 총알쏘기 method
    public void doShoot()
    {
        // 마우스 좌클릭시 if문 안으로 진입
        if( Input.GetMouseButtonDown(0) == true )
        {
            // 총알생성
            GameObject bullet = Instantiate(bullet_prefab);

            bullet.transform.position = FireHole.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody>().AddForce
                (transform.forward * fPower);
            LightUp();
        }
    }

    public void LightUp()
    {
        //등록된 작동예정 LightDown 메소드들을 제거
        CancelInvoke("LightDown");

        hole_light.enabled = true;

        // 0.5초뒤 LightDown메소드 실행
        Invoke("LightDown", 0.1f);
    }

    public void LightDown()
    {
        hole_light.enabled = false;
    }
}

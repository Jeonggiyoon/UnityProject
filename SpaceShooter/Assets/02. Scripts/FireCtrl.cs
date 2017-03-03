using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 반드시 필요한 컴포넌트를 명시해 해당 컴포넌트가 삭제되는 것을 방지하는 Attribute
[RequireComponent(typeof(AudioSource))]

public class FireCtrl : MonoBehaviour {

    // 총알 프리팹
    public GameObject bullet;

    // 총알 발사 좌표
    public Transform firePos;

    // 총알 발사 사운드 
    public AudioClip fireSfx;

    // AudioSource 컴포넌트를 추출한 후 변수에 할당
    private AudioSource source = null;

    // MuzzleFlash의 MeshRenderer 컴포넌트 연결 변수
    public MeshRenderer muzzleFlash;

	// Use this for initialization
	void Start () {

        // AudioSource 컴포넌트를 저장할 변수
        source = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        // 마우스 왼쪽 버튼을 클릭했을때 Fire 함수 호출
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }		
	}

    void Fire()
    {
        // 동적으로 총알을 생성하는 함수 
        CreateBullet();
        source.PlayOneShot(fireSfx, 0.9f);
        StartCoroutine(this.ShowMuzzleFlash());
    }

    void CreateBullet()
    {
        // Bullet 프리팹을 동적으로 생성
        Instantiate(bullet, firePos.position, firePos.rotation);
    }

    // MuzzleFlash 활성/ 비활성화를 짧은 시간 동안 반복
    IEnumerator ShowMuzzleFlash()
    {
        // MuzzleFlash 스케일을 불규칙하게 변경
        float scale = Random.Range(1.0f, 2.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale;

        // MuzzleFlash를 z축 기준으로 불규칙하게 회전시킴
        Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
        muzzleFlash.transform.localRotation = rot;

        // 활성화해서 보이게 함
        muzzleFlash.enabled = true;

        // 불규칙적인 시간 동아 Delay한 다음 MeshRenderer를 비활성화
        yield return new WaitForSeconds(Random.Range(0.05f, 0.3f));

        // 비활성화해서 보이지 않게 함
        muzzleFlash.enabled = false;
    }
}

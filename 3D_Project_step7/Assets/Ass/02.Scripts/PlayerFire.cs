using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour 
{
    public int iDamagePerShot = 20;             // 총알 발당 데미지
    public float fTimeBetweenBullets = 0.1f;    // 총알 쏘는 딜레이
    public float fRange = 100f;                 // 총알의 사정거리

    float fTimer;                               // 타이머
    Ray ShootRay;                               // 총알의 광선
    RaycastHit shootHit;                        // 광선과 충돌한 객체의 정보를 담을 공간
    int shootableMask;                          // Layer Mask
    ParticleSystem gunParticles;                // 총알의 파티클
    LineRenderer gunLine;                       // 라인 렌더러
    AudioSource gunAudio;                       // 오디오
    Light gunLight;                             // 불빛을 나타낼 광원
    public Light faceLight;                     // point Light
    float effectsDisplayTime = 0.2f;            // 이펙트 보여줄 시간

    void Awake()
    {
        // Shootable Layer 얻어도기
        shootableMask = LayerMask.GetMask("Shootable");

        // 컴포넌트 할당
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
        gunAudio = GetComponent<AudioSource>();
        gunParticles = GetComponentInChildren<ParticleSystem>();
    }
	
    void Shoot()
    {
        // 타이머 초기화
        fTimer = 0f;

        // 총소리 플레이
        gunAudio.Play();

        // 번쩍임 라이트 표시
        gunLight.enabled = true;
        faceLight.enabled = true;

        // 파티클을 기존에 플레이중이면, 중지하고 다시 시작
        gunParticles.Stop();
        gunParticles.Play();

        // 라인 렌더러 키고, 0인덱스 출발지점을 설정
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        // 쏠 광선의 Origin(시작벡터), direction(방향) 설정
        ShootRay.origin = transform.position;
        ShootRay.direction = transform.forward;

        // 광선 쏘기 -> 충돌 처리
        if (Physics.Raycast(ShootRay, out shootHit, fRange, shootableMask))
        {
            // 적 체력 정보 EnemyHealth 얻어오기
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            // 적이 null이 아니라면
            if(enemyHealth != null)
            {
                // 데미지를 받는다.
                enemyHealth.TakeDamage(iDamagePerShot, shootHit.point);
            }
            

            // shootableMask와 충돌했으면, LineRenderer의 끝을 설정
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            // 궤적의 1인덱스(끝점)을 광선의 최대길이로 설정
            gunLine.SetPosition(1, ShootRay.origin + ShootRay.direction * fRange);
        }
    }

    public void DisableEffects()
    {
        gunLight.enabled = false;
        faceLight.enabled = false;
        gunLine.enabled = false;
    }

	void Update () 
    {
        // 타이머
        fTimer += Time.deltaTime;
	
        // timeScale 0 ~ 1;

        // "Fire1" 키가 눌렀으면서, 시간이 딜레이보다 넘었고, timeScale != 0, 일시정지 아닐때
        if(Input.GetButton("Fire1") && fTimer >= fTimeBetweenBullets && Time.timeScale != 0)
            Shoot();

        // 총알 딜레이 * 이펙트 보여줄시간이 지났으면 효과 꺼버리기
        if(fTimer >= fTimeBetweenBullets * effectsDisplayTime)
            DisableEffects();
	}
}

using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
    public int startingHealth = 100;        // 시작체력
    public int currentHealth;               // 현재체력
    public float sinkSpeed = 2.5f;          // 가라앉는 속도
    public int scoreValue = 10;             // 죽었을때 올릴 점수
    public AudioClip deathClip;             // 죽는소리 음원

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        // 컴포넌트 할당
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        // 현재 체력 할당
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () 
    {
        // 가라앉기 플래그가 true 라면...
        if (isSinking)
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
	}

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        enemyAudio.Play();

        currentHealth -= amount;

        // hitParticles의 위치를 맞은 hitPoint로 배치
        hitParticles.transform.position = hitPoint;

        // 파티클 시스템 플레이 !
        hitParticles.Play();

        // 체력이 0 이하라면..
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        // 죽음 플래그 true
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        // 오디오 클립을 죽는소리로 변경
        enemyAudio.clip = deathClip;

        enemyAudio.Play();
    }

    public void StartSinking()
    {
        // 추적 NavMeshAgent 끄기
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // isKinematic을 체크하면 충돌이나 force의 영향을 받지 않는다.
        GetComponent<Rigidbody>().isKinematic = true;

        // 가라앉기 시작
        isSinking = true;

        // 점수 올리기
        ScoreManager.iScore += scoreValue;

        // 2초 뒤 삭제
        Destroy(gameObject, 2f);
    }
}

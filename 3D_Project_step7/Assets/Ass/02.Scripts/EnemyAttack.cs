using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
    public float timeBetweenAttacks = 0.5f;     // 공격딜레이
    public int attackDamage = 10;               // 공격 데미지

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

	// Use this for initialization
	void Start () 
    {
        // 컴포넌트 할당
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider other)
    {
        // isTrigger가 체크된 Sphere Collider와 충돌되었는게 player라면...
        if (other.gameObject == player)
            playerInRange = true;
    }

    // 탈출(Exit)
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = false;
    }
	// Update is called once per frame
	void Update () 
    {
        // 시간 측정
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks &&
            playerInRange &&
            enemyHealth.currentHealth > 0)
        {
            // 공격 !
            Attack();
        }
	}

    void Attack()
    {
        // 타이머리셋
        timer = 0f;

        // 플레이어가 살아있다면
        if(playerHealth.currentHealth > 0)
        {
            // 데미지를 받는 함수 호출 !
            playerHealth.TakeDamage(attackDamage);
        }

    }

}

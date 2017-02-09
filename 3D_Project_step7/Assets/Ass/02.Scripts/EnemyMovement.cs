using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
    Transform player;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // GameObject.FindGameObjectWithTag(string);
        // 현재 하이어아키뷰에있는 string태그를 가진 객체를 찾아서 GameObject형으로 반환한다.
        // 단점 : 객체가 많아지면 속도가 많이 느려진다.

        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        // 적과 플레이어가 둘다 살아있다면...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            nav.SetDestination(player.position);
        else
            nav.enabled = false;
	}
}

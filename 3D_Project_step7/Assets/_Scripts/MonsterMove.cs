using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour 
{
    public Transform hero;
    public MonsterHealth health;
    public NavMeshAgent nav;

	// Use this for initialization
	void Start () 
    {
        hero = GameObject.FindGameObjectWithTag("Hero").transform;
        health = GetComponent<MonsterHealth>();
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        doMove();
	}

    public void doMove()
    {
        if( health.isDead == true)
        {
            nav.enabled = false;
            return;
        }

        // 목적지를 주인공에게 맞춘다.
        nav.SetDestination(hero.position);

    }
}

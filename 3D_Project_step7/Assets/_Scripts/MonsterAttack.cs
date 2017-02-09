using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour 
{
    public GameObject hero;
    public HeroHealth hero_health;
    public bool isHeroRange = false;
    public float fDelay = 3f;

	// Use this for initialization
	void Start () {
        hero = GameObject.FindGameObjectWithTag("Hero");
        hero_health = hero.GetComponentInChildren<HeroHealth>();
        StartCoroutine("doAttack");
	}

    // 트리거 범위에 들어왔을때
    void OnTriggerEnter(Collider _col)
    {
        // 트리거에 들어온 것이 Hero라는 tag를 가지고 있다면
        if(_col.tag == "Hero")
        {
            isHeroRange = true;
        }
    }

    // 트리거 범위에서 나갔을때
    void OnTriggerExit(Collider _col)
    {
        // 트리거에 나간 것이 Hero라는 tag를 가지고 있다면
        if (_col.tag == "Hero")
        {
            isHeroRange = false;
        }
    }
	
    public IEnumerator doAttack()
    {
        while(true)
        {
            if( isHeroRange == false )
            {
                yield return new WaitForEndOfFrame();
            }
            else
            {
                //공격처리
                hero_health.TakeDamage(1);
                yield return new WaitForSeconds(fDelay);
            }
        }
    }
}

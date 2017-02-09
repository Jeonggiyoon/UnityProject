using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    public int HitPoint = 20;
    public bool isDead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void TakeDamage(int amount)
    {
        HitPoint -= amount;

        if( HitPoint <= 0)
        {
            //사망처리 & Game Over 처리
            isDead = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour 
{
    public ParticleSystem particle;
    public int HitPoint = 20;
    public bool isDead = false;
    public float SinkSpeed = 3f;

	// Use this for initialization
	void Start () 
    {
        particle = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if( isDead == true)
        {
            transform.Translate(Vector3.down * SinkSpeed * Time.deltaTime);
        }
	}

    // rigidbody끼리 충돌시 호출
    void OnCollisionEnter(Collision _col)
    {
        if( _col.collider.tag == "Bullet" )
        {
            TakeDamage( 10, _col.contacts[0].point );
            Destroy(_col.gameObject);
        }
    }

    public void TakeDamage(int amount, Vector3 hit_pos)
    {
        HitPoint -= amount;

        particle.transform.position = hit_pos;
        particle.Play();
        
        if( HitPoint <= 0)
        {
            //추후 사망처리
            isDead = true;
            Destroy(gameObject, 2f);
        }
    }
}

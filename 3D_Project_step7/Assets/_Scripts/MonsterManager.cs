using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour 
{
    public Transform[] point;
    public GameObject[] monster_prefab;
    public float fDelay = 3f;

	// Use this for initialization
	void Start () 
    {
        // CreateMonster 메소드가 코루틴으로 실행된다.
        StartCoroutine("CreateMonster");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public IEnumerator CreateMonster()
    {
        while(true)
        {
            // 0번째로 등록된 몬스터 생성
            GameObject instance = Instantiate(monster_prefab[0]);

            // 0번째로 등록된 위치좌표로 몬스터를 옮긴다.
            instance.transform.position = point[0].position;

            // fDelay만큼 시간이 지난뒤 다시 리턴
            yield return new WaitForSeconds(fDelay);
        }
    }
}

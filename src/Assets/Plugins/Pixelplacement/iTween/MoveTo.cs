using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;


public class MoveTo : MonoBehaviour {
    private Transform tr;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        // iTween.MoveTo(this.gameObject, iTween.Hash("position", new Vector3 (10, 10, 0), "Time", 15.0f, "delay", 0.5f));
        StartCoroutine(StartRutine());
    }
	
	// Update is called once per frame
	void Update () {  
             
    }

    IEnumerator StartRutine()
    {
        while (tr.position.y <= 10)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("y", 10.0f, "Time", 15.0f, "delay", 0.5f));
            yield return null;
        }

        while (tr.position.x <= 25)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("x", 25.0f, "Time", 15.0f, "delay", 0.5f));
            yield return null;
        }

        while (tr.position.y >= 0)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("y", 0.0f, "Time", 15.0f, "delay", 0.5f));
            yield return null;
        }

    }
}

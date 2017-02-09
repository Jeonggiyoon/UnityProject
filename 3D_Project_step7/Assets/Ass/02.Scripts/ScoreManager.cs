using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
    public static int iScore = 0;

    Text cText;

	void Awake()
    {
        cText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        cText.text = "Score : " + iScore;
	}
}

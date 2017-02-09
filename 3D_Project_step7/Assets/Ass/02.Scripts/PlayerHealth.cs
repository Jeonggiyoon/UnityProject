using UnityEngine;
using UnityEngine.UI;               // UI조작을 위해 네임스페이스 추가
using System.Collections;
using UnityEngine.SceneManagement;  // Scene Load를 위해 추가

public class PlayerHealth : MonoBehaviour 
{
    public int startingHealth = 100;
    public int currentHealth;
    public AudioClip deathClip;

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerFire playerShooting;
    bool isDead;
    bool damaged;

    public Slider healthSlider;

    public Image damagedImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    
	// Use this for initialization
	void Start () 
    {
        // 컴포넌트 할당
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerFire>();

        // 체력
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (damaged)
            damagedImage.color = flashColor;
        else
            damagedImage.color = Color.Lerp(damagedImage.color, Color.clear, 
                flashSpeed * Time.deltaTime);

        damaged = false;
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;

        //Debug.Log("HP : " + currentHealth);

        // 슬라이드바 벨류에 체력을 적용
        healthSlider.value = currentHealth;


        playerAudio.Play();

        if(currentHealth <= 0 && !isDead)
        {
            // 플레이어 죽음 !
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;

        Invoke("RestartLevel", 5f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthControl : MonoBehaviour
{

    public int currentHealth;
    public int maximumHealth;

    public PlayerControl player;

    public float invincibilityLength; //time that the player will take before receive more dmg
    [SerializeField] private float invincibilityCounter; //work as a satatus

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnlength;

    public GameObject deathEffect; //hold death effect 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth; //set to max health
       // player = FindObjectOfType<PlayerControl>();

        respawnPoint = player.transform.position; 


    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime; //count down invincibility
            flashCounter -= Time.deltaTime; //count down flash 
            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled; //turn of and on 
                flashCounter = flashLength; //reset 
            }

            if(invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true; //turn on to show player again
            }
        }
        
    }

    public void DamagePlayer(int damage,Vector3 direction) //damage the character
    {

        if (invincibilityCounter <= 0) 
        {
            if ((currentHealth - damage) < 0)
            {
                currentHealth = 0; //cause dmg
            }
            else
            {
                currentHealth -= damage; //cause dmg
            }
            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                invincibilityCounter = invincibilityLength; //reset counter
                playerRenderer.enabled = false; //make player disapear
                flashCounter = flashLength; //reset counter
            }


        }
        FindObjectOfType<PlayerCharacter>().UpDateHealth(currentHealth);

    }

    public void Respawn()
    {
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
        FindObjectOfType<PlayerCharacter>().UpDateHealth(currentHealth);

    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        player.gameObject.SetActive(false); //deactivate player
        Instantiate(deathEffect, player.transform.position, player.transform.rotation); //locate death effect
        yield return new WaitForSeconds(respawnlength);//wait for respawn length time to end
        isRespawning = false;
        player.gameObject.SetActive(true); //reactivate player
        player.transform.position = respawnPoint; //move player to start
        currentHealth = maximumHealth; //remove
        invincibilityCounter = invincibilityLength; //reset counter
        playerRenderer.enabled = false; //make player disapear
        flashCounter = flashLength; //reset counter
    }
    public void UpdateSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }


}

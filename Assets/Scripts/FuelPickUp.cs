using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickUp : MonoBehaviour
{


    public int value = 1;

    public GameObject pickUpEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) // player opject entered the fuel area
    {
        if(other.tag.Equals("Player"))
        {
            FindObjectOfType<PlayerCharacter>().AddFuel(value); //call function add fuel from player character class

            Instantiate(pickUpEffect, transform.position, transform.rotation);

            Destroy(gameObject); //make the fuel cell disapper
        }
    }
}

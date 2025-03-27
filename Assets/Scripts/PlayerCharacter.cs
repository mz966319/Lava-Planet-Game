using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCharacter : MonoBehaviour
{

    public int currentFuel;
    public Text fuelText;
    public int currentHealth;

    public Text healthText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFuel(int fuelToAdd)
    {
        currentFuel += fuelToAdd;
        fuelText.text = "Fuel: " + currentFuel; 
    }
    public void UpDateHealth(int health)
    {
        currentHealth = health;
        healthText.text = "Health: " + currentHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public HealthControl healthControl;
    // Start is called before the first frame update
    void Start()
    {
        healthControl = FindObjectOfType<HealthControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //set check point when player enters
    {
        if (other.tag.Equals("Player"))
        {
            ActivateCheckPoint();
        }
    }
    public void ActivateCheckPoint()
    {
        Vector3 Pointtransform = transform.position;
        Pointtransform.z += 1.2f;//player dont land on the light 
        healthControl.UpdateSpawnPoint(Pointtransform);
        Destroy(gameObject); //remove the point
    }
}

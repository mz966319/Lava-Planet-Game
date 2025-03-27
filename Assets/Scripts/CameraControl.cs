using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour


{   
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] bool useOffsetValues=false;
    [SerializeField] float rotateSpeed = 5;

    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //make mouse cursor disapper
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position; //set player position to pivot position
        pivot.transform.parent = target.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Mouse X") * rotateSpeed; // x pos of the mouse
        target.Rotate(0f, horizontalInput, 0f); //rotate player right and left using mouse

        float verticalInput = Input.GetAxis("Mouse Y") * rotateSpeed; //y pos of the mouse
        pivot.Rotate(-verticalInput, 0f, 0f); // rotate the pivot


        //limit up/down rotaition
        if(pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f) //up
        {
            pivot.rotation = Quaternion.Euler(45f, 0f, 0f);//float max ViewAngle = 45f
        }
        if(pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 340f) //up (360f-minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(340f, 0f, 0f);//float min ViewAngle = 315f
        }

        //make camera sinc with rotation 
        Quaternion rotation = Quaternion.Euler(pivot.eulerAngles.x, target.eulerAngles.y, 0f);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-5f, transform.position.z);
        }
        
        transform.LookAt(target);
        
    }
}

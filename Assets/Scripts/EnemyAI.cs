using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float walkLength = -10f;

    [SerializeField] float walkCounter=10f;


    public Rigidbody rigidbody;

    private Vector3 enemyPosition;
    private bool isMoving;
    [SerializeField] GameObject enemy;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        enemyPosition = transform.position;
        enemy.GetComponent<Animation>().Play("threaten");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateEnemy()
    {
        StartCoroutine("MoveEnemyCo");
        enemy.GetComponent<Animation>().Play("attackrun");
    }

    public void MoveEnemy() //move the enemy
    {
        if (!isMoving)
        {
            StartCoroutine("MoveEnemyCo");
        }
    }
    public IEnumerator MoveEnemyCo()

    {
        isMoving = true;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y,walkLength * movementSpeed * Time.deltaTime);
        yield return new WaitForSeconds(walkCounter);//wait for  walk time to end
        isMoving = false;

    }
}

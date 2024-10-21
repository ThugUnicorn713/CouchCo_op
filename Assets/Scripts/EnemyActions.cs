using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using System.Collections;
using System.Collections.Generic;

public class EnemyActions : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player1;
    public GameObject player2;

    [SerializeField] public float speed = 5f;
    [SerializeField] public float detectionRadius = 8f;
    
    private static EnemyActions Instance;

    public static EnemyActions GetInstance()
    {
        return Instance;
    }

    void Start()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        transform.position = rb.transform.position;
        transform.rotation = rb.transform.rotation;

    }
    void Update()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        if (rb != null && player1 != null)
        {

            MoveTowardsPlayer();

        }
        
    }

    public void MoveTowardsPlayer()
    {
        float distancetoPlayer1 = Vector2.Distance(transform.position, player1.transform.position); //modified to find the closer player then follow them
        float distancetoPlayer2 = Vector2.Distance(transform.position, player2.transform.position);

        if(distancetoPlayer1 < detectionRadius ||  distancetoPlayer2 < detectionRadius)
        {
            if (distancetoPlayer1 < distancetoPlayer2)
            {
                transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player2.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            speed = 0f;
        }




        /*  ~ORIGINAL MOVEMENT SCRIPT FOR REF~
         * 
         * 
         if (Vector2.Distance(transform.position, player1.transform.position ) < detectionRadius)  
         {
             transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, speed * Time.deltaTime);
         }
         else if (Vector2.Distance(transform.position, player2.transform.position) < detectionRadius)
         {
             transform.position = Vector2.MoveTowards(transform.position, player2.transform.position, speed * Time.deltaTime);
         }
         else
         {
             speed = 0f;
         }*/
    }

    public void EnemyFreeze()
    {
        //Debug.Log("Enemy is frozen");
        speed = 0f;
    }

    public void EnemyUnfreeze()
    {
        //Debug.Log("Enemy is unfrozen");
        speed = 1f;
    }

   /* public void GameOver()
    {
        if ()
        {
            
        }
    } */
}

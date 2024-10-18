using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TorchActions : MonoBehaviour
{
    [SerializeField] float lightDistance = 5f;
    [SerializeField] float lightRadius = 10f; //front radius?
    //public GameObject torch;
    public PlayerActions isFlashLightTurnedOn;
   [SerializeField] private GameObject instance; 


    //public GameObject player1;
    // public GameObject player2;
    //enemy move script here
    //enemy collider



    void Start()
    {
        PlayerActions playerActions = instance.GetComponent<PlayerActions>();

        isFlashLightTurnedOn = playerActions.GetComponent<PlayerActions>(); 
        //get enemy collider
    }

   
    void Update()
    {
       // if (//enemy's collider is within radius )
        //{
            if (isFlashLightTurnedOn.GetComponent<PlayerActions>().isFlashLightTurnedOn == true)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), lightDistance);

                if (hit)
                {
                    Debug.Log("You hit: " + hit.collider.name);
                    //call enemy freeze method
                }

            }
       // }

        
    }
}

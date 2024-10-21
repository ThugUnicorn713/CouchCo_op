using System;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchActions : MonoBehaviour
{
    [SerializeField] float lightDistance = 5f;
    //[SerializeField] float lightRadius = 10f; //front radius?
    
    public PlayerActions isFlashLightTurnedOn;
    
   
    [SerializeField] private GameObject instance;
    


    void Start()
    {
        PlayerActions playerActions = instance.GetComponent<PlayerActions>();
        isFlashLightTurnedOn = playerActions.GetComponent<PlayerActions>();

    }   

    void Update()
    {

        if (isFlashLightTurnedOn.GetComponent<PlayerActions>().isFlashLightTurnedOn == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), lightDistance);

            if (hit && hit.collider.CompareTag("Enemy"))
            {
                EnemyActions.GetInstance().EnemyFreeze();
                Debug.Log("PLAYER 1 hit: " + hit.collider.name);

            }
            else
            {
                EnemyActions.GetInstance().EnemyUnfreeze();
            }
        }
        else
        {
            EnemyActions.GetInstance().EnemyUnfreeze();
        }


    }

        
}

using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;

public class TorchActions2 : MonoBehaviour
{
    [SerializeField] float lightDistance = 5f;
    //[SerializeField] float lightRadius = 10f; //front radius?

    public PlayerActions2 isFlashLightTurnedOn;


    [SerializeField] private GameObject instance;



    void Start()
    {
        PlayerActions2 playerActions = instance.GetComponent<PlayerActions2>();
        isFlashLightTurnedOn = playerActions.GetComponent<PlayerActions2>();

    }

    void Update()
    {

        if (isFlashLightTurnedOn.GetComponent<PlayerActions2>().isFlashLightTurnedOn == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), lightDistance);

            if (hit && hit.collider.CompareTag("Enemy"))
            {
                EnemyActions.GetInstance().EnemyFreeze();
                Debug.Log("PLAYER 2 HIT ENEMY");

            }
            //took unfreeze method off of here cause system will overwrite freeze method on player 1 otherwise
        }  


    }


}

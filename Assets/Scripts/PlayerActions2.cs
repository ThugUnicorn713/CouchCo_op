using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using System;

public class PlayerActions2 : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] public bool isFlashLightTurnedOn = false;

    public static PlayerActions2 instance;

    Vector2 moveValue;
    Vector2 turnValue;
    //float turnSpeedValue;


    void Start()
    {
        instance = this;
    }

    public static PlayerActions2 GetInstance()
    {
        return instance;

    }
    void Update()
    {
        transform.Translate(transform.InverseTransformDirection(moveValue)); // player comfortablitiy when rotating 
        transform.right = turnValue; //smooth rotation 
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>() * Time.deltaTime * speed;

    }

    public void Rotate(InputAction.CallbackContext context)
    {
        turnValue = context.ReadValue<Vector2>();
        //turnSpeedValue = context.ReadValue<float>() *Time.deltaTime * turnSpeed;
    }

    public void FlashLightON2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player 2 pressed the torch button");
            if (isFlashLightTurnedOn)
            {
                isFlashLightTurnedOn = false;
            }
            else
            {
                isFlashLightTurnedOn = true;
            }


        }

    }
}

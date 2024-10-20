using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
using static UnityEditor.Experimental.GraphView.GraphView;
public class PlayerActions : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] public bool isFlashLightTurnedOn = false;

    public static PlayerActions Instance { get; private set; }

    Vector2 moveValue;
    Vector2 turnValue;
    //float turnSpeedValue; 
        

    void Start()
    {
        Instance = this;

        
    }

    public static PlayerActions GetInstance()
    {
        return Instance;

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

    public void FlashLightON(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
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

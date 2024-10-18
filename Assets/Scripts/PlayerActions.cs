using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;
public class PlayerActions : MonoBehaviour
{

    [SerializeField] float speed = 6f;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] bool interact = false;
    [SerializeField] public bool isFlashLightTurnedOn = false;

    [SerializeField] GameObject flashLight;

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

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.InverseTransformDirection(moveValue)); // player comfortablitiy when rotating 
        transform.right = turnValue; //rotation 
        

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

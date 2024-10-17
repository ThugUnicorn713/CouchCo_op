using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerActions : MonoBehaviour
{

    [SerializeField] float speed = 6f;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] bool interact = false;
    [SerializeField] bool isFlashLightTurnedOn = false;

    [SerializeField] GameObject flashLight;

    Vector2 moveValue;
    Vector2 turnValue;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.InverseTransformDirection(moveValue)); // player comfortable moving up and down in the direction of rotation
        transform.right = turnValue; //rotation 


    }

    public void Move(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>() * Time.deltaTime * speed;

    }

    public void Rotate(InputAction.CallbackContext context)
    {
        turnValue = context.ReadValue<Vector2>();
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
                Debug.Log("TRUE");
            }

            Debug.Log("button is pressed");
        }

    }
}

using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerActions : MonoBehaviour
{

    [SerializeField] float speed = 6f;
    [SerializeField] bool interact = false;
    [SerializeField] bool isFlashLightTurnedOn = false;

    [SerializeField] GameObject flashLight;

    Vector2 moveValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveValue);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>()*Time.deltaTime*speed;
    }
}

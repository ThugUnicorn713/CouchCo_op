using UnityEngine;

public class Button3 : MonoBehaviour
{
    public GameObject thisButton;
    public GameObject exitDoor;


    void Start()
    {
        thisButton = GameObject.FindGameObjectWithTag("Button3");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            thisButton.SetActive(false);
            exitDoor.SetActive(false);
        }
    }

}

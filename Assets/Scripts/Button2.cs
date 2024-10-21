using UnityEngine;

public class Button2 : MonoBehaviour
{
    public GameObject thisButton;
    public GameObject button3;


    void Start()
    {
        thisButton = GameObject.FindGameObjectWithTag("Button2");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            thisButton.SetActive(false);
            button3.SetActive(true);
        }
    }
}

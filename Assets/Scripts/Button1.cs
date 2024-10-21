using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static UnityEditor.Experimental.GraphView.GraphView;


public class Button1 : MonoBehaviour
{
    public GameObject thisButton;
    public GameObject button2;


    void Start()
    {
        thisButton = GameObject.FindGameObjectWithTag("Button");
        

        if (thisButton == null)
        {
            Debug.LogError("thisButton is null! Make sure it has the 'Button' tag.");
        }

        if (button2 == null)
        {
            Debug.LogError("button2 is null! Make sure it has the 'Button2' tag.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the trigger: " + other.name);

        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            Debug.Log("Player has touched me");
            thisButton.SetActive(false);
            button2.SetActive(true);
        }
    }
}

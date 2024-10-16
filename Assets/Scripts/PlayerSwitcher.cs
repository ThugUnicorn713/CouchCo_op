using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerSwitcher : MonoBehaviour
{
        
    int index = 0;
    [SerializeField]  List<GameObject> players = new List<GameObject>(); // make sure you are "using System.Collections.Generic" for lists I guess...


    PlayerInputManager inputManager;

    private void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
        index = Random.Range(0, players.Count); 
        inputManager.playerPrefab = players[index];
    }

    public void SpawnNextPlayerPrefab(PlayerInput input)
    {
        index = Random.Range(0, players.Count);
        inputManager.playerPrefab = players[index];
    }
}

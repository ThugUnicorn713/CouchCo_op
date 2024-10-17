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
        index = 0;
        inputManager.playerPrefab = players[index];
    }

    public void SpawnNextPlayerPrefab(PlayerInput input)
    {
        index = 1;
        inputManager.playerPrefab = players[index];
    }
}

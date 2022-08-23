using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private PlayerController player1_controller,player2_controller; //TODO : Instantiate player prefabs and assign to these variables

    private void Start() {
        player1_controller.SetPlayerTurn(PlayerTurn.PLAYER_1);
        player2_controller.SetPlayerTurn(PlayerTurn.PLAYER_2);
    }

    public void renderLevel(){

    }

    public Transform getPlayer1Transform() {
        return player1_controller.transform;
    }
    public Transform getPlayer2Transform() {
        return player2_controller.transform;
    }
}

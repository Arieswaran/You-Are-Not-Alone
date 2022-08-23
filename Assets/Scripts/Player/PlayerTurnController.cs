using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnController : MonoBehaviour
{
    //create instance
    public static PlayerTurnController instance;
    public PlayerTurn currentTurn;
    public GameObject player1_vcam,player2_vcam;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Debug.LogError("More than one PlayerTurnController in scene");
        }
    }

    public PlayerTurn getCurrentTurn() {
        return currentTurn;
    }

    public void switchPlayerTurn() {
        if (currentTurn == PlayerTurn.PLAYER_1) {
            currentTurn = PlayerTurn.PLAYER_2;
            setPlayer1CameraActive(false);
        } else {
            currentTurn = PlayerTurn.PLAYER_1;
            setPlayer1CameraActive(true);
        }
    }

    private void setPlayer1CameraActive(bool active) {
        player1_vcam.SetActive(active);
        player2_vcam.SetActive(!active);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            switchPlayerTurn();
        }
    }
}

public enum PlayerTurn
{
    PLAYER_1,
    PLAYER_2
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerTurnController : MonoBehaviour
{
    //create instance
    public static PlayerTurnController instance;
    public PlayerTurn currentTurn;
    public CinemachineVirtualCamera player1_vcam,player2_vcam;

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

    public void setPlayer1CameraActive(bool active) {
        player1_vcam.gameObject.SetActive(active);
        player2_vcam.gameObject.SetActive(!active);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            switchPlayerTurn();
        }
    }

    public void setPlayer1VCam(Transform followTarget) {
        player1_vcam.Follow = followTarget;
    }

    public void setPlayer2VCam(Transform followTarget) {
        player2_vcam.Follow = followTarget;
    }
    
}

public enum PlayerTurn
{
    PLAYER_1,
    PLAYER_2
}

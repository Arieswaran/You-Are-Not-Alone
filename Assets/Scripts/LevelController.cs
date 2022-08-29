using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private PlayerController player1_controller,player2_controller; //TODO : Instantiate player prefabs and assign to these variables
    [SerializeField] private float close_distance_to_win = 0.5f;

    private bool user_won = false;

    private void Start() {
        player1_controller.SetPlayerTurn(PlayerTurn.PLAYER_1);
        player2_controller.SetPlayerTurn(PlayerTurn.PLAYER_2);
    }

    private void Update() {
        if(getDistanceBetweenPlayers() < close_distance_to_win && !user_won){
            Debug.Log("User wins");
            user_won = true;
            OnUserWon();
        }
    }

    private void OnUserWon(){
        GameManager.instance.IncrementPlayerLevel();
        GameManager.instance.RestartLevel();
    }

    public void renderLevel(){

    }

    public Transform getPlayer1Transform() {
        return player1_controller.transform;
    }
    public Transform getPlayer2Transform() {
        return player2_controller.transform;
    }

    //calculate distance between two players
    public float getDistanceBetweenPlayers(){
        return Vector3.Distance(player1_controller.transform.position,player2_controller.transform.position);
    }
}

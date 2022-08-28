using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private PlayerTurnController playerTurnController;
    private LevelController levelController;
    [SerializeField] private GameObject levelPrefab; //we will use list of level prefabs to create levels, single prefab will be used for now
    [SerializeField] private List<GameObject> levelPrefabs; //list of level prefabs to create levels
    [SerializeField] private Transform levelParent; //parent transform for all levels
    [SerializeField] private GameObject StartMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one GameManager in scene");
        }
    }

    // private void Start()
    // {
    //     StartLevel();
    // }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    public void OnStartButtonClicked()
    {
        StartLevel();
    }

    public void StartLevel(){
        int level = GetPlayerLevel();
        if(level > levelPrefabs.Count){
            Debug.LogError("No level prefab found for level " + level);
            level = levelPrefabs.Count - 1;
        }
        levelPrefab = levelPrefabs[level];
        levelController = Instantiate(levelPrefab,levelParent).GetComponent<LevelController>();
        levelController.renderLevel();
        PlayerTurnController.instance.setPlayer1VCam(levelController.getPlayer1Transform());
        PlayerTurnController.instance.setPlayer2VCam(levelController.getPlayer2Transform());
        StartMenu.SetActive(false);
        PlayerTurnController.instance.setPlayer1CameraActive(true);
    }

    public void EndLevel(){
        Destroy(levelController.gameObject);
    }

    public void RestartLevel(){
        Destroy(levelController.gameObject);
        StartLevel();
    }

    public int GetPlayerLevel(){
        return PlayerPrefs.GetInt("level",1);
    }

    public void SetPlayerLevel(int level){
        PlayerPrefs.SetInt("level",level);
    }

    public void IncrementPlayerLevel(){
        SetPlayerLevel(GetPlayerLevel()+1);
    }

    

}

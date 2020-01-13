using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private GameManager gameManager;

	public Button respawn;
	public Button restart;
	public Button mainMenu;

    // Start is called before the first frame update
    void Start()
    {
    	gameManager = GameObject.FindObjectOfType<GameManager>();

        respawn.onClick.AddListener(RespawnGame);
        restart.onClick.AddListener(RestartGame);
        mainMenu.onClick.AddListener(GoMainMenu);
    }

    void RespawnGame(){
    	gameObject.SetActive(false);
    	gameManager.Respawn();
    }

    void RestartGame(){
    	Time.timeScale = 1;
    	SceneManager.LoadScene("Levels");
    }

    void GoMainMenu(){
    	Time.timeScale = 1;
    	SceneManager.LoadScene("MainMenu");
    }
}

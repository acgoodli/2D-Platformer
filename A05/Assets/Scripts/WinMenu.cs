using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
	private GameManager gameManager;

	public Button restart;
	public Button mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        restart.onClick.AddListener(RestartGame);
        mainMenu.onClick.AddListener(GoMainMenu);
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

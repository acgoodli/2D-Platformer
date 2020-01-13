using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject character;
	public Text scoreText;
	public Text stageCountText;
    public Text finalScoreText;

	public GameObject pauseMenu;
	public GameObject deathMenu;
    public GameObject winMenu;


	private Vector2 startPosition;
	private Vector2 resetPosition;
	private float score;
	private float stageCount;

	private bool paused;

    // Start is called before the first frame update
    void Start()
    {
    	score = 0;
    	stageCount = 1;
    	paused = false;
        startPosition = new Vector3(-7f, -3.39f);
        resetPosition = startPosition;
        
        character.GetComponent<Transform>().position = startPosition;
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        stageCountText.text = "Stage " + stageCount;

        if(Input.GetButton("Cancel") && !paused)
        	Pause();
    }

    public void UpdateScore(float addScore)
    {
    	score += addScore;
    }

    public void TeleportPlayer(Vector2 location)
    {
    	stageCount ++;
    	resetPosition = location;
    	character.GetComponent<Transform>().position = resetPosition;
    }

    void Pause()
    {
    	pauseMenu.SetActive(true);
    	paused = true;

    	Time.timeScale = 0;
    }

    public void UnPause()
    {
    	paused = false;
    	Time.timeScale = 1;
    }

    public void Respawn()
    {
    	character.GetComponent<Transform>().position = resetPosition;
    	character.GetComponent<Animator>().SetBool("Death",false);
    	UnPause();
    }

    public void Hop(float hopForce)
    {
        character.GetComponent<Rigidbody2D>().velocity = new Vector2(character.GetComponent<Rigidbody2D>().velocity.x, hopForce);
        character.GetComponent<Animator>().SetBool("Jump",true);
    }

    public void Death()
    {
    	score -= 10;
    	if(score < 0)
    		score = 0;

    	character.GetComponent<Animator>().SetBool("Death",true);
    	deathMenu.SetActive(true);
    	paused = true;

    	Time.timeScale = 0;
    }

    public void Win()
    {
        winMenu.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
        Time.timeScale = 0;
    }
}

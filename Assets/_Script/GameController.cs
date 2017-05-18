using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public float spawnWait;
	public int hazardCount;
	public float startWait = 1.0f;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start(){
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
		gameOverText.text = "";
		gameOver = false;
		restartText.text = "";
		restart = false;
	}
	void Update()
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R))
				Application.LoadLevel (Application.loadedLevel);
		}
	}
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			if (gameOver) 
			{
				restartText.text = "按【R】键重新开始";
				restart = true;
				break;
			}
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard=hazards[Random.Range(0,hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "得分:" + score;
	}

	public void GameOver()
	{
		gameOver = true;
		gameOverText.text = "游戏结束";
	}

}

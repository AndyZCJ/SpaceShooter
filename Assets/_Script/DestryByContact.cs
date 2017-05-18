using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent <GameController> ();
		else
			Debug.Log ("找不到tag为GameController的对象");
		if(gameController==null)
			Debug.Log ("找不到脚本GameController.cs");
        
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary"||other.tag == "Enemy")
			return;
		
		print (other.name);
		if (explosion != null) 
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player") 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}

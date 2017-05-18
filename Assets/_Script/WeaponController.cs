using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float delay;
	public float fireRate;


	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("Fire", delay, fireRate);
	}
	
	void Fire(){
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
	public GameObject obstacle1;
	public GameObject obstacle2;
	private int genCount = 0;
	public static bool GameStarted = false;
	public static int PlayerCount = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerCount == 2)
			GameStarted = true;
		if (genCount < 2 && GameStarted == true) {
			Vector3 location1 = new Vector3 (Random.Range (-3.5f, 3.5f), -2, 5);
			Vector3 location2 = new Vector3 (Random.Range (-3.5f, 3.5f), -1.5f, 5);
			Instantiate (obstacle1, location1, Quaternion.identity);
			Instantiate (obstacle2, location2, Quaternion.identity);
			genCount = genCount + 2;
		}
		else if (genCount == 2){
			genCount = 3;
			StartCoroutine (genBreak ());
		}
	}
	IEnumerator genBreak (){
		yield return new WaitForSeconds (2);
		genCount = 0;
	}
}

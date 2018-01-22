using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {
	public float speed;
	public GameObject o1;
	public GameObject o2;
	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,-speed);

	}
	
	// Update is called once per frame
	void Update () {
		Physics.IgnoreCollision (this.gameObject.GetComponent<Collider> (), o1.GetComponent<Collider> ());
		Physics.IgnoreCollision (this.gameObject.GetComponent<Collider> (), o2.GetComponent<Collider> ());
	}
}

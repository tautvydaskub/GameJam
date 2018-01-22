using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	private bool grounded;

	void Update()
	{
		if (isLocalPlayer)
		{				
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;		
		transform.Translate(x, 0, z);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//Fire();
				if (grounded) {
					this.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 5, 0);
				}
		}

		}

	}
	void OnCollisionEnter(Collision obstacle){
		if(obstacle.gameObject.tag == "Ground"){
			grounded = true;
		}
	}
	void OnCollisionExit(Collision obstacle){
		if(obstacle.gameObject.tag == "Ground"){
			grounded = false;
		}
	}
	void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);        
	}
	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
}

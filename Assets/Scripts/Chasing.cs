using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour {

	//The target player
	public Transform player;
	public int damage = 1;


	//At what distance will the enemy walk towards the player?
	public float walkingDistance = 10.0f;
	public float damageDistance = 1.0f;

	//In what time will the enemy complete the journey between its position and the players position
	public float smoothTime = 3.0f;

	//Vector3 used to store the velocity of the enemy
	private Vector3 smoothVelocity = Vector3.zero;

	//private bool _alive;
	public float speed = 3.0f;
	public float obstacleRange = 2.0f;

	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;

	void Start() {
		//_alive = true;
	}

	void Update()
	{
		//Look at the player
		transform.LookAt(player);

		//Calculate distance between player
		float distance = Vector3.Distance(transform.position, player.position);

		//If the distance is smaller than the walkingDistance
		if (distance < walkingDistance) {
			//Move the enemy towards the player with smoothdamp
			transform.position = Vector3.SmoothDamp (transform.position, player.position, ref smoothVelocity, smoothTime);
		} 
	}

	void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		//if (player != null) {
		player.Hurt(damage);
		//}
	}

}
using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
	public float healthBarLengh;
	public int maxHealth = 100;
	public int curHealth = 100;
	public int damage = 1;
	private bool playerDead = false;

	void Start() {
		_health = 1;
		healthBarLengh =  Screen.width / 2;
	}

	public void Hurt(int damage) {
		curHealth -= damage;
		Debug.Log("Health: " + _health);
	}

	void Update() {

		AddjustCurrentHealth(0);


	}

	private void OnGUI() {
		GUI.Box(new Rect(10, 40, healthBarLengh, 20), curHealth + "/" + maxHealth);

		if (playerDead == true) {
			GUI.Box(new Rect(360, 200, 100, 20), "Game Over");

			GUI.Box(new Rect(300, 240, 200, 20), "Press [R] to restart level");
		}
	}


	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;

		if(curHealth <= 0) {
			KillPlayer();
		}
		if(curHealth > maxHealth)
			curHealth = maxHealth;

		if(maxHealth < 1)
			maxHealth = 1;

		healthBarLengh = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}

	public void KillPlayer() {

		Time.timeScale = 0.0f;
		playerDead = true;

	}



	public void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag == "Chasing Enemy")
		{
				AddjustCurrentHealth(-1);
		}
	}


		
}

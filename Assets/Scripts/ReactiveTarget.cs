using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
	int counter = 0;
	public float healthBarLengh;
	void Start() {
		healthBarLengh =  Screen.width / 2;
	}
	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		StartCoroutine(Die());
	}

	private IEnumerator Die() {
		SceneController behavior = GetComponent<SceneController>();


		this.transform.Rotate(-75, 0, 0);

		yield return new WaitForSeconds(0.2f);
		
		Destroy(this.gameObject);
		behavior.enemyCount--;
		counter = counter + 1;
		GUI.Box (new Rect (10, 40, healthBarLengh, 20), "Count:" + counter);
	}


}

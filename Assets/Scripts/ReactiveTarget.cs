using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

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
	}
}

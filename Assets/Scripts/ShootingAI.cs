using UnityEngine;
using System.Collections;

public class ShootingAI : MonoBehaviour {
	
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;
	
	private bool _alive;
	
	void Start() {
		_alive = true;
	}
	
	void Update() {
		
			
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast(ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			if (hitObject.GetComponent<PlayerCharacter>()) {
					if (_fireball == null) {
						_fireball = Instantiate(fireballPrefab) as GameObject;
						_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
						_fireball.transform.rotation = transform.rotation;
					}
			}
		}
	}
				
				
			

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}

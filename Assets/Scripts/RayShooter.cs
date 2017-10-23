using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	public GameObject pistol;
	public GameObject rifle;
	[SerializeField] private GameObject bulletPrefab;
	public float obstacleRange = 5.0f;
	private GameObject _bullet;

	void Start() {
		_camera = GetComponent<Camera>();

//		Cursor.lockState = CursorLockMode.Locked;
//		Cursor.visible = false;
	}

//	void OnGUI() {
//		int size = 40;
//		float posX = _camera.pixelWidth/2 - size/4;
//		float posY = _camera.pixelHeight/2 - size/2;
//		GUI.Label(new Rect(posX, posY, size, size), "");
//	}

	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
				} else {
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
			GameObject weapon = GameObject.Find ("gun2");
			if (weapon == true){
				Debug.Log("Bullet Change");
				if (Physics.Raycast(ray, out hit)) {

					GameObject hitsObject = hit.transform.gameObject;
					ReactiveTarget target = hitsObject.GetComponent<ReactiveTarget>();
					if (target != null) {
						target.ReactToHit();
					}
					else{
						StartCoroutine (BulletIndicator (hit.point));
					}
				}

			}

		}
		if(Input.GetKeyDown(KeyCode.R))
			Application.LoadLevel(0);
	}

//	void Update() {
//		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
//			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
//			Ray ray = _camera.ScreenPointToRay(point);
//			RaycastHit hit;
//			if (Physics.Raycast(ray, out hit)) {
//				GameObject hitObject = hit.transform.gameObject;
//				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
//				if (target != null) {
//					target.ReactToHit();
//				} else {
//					StartCoroutine(SphereIndicator(hit.point));
//				}
//			}
//		}
//
//		if(Input.GetKeyDown(KeyCode.R))
//			Application.LoadLevel(0);
//			
//	}
//
	private IEnumerator SphereIndicator(Vector3 pos) {


		pistol = GameObject.Find ("gun1");
		rifle = GameObject.Find ("gun2");

		if (pistol.activeInHierarchy == true) {
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere.transform.position = pos;

			yield return new WaitForSeconds (1);

			Destroy (sphere);
		} 
		else if (rifle.activeInHierarchy == true) {
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = pos;

			yield return new WaitForSeconds(1);

			Destroy(cube);
		}


	}

	private IEnumerator CubeIndicator(Vector3 pos) {

		//if (GameObject.Find("gun1").SetActive(true) 
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = pos;
		//sphere.transform.localScale = Vector3(0.1, 0.1, 0.1);

		yield return new WaitForSeconds(1);

		Destroy(cube);

	}
	private IEnumerator BulletIndicator(Vector3 pos) {
		bulletPrefab = GameObject.FindGameObjectWithTag ("bullet");
		bulletPrefab = Instantiate(bulletPrefab) as GameObject;
		// sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		bulletPrefab.transform.position = pos;
		yield return new WaitForSeconds(1);

		Destroy(bulletPrefab);

	}
}
using UnityEngine;
using System.Collections;

public class SpawnCheck : MonoBehaviour {

	public GameObject checkObject;

	public bool canSpawnCheck = true;

	public GameObject spawnedObject;
	// Use this for initialization
	void Start () {
		Debug.Log("Into spawn check");
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Enter trigger collision");
		canSpawnCheck = false;

		if (other.gameObject.tag == "Target") {
			Debug.Log ("Found Target");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log("Exit trigger collision");
		canSpawnCheck = true;
	}
		
	// Update is called once per frame
	void Update () {

		if (canSpawnCheck == true) {

			Vector3 currentPosition = this.gameObject.transform.position;
			spawnedObject = (GameObject) Instantiate (checkObject, currentPosition, Quaternion.identity);

			this.gameObject.GetComponentInParent<AILerp> ().possibleTargets.Add (spawnedObject);
		}
	
	}
}

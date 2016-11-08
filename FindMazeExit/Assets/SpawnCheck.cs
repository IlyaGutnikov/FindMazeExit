using UnityEngine;
using System.Collections;
using System;

public class SpawnCheck : MonoBehaviour {

	public GameObject checkObject;

	public bool canSpawnCheck = true;
	Vector2 boxSize;

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

		if (other.gameObject.tag == "Wall") {
			canSpawnCheck = false;
		}

		if (other.gameObject.tag == "Check") {
			canSpawnCheck = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log("Exit trigger collision");
		canSpawnCheck = true;
	}
		
	// Update is called once per frame
	void Update () {

		Debug.Log ("canSpawnCheck " + canSpawnCheck);

		if (canSpawnCheck == true) {

			Vector3 currentPosition = this.gameObject.transform.position;
			Vector3 spawnPos = new Vector3 (Mathf.Round (currentPosition.x), Mathf.Round (currentPosition.y),0);

			Debug.Log ("Physics.CheckSphere " + Physics.CheckSphere (spawnPos, 10));

			if (!Physics.CheckSphere(spawnPos,10)) {

				spawnedObject = (GameObject)Instantiate (checkObject, spawnPos, Quaternion.identity);

				this.gameObject.GetComponentInParent<AILerp> ().possibleTargets.Add (spawnedObject);
			}
		}
	
	}
}

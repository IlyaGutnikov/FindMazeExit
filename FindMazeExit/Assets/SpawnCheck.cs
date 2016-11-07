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
	
		boxSize = checkObject.transform.localScale;
		Debug.Log ("BoxSize " + boxSize);
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
	void FixedUpdate () {

		if (canSpawnCheck == true) {

			Vector2 currentPosition = this.gameObject.transform.position;
			Vector3 parentPosition = this.gameObject.transform.parent.transform.position;
			Collider2D[] coll2d = null;
			coll2d = Physics2D.OverlapBoxAll (currentPosition, boxSize, 0,10);

			Debug.Log ("coll2d.Length " + coll2d.Length);

			if (coll2d.Length == 0) {
				spawnedObject = (GameObject)Instantiate (checkObject, currentPosition, Quaternion.identity);

				this.gameObject.GetComponentInParent<AILerp> ().possibleTargets.Add (spawnedObject);
			}
		}
	
	}
}

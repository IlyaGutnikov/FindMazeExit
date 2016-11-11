using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("CanGo");
		int exit = (int)Mathf.Round (Random.Range (0, gameObjects.Length));
		gameObjects [exit].GetComponent<CheckScript> ().isExit = true;
		gameObjects [exit].GetComponent<SpriteRenderer> ().enabled = true;
	}
}

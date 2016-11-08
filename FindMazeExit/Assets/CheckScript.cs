using UnityEngine;
using System.Collections;

public class CheckScript : MonoBehaviour {

	public bool isCheckPosition = false;
	public bool isExit = false;

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag.Equals ("Sensor") && isExit == true) {

			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.cyan;

			Time.timeScale = 0;

			GameObject.FindGameObjectWithTag ("AI").gameObject.GetComponent<AILerp> ().target = this.gameObject.transform;

			GameObject.FindGameObjectWithTag("AI").gameObject.GetComponent<AILerp> ().exitFound = true;
			GameObject.FindGameObjectWithTag("AI").gameObject.GetComponent<AILerp> ().possibleTargets.Clear ();
		}
	
	}
}

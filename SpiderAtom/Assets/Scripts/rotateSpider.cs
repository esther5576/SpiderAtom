using UnityEngine;
using System.Collections;

public class rotateSpider : MonoBehaviour
{
	#region TEST PART
	/*public float smooth = 2.0F;
	public float tiltAngle = 90.0F;
	void Update ()
	{
		float tiltAroundZ = Input.GetAxis ("Horizontal") * tiltAngle;
		Quaternion target = Quaternion.Euler (0, 0, tiltAroundZ);
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKeyDown ("q")) {
			//transform.rotation = 
			//transform.Rotate (0, 0, 90);
			//transform.rotation = Quaternion.Slerp (transform.rotation, new Quaternion (0, 0, 90), Time.deltaTime * 1);
		}

	}*/
	#endregion

	bool one_click = false;
	bool timer_running;
	float timer_for_double_click;
	
	//this is how long in seconds to allow for a double click
	public float delay = 0.01f;

	void Update ()
	{
		Debug.Log (Time.time - timer_for_double_click);
		if (Input.GetMouseButtonDown (0)) {

			if (!one_click) { // first click no previous clicks
				one_click = true;
				
				timer_for_double_click = Time.time; // save the current time
				// do one click things;
			} else {
				one_click = false; // found a double click, now reset
				
				//do double click things
				transform.Rotate (0, 0, 90);
				Debug.Log ("oneclick");
			}
		}
		if (one_click) {
			// if the time now is delay seconds more than when the first click started. 
			if ((Time.time - timer_for_double_click) > delay) {
				
				//basically if thats true its been too long and we want to reset so the next click is simply a single click and not a double click.
				
				one_click = false;
				
			}
		}
	}
}

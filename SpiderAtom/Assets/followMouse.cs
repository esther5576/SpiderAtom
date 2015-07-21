using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class followMouse : MonoBehaviour
{

	public List<Vector3> _positions = new List<Vector3> ();
	private Vector3 newDotPosition;
	private Vector3 lastDotPosition;
	private bool startDrawing;
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			_positions.Clear ();
		}
		
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.rigidbody != null) {
					
					if (hit.rigidbody.tag == "Player" && startDrawing == false) {
						startDrawing = true;
						
						newDotPosition = ray.origin - ray.direction / ray.direction.y * ray.origin.y;
						
						newDotPosition.y = 2f;
						
						if (this.transform.up == Vector3.forward || -this.transform.up == Vector3.forward)
							newDotPosition.z = this.transform.localPosition.z;
						
						if (this.transform.up == Vector3.up || -this.transform.up == Vector3.up)
							newDotPosition.y = this.transform.localPosition.y;
						
						if (this.transform.up == Vector3.right || -this.transform.up == Vector3.right)
							newDotPosition.x = this.transform.localPosition.x;
						
						if (newDotPosition != lastDotPosition) {
							_positions.Add (newDotPosition);
							lastDotPosition = newDotPosition;
						}
						
					}
					
					if (hit.rigidbody.tag == "Floor" && startDrawing == true && hit.normal == this.transform.up) {
						
						newDotPosition = ray.origin - ray.direction / ray.direction.y * ray.origin.y;
						
						if (this.transform.up == Vector3.forward || -this.transform.up == Vector3.forward)
							newDotPosition.z = this.transform.localPosition.z;
						
						if (this.transform.up == Vector3.up || -this.transform.up == Vector3.up)
							newDotPosition.y = this.transform.localPosition.y;
						
						if (this.transform.up == Vector3.right || -this.transform.up == Vector3.right)
							newDotPosition.x = this.transform.localPosition.x;
						
						if (newDotPosition != lastDotPosition) {
							_positions.Add (newDotPosition);
							lastDotPosition = newDotPosition;
						}
					}
					
				}
			} else {
				listClear ();
			}
		}
		
		if (Input.GetMouseButtonUp (0)) {
			listClear ();
		}
		
		if (_positions.Count > 0) {
			if (transform.position != _positions [0]) {
				transform.position = Vector3.MoveTowards (transform.position, _positions [0], 100 * Time.deltaTime);
				//transform.LookAt (_positions [0]);


			}
			if (transform.position == _positions [0]) {
				_positions.RemoveAt (0);
			}
		}
	}
	
	void listClear ()
	{
		startDrawing = false;
	}
}

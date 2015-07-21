using UnityEngine;
using System.Collections;

public class line : MonoBehaviour
{

	public float _distance = 10;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			Ray _r = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 _pos = _r.GetPoint (_distance);
			transform.position = _pos;
		}
	}
}

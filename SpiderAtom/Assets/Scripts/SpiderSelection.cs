using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderSelection : MonoBehaviour
{
	public List<Transform> _spiderSelected = new List<Transform> ();
	public int _score;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			RaycastHit _hit;
			Ray _ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (_ray, out _hit)) {
				if (_hit.rigidbody != null) {
					if (_spiderSelected.IndexOf (_hit.transform) < 0) {
						_spiderSelected.Add (_hit.transform);
					}
				}
			}
		}

		if (Input.GetMouseButtonUp (0)) {

			if (_spiderSelected.Count == 3) {
				if (_spiderSelected [0].tag == "Oxygen" && _spiderSelected [1].tag == "Hydrogene" && _spiderSelected [2].tag == "Oxygen") {
					_score ++;
				}
				if (_spiderSelected [0].tag == "Hydrogene" && _spiderSelected [1].tag == "Carbon" && _spiderSelected [2].tag == "Hydrogene") {
					_score ++;
				}
			}

			_spiderSelected.Clear ();
		}
	}

	void OnGUI ()
	{
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 30;
		
		myStyle.normal.textColor = Color.white;

		GUI.Label (new Rect (10, 10, 100, 20), "Score " + _score, myStyle);
	}
}

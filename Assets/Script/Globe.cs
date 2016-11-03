using UnityEngine;
using System.Collections;

public class Globe : MonoBehaviour {

	[SerializeField] private bool m_UseRadians = false;
	[Range(-Mathf.PI/2, Mathf.PI/2)] [SerializeField] private double m_Latitude = 0.0;
	[Range(-Mathf.PI, Mathf.PI)] [SerializeField] private double m_Longitude = 0.0;

	[Range(-90, 90)] [SerializeField] private float m_LatitudeDegree = 51.4826f;
	[Range(-180, 180)] [SerializeField] private float m_LongitudeDegree = -0.0077f; // Greenwich Coordinates

	[Range(0f, 1f)] [SerializeField] private float m_MarkerHeight = 0.01f;
	[Range(0f, 1f)] [SerializeField] private float m_MarkerScale = 0.3f;
	[SerializeField] private Transform m_GeoMarker;

	private Transform m_Markers;

	// Use this for initialization
	void Start () {
		AddMarker ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMarker(){
		if (m_UseRadians) {
			m_LatitudeDegree = (float)m_Latitude * 180.0f;
			m_LongitudeDegree = (float)m_Longitude * 180.0f;
		}

		if (m_GeoMarker != null) {
			Quaternion LocationRot = Quaternion.AngleAxis (m_LongitudeDegree, -Vector3.forward) * Quaternion.AngleAxis (m_LatitudeDegree, -Vector3.right);
			Transform cloneMarker = (Transform)Instantiate (m_GeoMarker, Vector3.zero, Quaternion.identity);

			cloneMarker.transform.parent = transform;
			cloneMarker.localScale = cloneMarker.localScale * m_MarkerScale;
			cloneMarker.transform.localPosition = LocationRot * new Vector3 (0, -m_MarkerHeight, 0);
			cloneMarker.transform.localRotation = LocationRot;
		}
	}
}

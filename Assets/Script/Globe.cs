using UnityEngine;
using System.Collections;

public class Globe : MonoBehaviour {

	[SerializeField] private bool m_UseRadians = false;
	[Range(-Mathf.PI/2, Mathf.PI/2)] [SerializeField] private double m_Latitude = 0.0;
	[Range(-Mathf.PI, Mathf.PI)] [SerializeField] private double m_Longitude = 0.0;

	[Range(-90, 90)] [SerializeField] private float m_LatitudeDegree = 0.0f;
	[Range(-180, 180)] [SerializeField] private float m_LongitudeDegree = 0.0f;

	[Range(0f, 1f)] [SerializeField] private float m_Radius = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (m_UseRadians) {
			m_LatitudeDegree = (float)m_Latitude * 180.0f;
			m_LongitudeDegree = (float)m_Longitude * 180.0f;
		}
		transform.localPosition = Quaternion.AngleAxis(m_LongitudeDegree, -Vector3.forward) * Quaternion.AngleAxis(m_LatitudeDegree, -Vector3.up) * new Vector3(m_Radius,0,0);
	}
}

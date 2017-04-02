using UnityEngine;
using System.Collections;

public class GlobeController : MonoBehaviour {

	[System.Serializable]
	private class LatLng
	{
		[Range(-90f, 90f)] public float lat;
		[Range(-180f, 180f)] public float lng;
        public string description;
	}

	[SerializeField] private bool m_UseRadians = false;
	[SerializeField] private LatLng[] m_Locations;

	[Range(0f, 1f)] [SerializeField] private float m_MarkerHeight = 0.01f;
	[Range(0f, 1f)] [SerializeField] private float m_MarkerScale = 0.7f;
	[SerializeField] private Transform m_GeoMarker;


	// Use this for initialization
	void Start () {
		if (m_Locations != null) {
			for (int i = 0; i < m_Locations.Length; i++) AddMarker();
			for (int i = 0; i < m_Locations.Length; i++) SetMarker(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMarker(){
		Transform cloneMarker = (Transform)Instantiate (m_GeoMarker, Vector3.zero, Quaternion.identity);
		cloneMarker.transform.parent = transform;
	}

	public void SetMarker(int index){

		try{

			float lat = m_Locations [index].lat;
			float lng = m_Locations [index].lng;
            string description = m_Locations[index].description;
			Transform cloneMarker = transform.GetChild (index);

			if (m_UseRadians) {
				lat = lat * 180.0f;
				lng = lng * 180.0f;
			}

			if (m_GeoMarker != null) {
				Quaternion LocationRot = Quaternion.AngleAxis (lng, -Vector3.forward) * Quaternion.AngleAxis (lat, -Vector3.right);
				cloneMarker.localScale = cloneMarker.localScale * m_MarkerScale;
				cloneMarker.transform.localPosition = LocationRot * new Vector3 (0, -m_MarkerHeight, 0);
				cloneMarker.transform.localRotation = LocationRot;
                if (cloneMarker.GetComponent<Marker>() != null) cloneMarker.GetComponent<Marker>().SetTitle(description);

            }
		}
		finally{
			//
		}
	}
}

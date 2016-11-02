using UnityEngine;
using System.Collections;

public class CustomizeAnimation : MonoBehaviour {


	[SerializeField] private bool m_AutoRotate = true;
	[Range(0f, 50f)] [SerializeField] private float m_RotateSpeedX = 0f;
	[Range(0f, 50f)] [SerializeField] private float m_RotateSpeedY = 10.0f;
	[Range(0f, 50f)] [SerializeField] private float m_RotateSpeedZ = 0f;

	[SerializeField] private bool m_AutoVibrate = true;
	[Range(0f, 10f)] [SerializeField] private float m_FrequencyX = 1.0f;
	[Range(0f, 10f)] [SerializeField] private float m_MagnitudeX = 0.2f;
	[Range(-Mathf.PI, Mathf.PI)] [SerializeField] private float m_PhaseX = 1.5f;

	[Range(0f, 10f)] [SerializeField] private float m_FrequencyY = 1.0f;
	[Range(0f, 10f)] [SerializeField] private float m_MagnitudeY = 0.08f;
	[Range(-Mathf.PI, Mathf.PI)] [SerializeField] private float m_PhaseY = 0f;

	[Range(0f, 10f)] [SerializeField] private float m_FrequencyZ = 0f;
	[Range(0f, 10f)] [SerializeField] private float m_MagnitudeZ = 0f;
	[Range(-Mathf.PI, Mathf.PI)] [SerializeField] private float m_PhaseZ = 0f;


	private Vector3 m_OriginalPosition;

	void Awake(){
		m_OriginalPosition = transform.position;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (m_AutoRotate) {
			transform.Rotate(
				m_RotateSpeedX * Time.deltaTime,
				m_RotateSpeedY * Time.deltaTime,
				m_RotateSpeedZ * Time.deltaTime
			);
		}

		if (m_AutoVibrate) {

			Vector3 newPos = new Vector3 (
				                 m_OriginalPosition.x + OffsetByTime (m_FrequencyX, m_MagnitudeX, m_PhaseX),
				                 m_OriginalPosition.y + OffsetByTime (m_FrequencyY, m_MagnitudeY, m_PhaseY),
				                 m_OriginalPosition.z + OffsetByTime (m_FrequencyZ, m_MagnitudeZ, m_PhaseZ)
			                 );
				
			transform.position = newPos;
		}
	}

	private float OffsetByTime(float frequency, float magnitude, float phase){
		return magnitude * Mathf.Sin (frequency * Time.time * Mathf.PI + phase);
	}
}

using UnityEngine;
using System.Collections;

public class MatrixPercentage : MonoBehaviour {

	[Range(0f, 1f)] [SerializeField] private float m_Percentage = 0.5f;
	[SerializeField] private Transform m_BaseShape;
	[SerializeField] private Material m_HighlightMaterial;
	[SerializeField] private int m_NumberOfRows = 5;
	[SerializeField] private int m_NumberOfColumns = 10;
	[SerializeField] private float m_GapSize = 0.5f;

	private Material m_BaseMaterial;

	// Use this for initialization
	void Awake () {

        int highlightNumber = (int)(m_NumberOfRows * m_NumberOfColumns * m_Percentage);
		for (int i = 0; i < m_NumberOfRows; i++) {
			for (int j = 0; j < m_NumberOfColumns; j++) {
				Transform baseClone = (Transform)Instantiate (m_BaseShape, Vector3.zero, Random.rotation);
				if (i * m_NumberOfColumns + j < highlightNumber)
					baseClone.GetComponent<Renderer> ().material = (Material)Instantiate (m_HighlightMaterial);
				baseClone.parent = transform;
				baseClone.localPosition = new Vector3 (j * m_GapSize, i * m_GapSize, 0);
			}
		}
	}
}

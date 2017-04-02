using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

	[SerializeField] private TextMesh m_Title;

	public void SetTitle(string title){
		if (m_Title != null) {
			m_Title.text = title;
		}
	}
}

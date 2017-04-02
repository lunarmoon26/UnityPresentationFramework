using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

[RequireComponent(typeof(TextMesh))]
public class TimestampText : MonoBehaviour {

    [SerializeField]
    private string m_DateTimeFormatString = "F"; // Standard Date and Time Format Strings

    [SerializeField]
    private CultureTypes m_CultureInfoType;

    private TextMesh m_TextMesh;
	// Use this for initialization
	void Awake () {
        m_TextMesh = transform.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        m_TextMesh.text = DateTime.Now.ToString(m_DateTimeFormatString, CultureInfo.CreateSpecificCulture("en-US"));
    }
}

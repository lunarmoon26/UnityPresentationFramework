using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController: MonoBehaviour {

    [SerializeField]
    private List<Transform> m_Targets;

    [SerializeField]
    private int m_InitialSlide = 0;

    [SerializeField]
    private bool m_AutoPlay = true;

    private float m_DurationOfCurrentSlide;
    private float m_TimeOut;

    public delegate void SlideChangedDelegate(bool changed);
    private SlideChangedDelegate m_SlideChanged;

    // Use this for initialization
    void Start() {
		if (m_Targets != null && m_Targets.Count > 0) {
			m_InitialSlide = m_InitialSlide % m_Targets.Count;
			LandingOnSlide();
			CurrentSlide.OnFocusing();
		}
    }
	
	// Update is called once per frame
	void Update () {

        if (m_Targets != null && m_Targets.Count > 0)
        {
            m_TimeOut += Time.deltaTime;

            if (Input.GetMouseButtonDown(0) || (m_TimeOut >= m_DurationOfCurrentSlide && m_AutoPlay))
            {
                NextSlide();
            }
            if (Input.GetMouseButtonDown(1))
            {
                PreviousSlide();
            }
        }
    }

    private void NextSlide() {
        CurrentSlide.OnBlurred();
        m_InitialSlide = (m_InitialSlide + 1) % m_Targets.Count;
        LandingOnSlide();
        CurrentSlide.OnFocusing();
    }

    private void PreviousSlide() {
        CurrentSlide.OnBlurred();
        m_InitialSlide = m_InitialSlide - 1 < 0 ? m_Targets.Count - 1 : (m_InitialSlide - 1) % m_Targets.Count;
        LandingOnSlide();
        CurrentSlide.OnFocusing();
    }

    private void LandingOnSlide() {
        m_SlideChanged(true);
        transform.position = m_Targets[m_InitialSlide].transform.position;
		transform.parent = m_Targets [m_InitialSlide];
		transform.localRotation = Quaternion.identity;
        m_TimeOut = 0;
        m_DurationOfCurrentSlide = m_Targets[m_InitialSlide].GetComponent<AbstractSlide>().Duration;
    }

    public void SetSlideChangedDelegate(SlideChangedDelegate newDelegate)
    {
        m_SlideChanged += newDelegate;
    }

    public AbstractSlide CurrentSlide {
        get
        {
            if (m_Targets != null && m_Targets.Count > 0)
            {
                m_InitialSlide = m_InitialSlide % m_Targets.Count;
                return m_Targets[m_InitialSlide].GetComponent<AbstractSlide>();
            }
            return null;
        }
    }
}

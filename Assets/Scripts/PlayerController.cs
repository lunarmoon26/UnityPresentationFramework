using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class PlayerController: MonoBehaviour {

    [SerializeField]
	private AbstractSlideController[] m_AllSlides;

	[SerializeField]
	private List<AbstractSlideController> m_EnabledSlides;

	[SerializeField] private Transform m_CameraRig;

	[SerializeField]
	private int m_PreviewAt = 0;

    [SerializeField]
    private int m_InitialSlide = 0;

	private int m_CurrentSlide = 0;

    [SerializeField]
    private bool m_AutoPlay = true;

    private float m_DurationOfCurrentSlide;
    private float m_TimeOut;

    public delegate void SlideChangedDelegate(bool changed);
    private SlideChangedDelegate m_SlideChanged;

	void Awake(){
		if (Application.isPlaying) {
			m_EnabledSlides = new List<AbstractSlideController> ();
			for (int i = 0; i < m_AllSlides.Length; ++i) {
				if (!m_AllSlides [i].Hidden)
					m_EnabledSlides.Add (m_AllSlides [i]);
			}
		}
	}

    // Use this for initialization
    void Start() {
		if (Application.isPlaying) {
			if (m_EnabledSlides != null && m_EnabledSlides.Count > 0) {
				m_CurrentSlide = m_InitialSlide % m_EnabledSlides.Count;
				LandingOnSlide ();
				CurrentSlide.Focusing ();
			}
		} else {
			m_AllSlides = FindObjectsOfType<AbstractSlideController>();
			m_CurrentSlide = m_PreviewAt % m_AllSlides.Length;
			PreviewAtSlide ();
		}
    }
	
	// Update is called once per frame
	void Update () {
		if (Application.isPlaying) {
			if (m_EnabledSlides != null && m_EnabledSlides.Count > 0)
			{
				m_TimeOut += Time.deltaTime;

				if (Input.GetMouseButtonDown (0) || Input.GetKeyDown ("right") || (m_TimeOut >= m_DurationOfCurrentSlide && m_AutoPlay)) {
					NextSlide ();
				}
				if (Input.GetMouseButtonDown (1) || Input.GetKeyDown ("left")) {
					PreviousSlide ();
				}
			}
		} else {
			m_AllSlides = FindObjectsOfType<AbstractSlideController>();
			m_CurrentSlide = m_PreviewAt % m_AllSlides.Length;
			PreviewAtSlide ();
		}
    }

    private void NextSlide() {
        CurrentSlide.Blurred();
		m_CurrentSlide = (m_CurrentSlide + 1) % m_EnabledSlides.Count;
        LandingOnSlide();
        CurrentSlide.Focusing();
    }

    private void PreviousSlide() {
        CurrentSlide.Blurred();
		m_CurrentSlide = m_CurrentSlide - 1 < 0 ? m_EnabledSlides.Count - 1 : (m_CurrentSlide - 1) % m_EnabledSlides.Count;
        LandingOnSlide();
        CurrentSlide.Focusing();
    }

    private void LandingOnSlide() {
		m_SlideChanged(true);
		transform.position = m_EnabledSlides[m_CurrentSlide].transform.position;
		transform.parent = m_EnabledSlides [m_CurrentSlide].transform;
		transform.localRotation = Quaternion.identity;
        m_TimeOut = 0;
		m_DurationOfCurrentSlide = m_EnabledSlides[m_CurrentSlide].Duration;
    }

	private void PreviewAtSlide() {
		if (m_CameraRig != null) {
			m_CameraRig.position = m_AllSlides[m_CurrentSlide].transform.position;
			m_CameraRig.rotation = m_AllSlides[m_CurrentSlide].transform.rotation;
		}
	}

    public void SetSlideChangedDelegate(SlideChangedDelegate newDelegate)
    {
        m_SlideChanged += newDelegate;
    }

	public AbstractSlideController CurrentSlide {
        get
        {
			if (m_EnabledSlides != null && m_EnabledSlides.Count > 0)
            {
				m_CurrentSlide = m_CurrentSlide % m_EnabledSlides.Count;
				return m_EnabledSlides[m_CurrentSlide];
            }
            return null;
        }
    }
}

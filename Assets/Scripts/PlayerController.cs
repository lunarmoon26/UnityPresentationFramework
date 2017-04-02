using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace UnityPresentationFramework.Control
{

    [ExecuteInEditMode]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private List<AbstractSlideController> m_AllSlides = new List<AbstractSlideController>();

        private List<AbstractSlideController> m_EnabledSlides;

        [SerializeField]
        private Transform m_CameraRig;

        private int m_CurrentSlide = 0;

        [SerializeField]
        private bool m_AutoPlay = true;

        private float m_DurationOfCurrentSlide;
        private float m_TimeOut;

        public delegate void SlideChangedDelegate(bool changed);
        private SlideChangedDelegate m_SlideChanged;

        void Awake()
        {
            if (Application.isPlaying)
            {
                m_EnabledSlides = new List<AbstractSlideController>();
                m_AllSlides.ForEach(x =>
                {
                    if (x && x.gameObject.activeSelf)
                        m_EnabledSlides.Add(x);
                });
            }
        }

        // Use this for initialization
        void Start()
        {
            if (Application.isPlaying)
            {
                if (m_EnabledSlides != null && m_EnabledSlides.Count > 0)
                {
                    LandingOnSlide();
                    CurrentSlide.Focusing();
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Application.isPlaying)
            {
                if (m_EnabledSlides != null && m_EnabledSlides.Count > 0)
                {
                    m_TimeOut += Time.deltaTime;

                    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("right") || (m_TimeOut >= m_DurationOfCurrentSlide && m_AutoPlay))
                    {
                        NextSlide();
                    }
                    if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("left"))
                    {
                        PreviousSlide();
                    }
                }
            }
        }

        private void NextSlide()
        {
            CurrentSlide.Blurred();
            m_CurrentSlide = (m_CurrentSlide + 1) % m_EnabledSlides.Count;
            LandingOnSlide();
            CurrentSlide.Focusing();
        }

        private void PreviousSlide()
        {
            CurrentSlide.Blurred();
            m_CurrentSlide = m_CurrentSlide - 1 < 0 ? m_EnabledSlides.Count - 1 : (m_CurrentSlide - 1) % m_EnabledSlides.Count;
            LandingOnSlide();
            CurrentSlide.Focusing();
        }

        private void LandingOnSlide()
        {
            m_SlideChanged(true);
            transform.position = m_EnabledSlides[m_CurrentSlide].transform.position;
            transform.parent = m_EnabledSlides[m_CurrentSlide].transform;
            transform.localRotation = Quaternion.identity;
            m_TimeOut = 0;
            m_DurationOfCurrentSlide = m_EnabledSlides[m_CurrentSlide].Duration;
        }

        public void PreviewAtSlide(int index)
        {
            if (m_CameraRig != null && m_AllSlides != null  && m_AllSlides.Count > 0)
            {
                m_CameraRig.position = m_AllSlides[index % m_AllSlides.Count].transform.position;
                m_CameraRig.rotation = m_AllSlides[index % m_AllSlides.Count].transform.rotation;
            }
        }

        public void SetSlideChangedDelegate(SlideChangedDelegate newDelegate)
        {
            m_SlideChanged += newDelegate;
        }

        public AbstractSlideController CurrentSlide
        {
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

}
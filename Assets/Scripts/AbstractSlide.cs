using UnityEngine;
using System.Collections;


public abstract class AbstractSlide : MonoBehaviour {

    [SerializeField]
    private int m_Duration = 3;
    [SerializeField]
    private string m_SlideName = "";

    public delegate void OnFocusingEventDelegate();
    private OnFocusingEventDelegate m_OnFocusing;

    public delegate void OnFocusedEventDelegate();
    private OnFocusedEventDelegate m_OnFocused;

    public delegate void OnBlurredEventDelegate();
    private OnBlurredEventDelegate m_OnBlurred;

    private delegate void StartEnteringDelegate();
    private StartEnteringDelegate m_StartEntering;

    // Use this for initialization
    protected virtual void Awake () {
        m_OnFocusing += WhenFocusing;
        m_OnFocused += WhenFocused;
        m_OnBlurred += WhenBlurred;

        for(int i = 0; i < transform.childCount; i++)
        {
            var coreAnimationComponent = transform.GetChild(i).GetComponent<CoreAnimation>();
            if(coreAnimationComponent != null)
            {
                m_StartEntering += coreAnimationComponent.Enter;
            }
        }
    }

    void Start()
    {
        if(m_StartEntering != null) m_StartEntering();
    }

    protected abstract void WhenFocusing();
    protected abstract void WhenFocused();
    protected abstract void WhenBlurred();

    public int Duration {
        get { return m_Duration; }
    }

    public OnFocusingEventDelegate OnFocusing
    {
        get { return m_OnFocusing; }
    }

    public OnFocusedEventDelegate OnFocused
    {
        get { return m_OnFocused; }
    }

    public OnBlurredEventDelegate OnBlurred
    {
        get { return m_OnBlurred; }
    }
}

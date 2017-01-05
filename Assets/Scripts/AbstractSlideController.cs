using UnityEngine;
using System.Collections;


public abstract class AbstractSlideController : MonoBehaviour {

    [SerializeField]
    private int m_Duration = 3;
    [SerializeField]
    private string m_SlideName = "";
	[SerializeField]
	private bool m_IsHidden = false;

    public delegate void OnFocusingEventDelegate();
    private OnFocusingEventDelegate m_OnFocusing;

    public delegate void OnFocusedEventDelegate();
    private OnFocusedEventDelegate m_OnFocused;

    public delegate void OnBlurredEventDelegate();
    private OnBlurredEventDelegate m_OnBlurred;

    protected delegate void StartEnteringDelegate();
    protected StartEnteringDelegate m_StartEntering;

	protected bool m_IsFirstTimeEnter = true;

    // Use this for initialization
    protected virtual void Awake () {
		m_OnFocusing += OnFocusing;
		m_OnFocused += OnFocused;
		m_OnBlurred += OnBlurred;

        for(int i = 0; i < transform.childCount; i++)
        {
            var coreAnimationComponent = transform.GetChild(i).GetComponent<CoreAnimation>();
            if(coreAnimationComponent != null)
            {
                m_StartEntering += coreAnimationComponent.Enter;
            }
        }
    }

    protected abstract void OnFocusing();
    protected abstract void OnFocused();
    protected abstract void OnBlurred();

    public int Duration {
        get { return m_Duration; }
    }

	public bool Hidden {
		get { return m_IsHidden; }
	}
    public OnFocusingEventDelegate Focusing
    {
        get { return m_OnFocusing; }
    }

    public OnFocusedEventDelegate Focused
    {
        get { return m_OnFocused; }
    }

    public OnBlurredEventDelegate Blurred
    {
        get { return m_OnBlurred; }
    }
}

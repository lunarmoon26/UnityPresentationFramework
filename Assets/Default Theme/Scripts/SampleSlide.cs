using UnityEngine;
using System.Collections;

public class SampleSlide : AbstractSlideController
{

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        // Your code..
    }

    protected override void OnFocusing()
    {
        //Debug.Log("Focusing");
        // Your code..
    }

    protected override void OnFocused() {
        //Debug.Log("Focused");
        // Your code..
		if (m_IsFirstTimeEnter) {
			if (m_StartEntering != null)
				m_StartEntering ();
			m_IsFirstTimeEnter = false;
		}
    }
    protected override void OnBlurred() {
        //Debug.Log("Blurred");
        // Your code..
    }

}
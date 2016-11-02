using UnityEngine;
using System.Collections;

public class SampleSlide : AbstractSlide
{

    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        // Your code..
    }

    protected override void WhenFocusing()
    {
        //Debug.Log("Focusing");
        // Your code..
    }

    protected override void WhenFocused() {
        //Debug.Log("Focused");
        // Your code..
    }
    protected override void WhenBlurred() {
        //Debug.Log("Blurred");
        // Your code..
    }

}
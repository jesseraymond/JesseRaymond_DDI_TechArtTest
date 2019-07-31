using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPopup : MonoBehaviour
{
    // TODO Several things are preventing the popup from working
    // TODO Debug the problems, and for extra credit minimize future human error and maximize flexbility
    public Animator popupAnimator;
    public Button button;

    void Start ()
    {
        button.onClick.AddListener (() => Toggle ());
    }

    void Toggle ()
    {
        popupAnimator.SetTrigger ("Toggle");
    }
}

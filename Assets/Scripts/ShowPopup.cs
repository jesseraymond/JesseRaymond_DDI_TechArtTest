using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ShowPopup : LeftMenuButton
{
    public Animator popupAnimator; // Set in the Inspector

    protected override void OnClick()
    {
        base.OnClick();
        Toggle();
    }

    private void Toggle ()
    {
        // Reduced human error by limiting redundant typing of string-dependent functionality (less chances for typos)
        popupAnimator.SetTrigger(MethodBase.GetCurrentMethod().Name);
    }

    public override object CopyScriptToGeneratedGameObject()
    {
        object copy = base.CopyScriptToGeneratedGameObject();
        if (copy is ShowPopup showPopup)
        {
            showPopup.popupAnimator = popupAnimator;
        }

        return base.CopyScriptToGeneratedGameObject();
    }
}

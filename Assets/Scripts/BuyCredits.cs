using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCredits : LeftMenuButton
{
    public int addCreditValue; // Set in the Inspector

    protected override void OnClick()
    {
        base.OnClick();
        CreditManager.AddCredits(addCreditValue);
    }

    public override object CopyScriptToGeneratedGameObject()
    {
        object copy = base.CopyScriptToGeneratedGameObject();
        if (copy is BuyCredits buyCredits)
        {
            buyCredits.addCreditValue = addCreditValue;
        }

        return base.CopyScriptToGeneratedGameObject();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProblemScript : MonoBehaviour
{
    public Button button;
    public int addCreditValue;

    // TODO If you know how, repair this script to accomplish its intended goal, and rename it apropriately
    // TODO If you do not know how, prevent the compile errors, or delete this script, and carry on with the test
    void Start ()
    {
        //The listener should be listening for the click event, which then calls the AddCredits method, instead of trying to listen for an AddCredits event
        button.onClick.AddListener ( () => OnClick ());
    }

    void OnClick ()
    {
        CreditManager.AddCredits (addCreditValue);
    }
}

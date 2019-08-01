using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditManager : Singleton<CreditManager>
{
    public Text creditValue;

    private static CreditManager _instance;
    private const int startingCredits = 999;
    private const int maxCredits = 99999999;

    private int credits;
    public int Credits
    {
        get { return credits; }
        set
        {
            if (credits == value)
            {
                return;
            }

            credits = value;

            OnCreditsChange?.Invoke(credits);
        }
    }
    public delegate void OnVariableChangeDelegate(int newVal);
    public event OnVariableChangeDelegate OnCreditsChange;

    private void Start()
    {
        OnCreditsChange += CreditsChangeHandler;
        Credits = startingCredits;
    }

    private void Awake ()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            // Removed duplicate instance of the CreditManager component in the UIPrototype1 scene and implemented the standard Unity singleton pattern
            Debug.LogWarning($"Singleton of {GetType().Name} already exists. Any additional instances are unnecessary and should be removed.");
        }
    }

    private void CreditsChangeHandler(int newValue)
    {
        creditValue.text = IntToFormattedString(newValue);
    }

    private string IntToFormattedString(int newValue)
    {
        return String.Format("{0:n0}", newValue);
    }

    //The protection level of this method was set to private, making it inaccessible to the problem script
    public static void AddCredits (int value)
    {
        //Functionality to add Credits
        if (_instance.Credits + value < maxCredits)
        {
            _instance.Credits += value;
        }
    }
}

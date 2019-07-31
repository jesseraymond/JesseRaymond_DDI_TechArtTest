using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour
{
    static CreditManager _instance;
    public Text creditValue;

    static int credits = 0;

    void Awake ()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogWarning($"Singleton of {this.GetType().Name} already exists. Newly created instance will be deleted and the previous instance will be preserved.");
            Destroy(this);
        }
    }

    //The protection level of this method was set to private, making it inaccessible to the problem script
    public static void AddCredits (int value)
    {
        //Added functionality to add credits
        credits += value;
    }
}

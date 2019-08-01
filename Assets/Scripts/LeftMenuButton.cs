using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LeftMenuButton : MonoBehaviour
{
    public string CustomName = "";

    [HideInInspector]
    public GameObject GeneratedGameObject;
    [HideInInspector]
    public Text ButtonText;

    protected void Awake()
    {
        if (GeneratedGameObject != null)
        {
            if (GeneratedGameObject.GetComponentInChildren<Text>() is Text text)
            {
                ButtonText = text;
                ButtonText.text = CustomName == "" ? Regex.Replace(GetType().Name, "(\\B[A-Z0-9])", " $1") : CustomName;
            }

            if (GeneratedGameObject.GetComponent<Button>() is Button button)
            {
                button.onClick.AddListener(OnClick);
            }
        }
    }

    public virtual object CopyScriptToGeneratedGameObject()
    {
        return GeneratedGameObject.AddComponent(GetType());
    }

    protected virtual void OnClick()
    {
        Debug.Log($"{GetType().Name} clicked");
    }
}
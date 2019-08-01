using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftMenu : Singleton<LeftMenu>
{
    public RectTransform ScrollViewContentRect;
    public GameObject ButtonPrefab;
    public float MenuItemVerticalPadding;

    private float nextButtonPosition;

    private void Awake ()
    {
        nextButtonPosition = MenuItemVerticalPadding;

        foreach (LeftMenuButton item in GetComponents<LeftMenuButton>())
        {
            item.GeneratedGameObject = Instantiate(Instance.ButtonPrefab, Instance.ScrollViewContentRect.transform);
            item.GeneratedGameObject.name = $"{item.GetType().Name}Button";

            RectTransform rt = (RectTransform)item.GeneratedGameObject.transform;
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(1, 1);
            rt.pivot = new Vector2 (0.5f, 1);
            rt.position = new Vector3(rt.position.x, nextButtonPosition, rt.position.y);
            nextButtonPosition -= rt.rect.height + MenuItemVerticalPadding;

            item.CopyScriptToGeneratedGameObject();
            //item.GeneratedGameObject.GetComponent(item.GetType());
        }
    }
}

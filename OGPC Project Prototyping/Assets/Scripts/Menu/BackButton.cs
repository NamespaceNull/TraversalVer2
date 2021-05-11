using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject sManager;
    public GameObject self;
    GameObject objToExit;
    RectTransform backTransform;
    Vector2 lastScreenSize;
    private void Start()
    {
        lastScreenSize = new Vector2(Screen.width, Screen.height);
        BackButtonTransformations();
    }
    private void Update()
    {
        Vector2 curSize = new Vector2(Screen.width, Screen.height);
        if (!curSize.Equals(lastScreenSize))
        {
            BackButtonTransformations();
        }
        lastScreenSize = curSize;
    }
    public void GetObject(GameObject obj)
    {
        objToExit = obj;
        self.SetActive(true);
    }
    public void Exit()
    {
        objToExit.SetActive(false);
        sManager.GetComponent<SettingsManager>().SetVis("opened");
    }
    void BackButtonTransformations()
    {
        // Set the size and location of the button \\

        // Get the container
        backTransform = GetComponent<RectTransform>();

        // parameters, this will be a fraction of the screen's dimensions
        float padding = 0.025f;
        float dimensions = 0.1f;

        // Transformations
        backTransform.sizeDelta = new Vector2(dimensions * Screen.height,
            dimensions * Screen.height);
        backTransform.position = new Vector2((int)(padding * Screen.width + backTransform.rect.width),
            (int)((1 - padding) * Screen.height - backTransform.rect.height));
    }
}

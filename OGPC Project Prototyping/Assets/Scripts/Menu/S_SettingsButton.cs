using UnityEngine;
using UnityEngine.UI;

public class S_SettingsButton : MonoBehaviour
{

    RectTransform gearRotate;
    Button buttonComponent;
    public GameObject sManager;
    public bool isOpen;

    Vector2 lastScreenSize;
    private void Start()
    {
        gearRotate = GetComponent<RectTransform>();
        buttonComponent = GetComponent<Button>();
        isOpen = false;
        lastScreenSize = new Vector2(Screen.width, Screen.height);
        SettingsButtonTransformations();

    }
    private void Update()
    {
        Vector2 curSize = new Vector2(Screen.width, Screen.height);
        if (!curSize.Equals(lastScreenSize))
        {
            SettingsButtonTransformations();
        }
        lastScreenSize = curSize;
    }
    public void BasicFunction()
    {
        buttonComponent.interactable = false;
        int multVal = isOpen ? 1 : -1;
        gearRotate.Rotate(0, 0, 35 * multVal);
        isOpen = !isOpen;
        string newVisState = sManager.GetComponent<SettingsManager>().CreateStringVis(isOpen);
        sManager.GetComponent<SettingsManager>().SetVis(newVisState);
        buttonComponent.interactable = true;
    }
    void SettingsButtonTransformations()
    {
        // Set the size and location of the button \\

        // Get the container
        RectTransform buttonTransform = GetComponent<RectTransform>();

        // parameters, this will be a fraction of the screen's dimensions
        float padding = 0.025f;
        float dimensions = 0.1f;

        // Transformations
        buttonTransform.sizeDelta = new Vector2(dimensions * Screen.height, dimensions * Screen.height); // Square button
        buttonTransform.position = new Vector2((int)((1 - padding) * Screen.width - buttonTransform.rect.width), (int)((1 - padding) * Screen.height - buttonTransform.rect.height));
    }

}
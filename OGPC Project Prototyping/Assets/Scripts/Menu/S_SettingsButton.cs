using UnityEngine;
using UnityEngine.UI;

public class S_SettingsButton : MonoBehaviour
{

    RectTransform gearRotate;
    Button buttonComponent;
    public GameObject sManager;
    public bool isOpen;
    private void Start()
    {
        gearRotate = GetComponent<RectTransform>();
        buttonComponent = GetComponent<Button>();
        isOpen = false;

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
}

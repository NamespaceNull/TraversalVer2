using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour
{
    public GameObject sManager;
    bool menuOpen = true;
    bool lastMenuOpen;
    public GameObject player;
    public GameObject self;
    public static bool opened;
    Text childText;
    // Start is called before the first frame update
    void Start()
    {
        opened = false;
        childText = transform.Find("Text").gameObject.GetComponent<Text>();
        lastMenuOpen = menuOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if (opened)
        {
            childText.text = "Save";
        }
        opened = false;
        SaveButtonTransformations();
    }
    public void doSave()
    {
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        childText.text = "Saved";
    }
    void SaveButtonTransformations()
    {
        // Set the size and location of the button \\

        // Get the container
        RectTransform saveTransform = GetComponent<RectTransform>();

        // parameters, this will be a fraction of the screen's dimensions
        float padding = 0.025f;
        float dimensions = 0.1f;

        // Transformations
        saveTransform.sizeDelta = new Vector2(dimensions * Screen.height, dimensions * Screen.height); // Square button
        saveTransform.position = new Vector2((int)(padding * Screen.width + saveTransform.rect.width), (int)((1 - padding) * Screen.height - saveTransform.rect.height));
    }
}

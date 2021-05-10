using UnityEngine;
using UnityEngine.UI;

public class VolumeAdjuster : MonoBehaviour
{
    Button volDown;
    Button volUp;
    Slider volAdjust;

    int lastScreenWidth;

    private void Awake()
    {
        // Get objects
        volDown = GameObject.Find("Volume Decrease").GetComponent<Button>();
        volUp = GameObject.Find("Volume Increase").GetComponent<Button>();
        volAdjust = GameObject.Find("Volume Slider").GetComponent<Slider>();

    }
    private void Start()
    {
        lastScreenWidth = Screen.width; // Get initial screen size
        VisualUISet();
        //Set initial volume
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
        }
        AllAdjust();
    }

    private void Update()
    {
        if (Screen.width != lastScreenWidth)
        {
            VisualUISet();
            lastScreenWidth = Screen.width;
        }
        AllAdjust();
    }

    public void VolumeDecrease()
    {
        float volume = PlayerPrefs.GetFloat("volume") - .1f;
        PlayerPrefs.SetFloat("volume", volume);
        AllAdjust();
    }
    public void VolumeIncrease()
    {
        float volume = PlayerPrefs.GetFloat("volume") + .1f;
        PlayerPrefs.SetFloat("volume", volume);
        AllAdjust();

    }
    public void VolumeAdjust()
    {
        PlayerPrefs.SetFloat("volume", volAdjust.normalizedValue);
        AllAdjust();

    }
    void AllAdjust()
    {
        // Get volume
        float volume = PlayerPrefs.GetFloat("volume");

        //Set system volume
        AudioListener.volume = volume;

        // Default volume changing buttons to interactable
        volUp.interactable = true;
        volDown.interactable = true;

        // Make buttons not interactable if they would do nothing
        if (volume == 1) { volUp.interactable = false; } // Max volume
        if (volume == 0) { volDown.interactable = false; } // Muted

        // Set the slider to represent the current volume
        volAdjust.normalizedValue = volume;
    }
    void VisualUISet()
    {
        // Get transforms
        RectTransform volRectTransform = volAdjust.GetComponent<RectTransform>();
        RectTransform downRectTransform = volDown.GetComponent<RectTransform>();
        RectTransform upRectTransform = volUp.GetComponent<RectTransform>();

        int perCent5 = (int)(0.05f * Screen.width); // 5% of the screen width

        // Get and set text size
        Text downText = volDown.GetComponentInChildren<Text>();
        downText.fontSize = (int)(downText.fontSize * perCent5 * perCent5 / (upRectTransform.rect.width * upRectTransform.rect.width));
        if (downText.fontSize > 68)
        { downText.fontSize = 68; }
        Text upText = volUp.GetComponentInChildren<Text>();
        upText.fontSize = downText.fontSize;

        // Set volume bar and button sizes and positions
        upRectTransform.sizeDelta = new Vector2(perCent5, perCent5);
        downRectTransform.sizeDelta = upRectTransform.sizeDelta;

        upRectTransform.position = new Vector2((int)(0.95f * Screen.width), (int)(0.05f * Screen.height));
        downRectTransform.position = new Vector2(perCent5, (int)(.05f * Screen.height));

        volRectTransform.sizeDelta = new Vector2((int)(Screen.width * .75f), volRectTransform.rect.height);
        volRectTransform.position = new Vector2((int)(Screen.width / 2), (int)(0.05f * Screen.height + perCent5 / 2));
    }
}
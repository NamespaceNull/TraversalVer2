using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darknessManager : MonoBehaviour
{

    public Color32 environmentalColor;
    public Color32 darknessColor;
    public GameObject player;
    public static bool thing = true;
    private Color32 previousEnvironmentalColor;

    void Start() {
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        setFlatRenderColor(environmentalColor);
        // saving the previous environmental color \\
        previousEnvironmentalColor = environmentalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            StartCoroutine("fadeToDark");
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            StartCoroutine("fadeToLight");
        }
        
    }

    // changes the setting to dark to allow lumen to work \\
    public IEnumerator fadeToDark() {
        int redColorDiff = environmentalColor.r - darknessColor.r;
        int greColorDiff = environmentalColor.g - darknessColor.g;
        int bluColorDiff = environmentalColor.b - darknessColor.b;

        for (int i = 0; i < 255; i++) {
            if (environmentalColor.r > 0) {
                environmentalColor.r -= 1;
            }
            if (environmentalColor.g > 0) {
                environmentalColor.g -= 1;
            }
            if (environmentalColor.b > 0) {
                environmentalColor.b -= 1;
            }
            setFlatRenderColor(environmentalColor);
            yield return null;
        }
    }

    // changes the setting to light for the rest of the game \\
    public IEnumerator fadeToLight() {
        int redColorDiff = previousEnvironmentalColor.r - environmentalColor.r;
        int greColorDiff = previousEnvironmentalColor.g - environmentalColor.g;
        int bluColorDiff = previousEnvironmentalColor.b - environmentalColor.b;

        for (int i = 0; i < 255; i++) {
            if (environmentalColor.r < previousEnvironmentalColor.r) {
                environmentalColor.r += 1;
            }
            if (environmentalColor.g < previousEnvironmentalColor.g) {
                environmentalColor.g += 1;
            }
            if (environmentalColor.b  < previousEnvironmentalColor.b) {
                environmentalColor.b += 1;
            }
            setFlatRenderColor(environmentalColor);
            yield return null;
        }
    }

    void setRenderColor(Color32 color) {
        RenderSettings.ambientSkyColor = color;
        RenderSettings.ambientEquatorColor = color;
        RenderSettings.ambientGroundColor = color;
    }

    void setFlatRenderColor(Color32 color) {
        RenderSettings.ambientLight = color;
    }

}

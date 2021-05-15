using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logoScript : MonoBehaviour
{
    // variables \\
    public Image image;
    private GameObject trigger;
    public bool happened = false;
    private bool coroutineFinished = false;

    // get the image component \\
    void Start() {
        image = GetComponent<Image>();
        trigger = GameObject.Find("Fade Out Trigger");
    }

    // every late update, check for the player collision with FadeOut script \\
    void LateUpdate() {
        // fade in the logo
        if (fadeTrigger.entered && endTrigger.end) {
            StartCoroutine("fadeLogoIn");
        }
        // when the logo is done fading in, quit the game
        if (coroutineFinished) {
            StartCoroutine("wait");
            Application.Quit();
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(5);
    }

    // fade in the logo \\
    IEnumerator fadeLogoIn() {
        for (int i = 0; i < 100; i++) {
            Color temp = image.color;
            temp.a += 0.01f;
            image.color = temp;
            yield return new WaitForSeconds(0.5f);
        }
        coroutineFinished = true;
    }
}

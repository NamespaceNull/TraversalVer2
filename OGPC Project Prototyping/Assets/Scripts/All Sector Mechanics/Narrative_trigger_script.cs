using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Narrative_trigger_script : MonoBehaviour
{

    // messages
    bool dirIsX;
    public string posMessage; // for if values are up or right
    public string negMessage; // for if values are down or left

    public void GetTriggerAction(Vector2 vel)
    {
        string message;
        float val = dirIsX ? vel.x : vel.y;
        if (val < 0) message = posMessage;
        else if (val > 0) message = negMessage;
        else message = "";
        GetComponent<TextMeshPro>().text = message;
    }
}

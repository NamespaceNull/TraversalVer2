using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Narrative_trigger_script : MonoBehaviour
{
    private GameObject player;

    public bool fromAbove;
    public bool fromBelow;
    public bool fromTheLeft;
    public bool fromTheRight;

    private int directionX;
    private int directionY;

    // messages
    public string topLeft;
    public string topRight;
    public string bottomLeft;
    public string bottomRight;
    public string top;
    public string bottom;
    public string left;
    public string right;

    // This will most likely be replaced with a reference to the isBroken map condition
    [HideInInspector]
    public bool broken = false;

   // [HideInInspector]
    public bool enter;

    private int a;

    void Start()
    {
     
        player = GameObject.Find("Player");

    }

    public void GetTriggerAction(Vector2 vel)
    {
        // start directions
        fromAbove = false;
        fromBelow = false;
        fromTheRight = false;
        fromTheLeft = false;
        if (!broken)
        {
            // Set directions with values, and set enter based on whether the trigger worked
            enter = true;
            if (vel.y < 0) fromAbove = true;
            else if (vel.y > 0) fromBelow = true;
            else enter = false;
            if (vel.x > 0)
            {
                fromTheLeft = true;
                enter = true;
            }
            else if (vel.x < 0)
            {
                fromTheRight = true;
                enter = true;

            }

            if (enter)
            {
                // Set text
                if (fromTheLeft)
                {
                    if (fromAbove)
                    {
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(topLeft);

                    }
                    else if (fromBelow)
                    {
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(bottomLeft);
                    }
                    else
                    {
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(left);
                    }
                }
                else if (fromTheRight)
                {
                    if (fromAbove)
                    {
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(topRight);
                    }
                    else if (fromBelow)
                    {
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(bottomRight);
                    }
                    else
                    {
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(right);
                    }
                }
                else if (fromAbove)
                {
                    TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                    componentTMP.SetText(top);
                }
                else if (fromBelow)
                {
                    TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                    componentTMP.SetText(bottom);
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        enter = false;
    }

    
}

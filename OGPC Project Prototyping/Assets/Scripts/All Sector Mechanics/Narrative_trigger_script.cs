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
                Debug.Log("fromLeft");
            }
            else if (vel.x < 0)
            {
                fromTheRight = true;
                enter = true;
                Debug.Log("from right");

            }

            if (enter)
            {
                Debug.Log("enter = true " + vel.ToString());
                // Set text
                if (fromTheLeft)
                {
                    if (fromAbove)
                    {
                        Debug.Log("LA");
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(topLeft);

                    }
                    else if (fromBelow)
                    {
                        Debug.Log("LB");
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(bottomLeft);
                    }
                    else
                    {
                        Debug.Log("L");
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(left);
                    }
                }
                else if (fromTheRight)
                {
                    if (fromAbove)
                    {
                        Debug.Log("RA");
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(topRight);
                    }
                    else if (fromBelow)
                    {
                        Debug.Log("RB");
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(bottomRight);
                    }
                    else
                    {
                        Debug.Log("R");
                        TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                        componentTMP.SetText(right);
                    }
                }
                else if (fromAbove)
                {
                    Debug.Log("A");
                    TextMeshPro componentTMP = GetComponent<TextMeshPro>();
                    componentTMP.SetText(top);
                }
                else if (fromBelow)
                {
                    Debug.Log("B");
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

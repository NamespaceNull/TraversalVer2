using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port2D : MonoBehaviour
{
    public Material openMat;
    public Material closedMat;
    public Transform player;
    private MeshRenderer rend;
    public int minDis = 2; // make sure that minDis is the objects x.Scale + 1
    // if true, the port allows entry to the right. false, the port allows entry to the left
    public bool allowEntry = true;

    void Start() {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the port allows entry from the right \\
        if (allowEntry) {
            // if the player is to the right, turn off collision \\
            if (player.transform.position.x > gameObject.transform.position.x) {
                rend.material = openMat;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            // once the player is out, turn back on collision \\
            else if (player.transform.position.x < gameObject.transform.position.x - minDis) {
                rend.material = closedMat;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            }
        }
        // if the port allows entry from the left \\
        else {
            // if the player is to the left, turn off collision \\
            if (player.transform.position.x < gameObject.transform.position.x) {
                rend.material = openMat;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            // once the player is out, turn back on collision \\
            else if (player.transform.position.x > gameObject.transform.position.x + minDis) {
                rend.material = closedMat;
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            }
        }
    }
}

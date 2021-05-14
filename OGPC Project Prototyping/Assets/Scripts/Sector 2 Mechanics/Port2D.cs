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
    public bool allowEntryRight = true;
    public bool horizontalPort = false;
    public bool allowEntryTop = false;

    // get the mesh renderer of the player \\
    void Start() {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if not a horizontal port \\
        if (!horizontalPort) {
            // if the port allows entry from the right \\
            if (allowEntryRight) {
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
        // if a horizontal port \\
        else {
            // port allows entry from the top \\
            if (allowEntryTop) {
                // if the player is above, turn off collision 
                if (player.transform.position.y > gameObject.transform.position.y) {
                    rend.material = openMat;
                    Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                }
                // if the player is below, turn on collision
                else if (player.transform.position.y < gameObject.transform.position.y - minDis) {
                    rend.material = closedMat;
                    Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
                }
            }
            // if the port allows entry from the bottom \\
            else {
                // if the player is below, turn off collision
                if (player.transform.position.y < gameObject.transform.position.y) {
                    rend.material = openMat;
                    Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                }
                // if the player is above, turn off collision
                else if (player.transform.position.y > gameObject.transform.position.y + minDis) {
                    rend.material = closedMat;
                    Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
                }
            }
        }
    }
}

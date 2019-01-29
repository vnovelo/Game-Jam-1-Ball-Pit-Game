using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadManager : MonoBehaviour
{

    public int jumpHeight;
    private void OnCollisionEnter(Collision other)
    {
        //Causes the player to jump up to a certain height when stepping on the jump pad
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Rigidbody>
                ().AddForce(Vector3.up * jumpHeight);
        }
    }
}

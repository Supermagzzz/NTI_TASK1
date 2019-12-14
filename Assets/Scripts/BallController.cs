using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Vector3 velocity;

    private bool canMove = false;
    private Rigidbody rb;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Pause() {
        if (canMove) {
            canMove = false;
            velocity = rb.velocity;
            rb.velocity = Vector3.zero;
        }
    }

    public void Resume() {
        if (!canMove) {
            canMove = true;
            rb.velocity = velocity;
        }
    }

    public Vector3 getVelocity() {
        return (canMove ? rb.velocity : velocity);
    }

    public void setVelocity(Vector3 v) {
        velocity = v;
    }
}

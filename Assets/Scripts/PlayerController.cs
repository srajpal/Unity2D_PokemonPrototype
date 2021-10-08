using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;
    private Vector2 input;

    private void Update() {
        if (!isMoving) {
            // Input.x = Input.GetAxis("Horizontal");
            // Input.y = Input.GetAxis("Vertical");
        }
    }
}

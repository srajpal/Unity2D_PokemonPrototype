using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;
    private Vector2 input;

    private void Update() 
    {
        if (!isMoving) 
        {
            // get the movement for the player
            // GetAxisRaw returns -1, 0, 1
            // We do this so the player moves from one tile to the next.
            // We do not want the player moving to part of a tile.
            // This will simulate the movement in 16 bit pokemon games.
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // lets make sure we are only moving in 4 directions not 8
            // no diaganol movement
            if (input.x != 0) 
            {
                input.y = 0;
            }

            // if the player was moved
            if (input != Vector2.zero) 
            {
                // add the new movement to the current position
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                // use a coroutine to move smothely
                StartCoroutine(MovePlayer(targetPos));
            }
        }
    }

    // A Coroutine that will run over a period of time to move the player
    IEnumerator MovePlayer(Vector3 targetPos)
    {
        // while the difference between the target position and current possition is 
        // bigger than a very small value move towards the new position
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            isMoving = true;

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null; // wait for the next update to be called, then continue execution
        }

        transform.position = targetPos;

        isMoving = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectLayer;

    private bool isMoving;
    private Vector2 input;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                // add the new movement to the current position
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                {
                    // use a coroutine to move smothely
                    StartCoroutine(MovePlayer(targetPos));
                }
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    // A Coroutine that will run over a period of time to move the player
    IEnumerator MovePlayer(Vector3 targetPos)
    {
        isMoving = true;

        // while the difference between the target position and current possition is 
        // bigger than a very small value move towards the new position
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
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

    // instead of adding coliders to individual tiles we have added a tilemap collider
    // to a tilemap layer. this will create solid objects that we cannot walk through. 
    // use this to check if the target location we want to go to is part of that 
    // solid object layer. return false if we cannot walk on the next tile.
    private bool IsWalkable(Vector3 targetPos) 
    {
        // you can make the radius even smaller if you want the player to appear over 
        // some of the tiles
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectLayer) != null)
        {
            return false;
        }
        return true;
    }
}

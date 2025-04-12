using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    private Vector3 lastMoveDir;
    private void Awake()
    {

    }


    private void Update()
    {
        HandleMovement();
        HandleDash();

    }

    private void HandleMovement()
    {
        float speed = 4f;
        float moveX = 0f;
        float moveY = 0f;



        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        bool isIdle = moveX == 0f && moveY == 0f;
        if (isIdle)
        {

        }
        else
        {
            Vector3 moveDir = new Vector3(moveX, moveY).normalized;


            if (TryMove(moveDir, speed * Time.deltaTime))
            {

            }
            else
            {

            }


        }


    }





    private bool CanMove(Vector3 dir, float distance)
    {
        return Physics2D.Raycast(transform.position, dir, distance).collider == null;
    }

    private bool TryMove(Vector3 baseMoveDir, float distance)
    {
        Vector3 moveDir = baseMoveDir;
        bool canMove = CanMove(moveDir, distance);
        if (!canMove)
        {
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = CanMove(moveDir, distance);
            if (!canMove)
            {
                moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = CanMove(moveDir, distance);
            }
        }

        if (canMove)
        {
            lastMoveDir = moveDir;
            transform.position += moveDir * distance;
            return true;
        }
        else
        {
            return false;
        }


    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dashDistance = 3f;
            TryMove(lastMoveDir, dashDistance);

        }
    }
}
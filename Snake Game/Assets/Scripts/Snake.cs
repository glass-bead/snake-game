using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //[SerializeField] Rigidbody2D rBody;
    
    private Vector2 movement;

    
    // Start is called before the first frame update
    void Start()
    {
        movement = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        HandleUserInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleUserInputs()
    {
        // Only allow turning up or down while moving in the x-axis
        if (movement.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                movement = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                movement = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (movement.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movement = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                movement = Vector2.right;
            }
        }
    }

    private void Move()
    {
        float roundPosX = Mathf.Round(transform.position.x);
        float roundPosY = Mathf.Round(transform.position.y);

        transform.position = new Vector2(roundPosX + movement.x, roundPosY + movement.y);
    }
}

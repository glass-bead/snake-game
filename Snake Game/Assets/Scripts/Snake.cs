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
        float XAxis = Input.GetAxisRaw("Horizontal");
        float YAxis = Input.GetAxisRaw("Vertical");

        // Only allow turning up or down while moving in the x-axis
        if (XAxis != 0f)
        {
            movement = Vector2.right * XAxis;
        }
        // Only allow turning left or right while moving in the y-axis
        if (YAxis != 0f)
        {
            movement = Vector2.up * YAxis;
        }
    }

    private void Move()
    {
        float roundPosX = Mathf.Round(transform.position.x);
        float roundPosY = Mathf.Round(transform.position.y);

        transform.position = new Vector2(roundPosX + movement.x, roundPosY + movement.y);
    }
}

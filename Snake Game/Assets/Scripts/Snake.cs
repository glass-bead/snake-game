using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] List<Transform> tail = new List<Transform>();
    [SerializeField] GameObject tailPrefab;

    private Vector2 movement;
    private bool gameover = false;

    // Start is called before the first frame update
    void Start()
    {
        movement = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        HandleUserInputs();
    }

    private void FixedUpdate()
    {
        if (gameover == false)
        {
            UpdateTail();
            Move();
        } 
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
        float x = Mathf.Round(transform.position.x) + movement.x;
        float y = Mathf.Round(transform.position.y) + movement.y;

        transform.position = new Vector2(x, y);
    }

    private void UpdateTail()
    {
        for (int t = tail.Count - 1; t > 0; t--)
        {
            tail[t].position = tail[t - 1].position;
        }
    }

    private void GrowTail()
    {
        Transform newTail = Instantiate(tailPrefab, new Vector2(50f, 50f), Quaternion.identity).transform;
        tail.Add(newTail);
    }

    private void Stop()
    {
        gameover = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            GrowTail();
        }
        
        if (other.CompareTag("Wall") || other.CompareTag("Tail"))
        {
            Stop();
            Debug.Log("GameOver()");
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    [SerializeField] GameObject snake;
    
    private readonly int width = 24, height = 11;
    
    // Start is called before the first frame update
    void Start()
    {
        RespawnFood();
    }

    private void RespawnFood()
    {
        var position = new Vector3(Mathf.RoundToInt(Random.Range(-width, width)), Mathf.RoundToInt(Random.Range(-height, height)), 0f);

        if (position == snake.transform.position)
        {
            RespawnFood();
        }
        else
        {
            transform.position = position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RespawnFood();
    }
}

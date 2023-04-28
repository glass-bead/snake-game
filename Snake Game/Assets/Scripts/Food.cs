using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    private readonly int width = 30, height = 11;
    
    // Start is called before the first frame update
    void Start()
    {
        RespawnFood();
    }

    private void RespawnFood()
    {
        var position = new Vector2(Mathf.RoundToInt(Random.Range(-width, width)), Mathf.RoundToInt(Random.Range(-height, height)));
        transform.position = position;
    }
}

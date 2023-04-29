using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject food;
    [SerializeField] GameObject snake;

    private readonly int width = 30, height = 11;

    private void SpawnFood()
    {
        var position = new Vector3(Mathf.RoundToInt(Random.Range(-width, width)), Mathf.RoundToInt(Random.Range(-height, height)), 0f);

        if (position == snake.transform.position)
        {
            SpawnFood();
        }
        else
        {
            food.transform.position = position;
        }
    }
}

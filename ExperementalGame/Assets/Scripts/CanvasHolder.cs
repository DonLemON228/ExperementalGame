using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHolder : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] float distance;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = enemy.position + player.up * distance;
    }
}

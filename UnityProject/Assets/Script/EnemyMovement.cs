using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float turnSpeed = 180.0f;
    public float damage;

    private CharacterController controller;
    private Transform player;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);

        controller.Move(transform.forward * speed * Time.deltaTime);
    }

    
}

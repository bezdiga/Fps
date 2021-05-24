using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 20.0f;
    public float life = 5.0f;
    public float damageDealt;
    void Start()
    {
        Invoke("kill", life);
    }

    
    void FixedUpdate()
    {
        MovementRacket();
    }

    private void MovementRacket()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth health = other.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakeDamage(damageDealt);
        }
        kill();
    }

    private void kill()
    {
        Destroy(gameObject);
    }
}

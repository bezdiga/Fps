using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketLauncher : MonoBehaviour
{
    public GameObject racketPrefab;
    public Transform racketBarrel;
    public float reluadTime = 0.5f;

    private float lastFireTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }

    private void fire()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > lastFireTime + reluadTime)
        {
            GameObject go = (GameObject)Instantiate(racketPrefab, racketBarrel.position, Quaternion.LookRotation(racketBarrel.forward));
            Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
            lastFireTime = Time.time;
        }
        
    }
}

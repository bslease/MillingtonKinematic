using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSeeker : MonoBehaviour
{
    public Transform myTarget;
    public float maxSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // move me
        Vector3 v = (myTarget.position - transform.position).normalized * maxSpeed;
        transform.position += v * Time.deltaTime;

        // face my target
        transform.LookAt(myTarget);
    }
}

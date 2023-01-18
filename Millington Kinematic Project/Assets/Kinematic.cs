//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    Vector3 velocity;
    float rotation;

    private KinematicSeek mySteering;
    public Transform myTarget;
    public float myMaxSpeed = 5f;

    private void Start()
    {
        mySteering = new KinematicSeek();
        mySteering.target = myTarget;
        mySteering.character = this.transform;
        mySteering.maxSpeed = myMaxSpeed;
    }

    private void KinematicUpdate(KinematicSteeringOutput steering, float time)
    {
        // Millington's Update on p.49 looks like this:

        //// Update the position and orientation
        //transform.position += velocity * time;
        //transform.rotation += rotation * time;

        //// and the velocity and rotation
        //velocity += steering.velocity * time;
        //rotation += steering.rotation * time;

        // note that he's taking existing velocity into account
        // rather than instantly changing it
        // he's also setting rotation directly in Kinematic seek, so we don't
        // need to also do it here
        // in the end, we only need to do two things here:
        // update the velocity and update the position based on it
        // try comparing the two ways to handle velocity changes
        velocity += steering.velocity * time;   // <- Millington
        //velocity = steering.velocity;           // <- simple seeker
        transform.position += velocity * time;
    }

    private void Update()
    {
        KinematicSteeringOutput steering = mySteering.getSteering();
        KinematicUpdate(steering, Time.deltaTime);
    }
}

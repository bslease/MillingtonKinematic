//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

// Millington p.48
public class SteeringOutput
{
    public Vector3 linear; // linear acceleration
    public float angular;  // angular accelaration

    // Note: this is Millington's structure for encapsulating
    // accelerations for use in a dynamic steering situation
    // where you want to simulate something like Asteroids
    // instead of say PacMan
}

// Millington p.52
public class KinematicSteeringOutput
{
    public Vector3 velocity; // an actual speed, not an acceleration
    public float rotation;   // an amount to actually rotate, not an angular acceleration

    // Note: this is Millington's structure for encapsulating
    // amounts that are meant to be applied directly to an object's
    // movement and spin rather than indirectly through accelerations
    // like in the SteeringOutput class
}

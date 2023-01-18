using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Millington p. 52
public class KinematicSeek
{
    // public Static character;
    // public Static target;
    // Millington's "Static" class is just an object that has
    // a position and an orientation
    // we will instead get these from Unity's Transform component
    // which all game objects in Unity have
    public Transform character;
    public Transform target;

    public float maxSpeed;

   //  based on Millington p. 44
    public KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        // Get the direction to the target
        result.velocity = target.position - character.position;

        // The velocity is along this direction, at full speed
        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        // Face in the direction we want to move
        // Millington has:
        // character.orientation = newOrientation(character.orientation, result.velocity)
        float targetAngle = newOrientation(character.rotation.eulerAngles.y, result.velocity);
        character.eulerAngles = new Vector3(0, targetAngle, 0);

        result.rotation = 0;
        return result;
    }

    // Millington p. 51
    private float newOrientation(float current, Vector3 velocity)
    {
        // Make sure we have a velocity.
        if (velocity.magnitude > 0) // Millington: "if velocity.length() > 0:"
        {
            // Calculate oreintation from the velocity
            // Millington has "return atan2(-static.x, static.z) because he assumes a left-hand system
            // see formulae on pages 47 vs. 46

            float targetAngle = Mathf.Atan2(velocity.x, velocity.z);
            // The above calculated radians. We prefer degrees, so convert:
            targetAngle *= Mathf.Rad2Deg;
            return targetAngle;
        }
        else
        {
            return current;
        }
    }

    void Update()
    {
        getSteering();
    }
}

using UnityEngine;

public class MillingtonsKinematic
{
    // Millington p. 48
    Vector3 position;
    float orientation;
    Vector3 velocity;
    float rotation;

    // Millington p. 49
    private void Update(SteeringOutput steering, float time)
    {
        // Update the position and orientation
        position += velocity * time;
        orientation += rotation * time;

        // and the velocity and rotation
        velocity += steering.linear * time;
        rotation += steering.angular * time;
    }
}

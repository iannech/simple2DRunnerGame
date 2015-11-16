using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    public Transform target;

    private float trackSpeed = 10f;

    public void setTarget(Transform t)
    {
        target = t;
    }

	
	// after player starts moving
	void LateUpdate () {
           
        if (target)
        {
            float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
            float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    // Increase n towards target speed
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            // check which direction must current speed be incremented to get to the target speed.
            float dir = Mathf.Sign(target - n); // n must be increased or decreased to get closer to target.
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n) ? n : target); // if n has passed the target, return the target. Otherwise return n.

        }
    }
}

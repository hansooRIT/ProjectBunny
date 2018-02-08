using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour {

    //Vectors for force movement
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 direction;
    public Vector3 position;

    //Variables for forces calculations
    public float seekingWeight;
    public float maximumForce;

    //Floats for force movement
    public float mass;

    //Max speed of the vehicle
    public float maxSpeed;

    //Size of the vehicle for collision checks
    public float radius;

    //Speed and circle size for wandering
    public float wanderWeight;
    public float wanderRadius;

    //Timestamps for perlin noise for wandering.
    float xTimestamp;
    float yTimestamp;

    //The resulting angle from the perlin noise calculation.
    public float angle;

    //The distance a vehicle will be before object avoidance kicks in.
    public float safeDist;

    //Reference to the future location of the vehicle, if it continues going in the same direction.
    public Vector3 futureLoc;

    //Circular game object for the future location debug lies.
    //private GameObject futureLocObj;
    public GameObject bunnyTarget;
    public GameObject cam;

    // Use this for initialization
    void Start () {
        //Initializes the location object as a child from the vehicle's prefab.
        //futureLocObj = transform.GetChild(0).gameObject;
        xTimestamp = Random.Range(0.0f, 500.0f);
        yTimestamp = Random.Range(0.0f, 500.0f);
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
        CalcSteeringForces();
        //SetTransform();
    }

    /// <summary>
    /// UpdatePosition
    /// Recalculates the velocity and resulting position based on any forces.
    /// </summary>
    protected void UpdatePosition()
    {
        //Step 0: Start position at the same position as the transform component
        position = transform.position;

        //Step 1: Add acceleration vector to velocity * time to velocity.
        velocity += acceleration * Time.deltaTime;

        //Step 2: Add velocity to position
        position += velocity * Time.deltaTime;
        //gameObject.GetComponent<CharacterController>().Move(velocity * Time.deltaTime);
        position.z = 0;
        gameObject.transform.position = position;

        //Sets the vehicle's future location for the debug lines, and shows them depending on the toggle.
        //futureLocObj.transform.position = position + (velocity.normalized * 4);
        /*if (!debugOn)
        {
            futureLocObj.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            futureLocObj.GetComponent<MeshRenderer>().enabled = true;
        }*/

        //Step 3: Derive a direction from the velocity.
        direction = velocity.normalized;
        if (direction.x < 0.0)
        {
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }


        //Step 4: Reset acceleration.
        acceleration = Vector3.zero;
    }

    /// <summary>
    /// Sets transform component to the local position.
    /// </summary>
    /*protected void SetTransform()
    {
        //Set the "up" vector to this vehicle's direction.
        transform.forward = direction;
    }*/

    public void CalcSteeringForces()
    {
        //Gets a empty vector.
        Vector3 ultForce = Vector3.zero;
        //And if the zombie has a target...
        if (bunnyTarget != null)
        {
            ultForce += Seek(bunnyTarget.transform.position, seekingWeight);
        }
        if (Mathf.Abs(gameObject.transform.position.y) > cam.GetComponent<Camera>().orthographicSize - 0.5 || Mathf.Abs(gameObject.transform.position.x) > (cam.GetComponent<Camera>().orthographicSize * 2) + 1)
        {
            ultForce += Seek(new Vector3(0.0f, 0.0f, 0.0f), seekingWeight);
        }
        else
        {
            //Wander aimlessly otherwise.
            ultForce += Wander();
        }
        //Loops through each obstacle and avoids it.
        /*foreach (GameObject obstacle in obstacleList)
        {
            ultForce += ObjectAvoidance(obstacle, safeDist);
        }*/
        //Clamp the strength of the force to a maximum.
        ultForce = Vector3.ClampMagnitude(ultForce, maximumForce);
        //Then applies it.
        ApplyForce(ultForce);
    }

    /// <summary>
    /// Applies any Vector3 force to the acceleration vector.
    /// </summary>
    /// <param name="force">The force that's being applied.</param>
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    /// <summary>
    /// Makes the vehicle move towards the target position with the weight given.
    /// Higher weight = quicker speed.
    /// </summary>
    /// <param name="targetPosition">The location to move towards</param>
    /// <param name="weight">The strength of the force that will push the vehicle towards the position.</param>
    /// <returns></returns>
    protected Vector3 Seek(Vector3 targetPosition, float weight)
    {
        //Step 1: Calculate desired velocity. Vector from myself to target.
        Vector3 desiredVelocity = targetPosition - position;

        //Step 2: Scale TO maxSpeed.
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        //Step 3: Calculate resulting steering force. Head of current to head of velocity.
        Vector3 steeringForce = (desiredVelocity - velocity) * weight;
        steeringForce.z = 0;
        //Step 4: Return the steering force
        return steeringForce;
    }
    /// <summary>
    /// Causes the vehicle to flee from the given position.
    /// </summary>
    /// <param name="targetPosition">The position to flee from</param>
    /// <param name="weight">The strength of the fleeing force.</param>
    /// <returns></returns>
    protected Vector3 Flee(Vector3 targetPosition, float weight)
    {
        //Step 1: Calculate desired velocity. Vector from myself to target.
        Vector3 desiredVelocity = position - targetPosition;

        //Step 2: Scale TO maxSpeed.
        desiredVelocity = desiredVelocity.normalized * weight;

        //Step 3: Calculate resulting steering force. Head of current to head of velocity.
        Vector3 steeringForce = desiredVelocity - velocity;
        steeringForce.z = 0;
        //Step 4: Return the steering force
        return steeringForce;
    }

    /// <summary>
    /// Causes the vehicle to wander forward with slight variations.
    /// </summary>
    /// <returns>The force of the vehicle wandering to a new location.</returns>
    protected Vector3 Wander()
    {
        //Projects a circle a distance away, depending on the weight of the wandering.
        Vector3 projectedDist = position + (direction * (wanderWeight / 5));
        //Then uses perlin noise to determine an angle for the point to lie on the projected circle.
        angle = Mathf.PerlinNoise(xTimestamp, yTimestamp) * 360;
        xTimestamp += 0.0003f;
        yTimestamp += 0.0003f;
        Vector3 wanderLoc = new Vector3(projectedDist.x + (Mathf.Cos(angle) * wanderRadius), projectedDist.y + (Mathf.Sin(angle) * wanderRadius), 0);
        //Then the vehicle seeks towards the new point.
        return Seek(wanderLoc, wanderWeight);
    }

    /// <summary>
    /// Script to allow the vehicle to avoid and move around obstacles.
    /// </summary>
    /// <param name="obstacle">The obstacle to avoid</param>
    /// <param name="safeDistance">The distance at which an obstacle starts becoming noticed by the vehicle.</param>
    /// <returns>The desired force for the vehicle to move away from the obstacle that's blocking it's way.</returns>
    protected Vector3 ObjectAvoidance(GameObject obstacle, float safeDistance)
    {
        //Gets distance from vehicle to obstacle.
        Vector3 localToObstacle = obstacle.transform.position - position;
        //If the obstacle is within the vehicle's safe distance
        if (localToObstacle.magnitude - (radius + obstacle.GetComponent<CapsuleCollider>().radius) < safeDistance)
        {
            //And it's currently in front of the vehicle.
            if (Vector3.Dot(localToObstacle, transform.forward) > 0)
            {
                //And the obstacle is right in front of the vehicle.
                float rightProjection = Vector3.Dot(localToObstacle, transform.right);
                if (Mathf.Abs(rightProjection) < (radius + obstacle.GetComponent<CapsuleCollider>().radius))
                {
                    //Move to the left or right of the object, depending on the dot product.
                    if (rightProjection < 0)
                    {
                        Vector3 desiredVelocity = transform.right * maxSpeed;
                        return desiredVelocity - velocity;
                    }
                    else
                    {
                        Vector3 desiredVelocity = -transform.right * maxSpeed;
                        return desiredVelocity - velocity;
                    }
                }
            }
        }
        return Vector3.zero;
    }

    /// <summary>
    /// Calculates the vehicle's future position, assuming it will continue moving in the same direction.
    /// </summary>
    /// <returns>The vehicle's future position as a vector3.</returns>
    public Vector3 CalcFutureLoc()
    {
        return position + (velocity.normalized * 4);
    }
}

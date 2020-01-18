using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScriptWithBetterCalculations : MonoBehaviour
{
    public GameObject sun;
    private Vector3 sunPosition;
	public GameObject planet;
    private Vector3 planetPosition;
	public Rigidbody planetRigidbody;
	private float planetMass = 10000.0f;
	private float sunMass = 100000000000.0f;
	Vector3 startVelocity=new Vector3 (0f,5f,0f);

	Vector3 originalPosition;
	Vector3 newPosition;
	Vector3 velocity;
	Vector3 acceleration;

	// Use this for initialization
	void Start () {
        //Set velocity to intial velocity
        velocity=startVelocity;
	}
    
	void FixedUpdate () {
        //The time interval we calculate the position change for
		float time = 0.001f;
        //Position of the planet before it's moved
		originalPosition = planet.transform.position;
        //Acceleration of the planet is the force diveded by the mass
        //F=ma so a=F/m
        acceleration = (calculateForce()/planetMass);
        //d=vt+0.5at^2
        //Distance = velocity * time + half the acceleration * time squared
        planet.transform.position+=(velocity*time+0.5f*acceleration*time*time);
        //Set the new position of the planet to newPosition
		newPosition = planet.transform.position;
        //Recalculate velocity
        //Velocity = distance / time
        //Distance = new position - original position
		velocity = (newPosition - originalPosition) / time;	
	}

	public Vector3 calculateForce(){
        //Find the positions of the objects
		sunPosition = sun.transform.position;
        planetPosition = planet.transform.position;
        //Distance between the objects (r)
		float distance = Vector3.Distance (sunPosition, planetPosition);
        //Gravitational Constant (G)
        float G = 6.67f*Mathf.Pow(10,-11);
        //A = G*m* / r^2
        float force = G*sunMass*planetMass / distance*distance;
        //Turn the force from just a value into a 3D vector with direction
        Vector3 forceWithDirection = (force*(sunPosition-planetPosition));
        //Return Force
		return (forceWithDirection);
	}

}

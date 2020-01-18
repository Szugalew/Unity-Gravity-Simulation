using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public GameObject sun;
    private Vector3 sunPosition;
	public GameObject planet;
    private Vector3 planetPosition;
	public Rigidbody planetRigidbody;
	private float planetMass = 10.0f;
	private float sunMass = 1000000000.0f;
	Vector3 startVelocity=new Vector3 (0f,20f,0f);

	// Use this for initialization
	void Start () {
		//Make the planet move
        planetRigidbody.AddForce (startVelocity, ForceMode.VelocityChange);
	}

	void FixedUpdate () {
        //Calculate and add the force of gravity to the planet
		planetRigidbody.AddForce (calculateForce(), ForceMode.Impulse);	
	}

	public Vector3 calculateForce(){
        //Find the positions of the objects
		sunPosition = sun.transform.position;
        planetPosition = planet.transform.position;
        //Distance between the objects (r)
		float distance = Vector3.Distance (sunPosition, planetPosition);
        //Distance squared (r^2)
        float distanceSquared = distance*distance;
        //Gravitational Constant (G)
        float G = 6.67f*Mathf.Pow(10,-11);
        //F = G*m*m / r^2
        float force = G*sunMass*planetMass / distanceSquared;
        //Turn the force from just a value into a 3D vector with direction
        Vector3 forceWithDirection = (force*(sunPosition-planetPosition));
        //Return Force
		return (forceWithDirection);
	}

}


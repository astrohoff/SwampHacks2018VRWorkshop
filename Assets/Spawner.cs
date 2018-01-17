using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // Radius of the sphere on which asteroids spawn.
    public float spawnRadius;
    // Radius of the sphere on which asteroid target directions are generated.
    // (Larger radius will make asteroids pass farther from center.)
    public float targetRadius;
    // How often asteroids spawn.
    public float spawnTime;
    // The asteroid object that is cloned to spawn the asteroids.
    public GameObject spawnObject;
    // Speed of the asteroids.
    public float speed;
    // Rotational speed of the asteroids.
    public float angularSpeed;

    // How long it has been since we last spawned a new asteroid.
    float timeSinceSpawn;
	
	// Update is called once per frame
	void Update () {
        // Check if it's time to spawn a new asteroid.
        if (timeSinceSpawn > spawnTime)
        {
            // Spawn a new asteroid and reset the time.
            Spawn();
            timeSinceSpawn = 0;
        }
        // Add the frame time to the elapsed time to keep track of time.
        timeSinceSpawn += Time.deltaTime;
	}

    // Spawn an asteroid.
    void Spawn(){
        // Calculate random spawn position on sphere around scene center.
        // Radius used  to adjust sphere size.
        Vector3 spawnPosition = Random.onUnitSphere * spawnRadius;
        // Spawn the asteroid.
        GameObject obj = Instantiate(spawnObject);
        // Move it to the random position.
        obj.transform.position = spawnPosition;
        // Calculate a random target position.
        Vector3 targetPosition = Random.onUnitSphere * spawnRadius;
        // Calculate movement direction.
        Vector3 direction = targetPosition - spawnPosition;
        // Set rigidbody velocity to give astroid speed in physics engine.
        obj.GetComponent<Rigidbody>().velocity = direction * speed;
        // Calcuate and assign random rotational velocity.
        Vector3 rotation = Random.onUnitSphere * angularSpeed;
        obj.GetComponent<Rigidbody>().angularVelocity = rotation;
    }
}

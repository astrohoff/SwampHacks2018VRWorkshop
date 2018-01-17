using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    // Called by physics engine when objects collide.
    void OnCollisionEnter(Collision c){
        // If the asteroid collided with the player.
        if (c.collider.tag == "Player")
        {
            // Destroy the asteroid (because it has been collected).
            Destroy(gameObject);
        }
    }
}

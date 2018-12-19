using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    [SerializeField]
    private Rigidbody rd;
	// Use this for initialization
	void Awake() {
        rd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        var force = col.relativeVelocity * rd.mass;
            if (force.magnitude > 10.0f)
            {
            Renderer rend = this.GetComponent<Renderer>();
            ParticleSystem tempPS = this.GetComponent<ParticleSystem>();
            tempPS.Stop();
            rend.enabled = false;
            }

       // print(force.magnitude);

        
    }
}

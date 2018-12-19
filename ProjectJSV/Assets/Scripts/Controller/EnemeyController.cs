using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyController : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Rigidbody rd;
    private int numHits = 3;
    int currentHits = 0;

    public UnityEngine.AI.NavMeshAgent agent;
    void Awake()
    {
        rd = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(player.transform.position);
        if (rd.velocity != Vector3.zero) { rd.velocity = Vector3.zero; }
    }

    void OnCollisionEnter(Collision col)
    {
        var force = col.relativeVelocity * rd.mass;
        if (force.magnitude > 10.0f)
        {
           
            if (currentHits == numHits)
            {
                Destroy(this.gameObject);
            }
            ++currentHits;
        }

    }
}

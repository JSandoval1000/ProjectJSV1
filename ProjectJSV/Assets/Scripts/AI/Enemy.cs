using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private Rigidbody rd;
    [SerializeField]
    private Rigidbody player;
    // Use this for initialization
    void Awake()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(player.transform);
        transform.position += transform.forward * 2 * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        var force = col.relativeVelocity * rd.mass;
        if (force.magnitude > 10.0f)
        {
            Destroy(this.gameObject);
        }



    }

}

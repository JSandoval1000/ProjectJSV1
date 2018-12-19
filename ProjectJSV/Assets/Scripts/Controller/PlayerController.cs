using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private Vector3 playerPos = Vector3.zero;
    [SerializeField]
    private Material[] materialList;
    [SerializeField]
    private GameObject reticle;
    [SerializeField]
    private GameObject projectile;
    private Rigidbody rd;
    private MeshRenderer mesh;
    private const float slowDownConst = 10;
    private bool firePrimaryIsPressed = false;
    static int playerNum = 0;
    string horizontal;
    string vertical;
    string aimX, aimY,primaryFire;
    // Use this for initialization
    void Start () {
        playerPos = transform.position;
        ++playerNum;
        horizontal = "Horizontal" + playerNum;
        vertical = "Vertical" + playerNum;
        aimX = "Mouse X" + playerNum;
        aimY = "Mouse Y" + playerNum;
        primaryFire = "Fire1" + playerNum;
        mesh = GetComponent<MeshRenderer>();
        rd = GetComponent<Rigidbody>();
        mesh.material = materialList[playerNum - 1];
        reticle = Instantiate(reticle,transform);
    }
	
	// Update is called once per frame
	void FixedUpdate() {

        //Player Movement
          var playerPos = new Vector3(Input.GetAxis(horizontal), 0, Input.GetAxis(vertical));
     
          if((Input.GetAxis(horizontal) <= 0.05f && Input.GetAxis(horizontal) >= -0.05f) && !(Input.GetAxis(vertical) <= 0.05f && Input.GetAxis(vertical) >= -0.05f))
        {
            rd.drag = 0.0f;
            rd.AddForce(playerPos * 2000 * Time.deltaTime);
        }
        else
        {
            rd.drag = 0.4f;
            rd.AddForce(playerPos * 1000 * Time.deltaTime);
        }

        //Aiming Reticle
        reticle.transform.localPosition = Vector3.zero;
        var reticlePos = new Vector3(Input.GetAxis(aimX),0.0f, Input.GetAxis(aimY));
        var aimDir = new Vector3(reticlePos.x, 0.0f, reticlePos.z).normalized;
        var aimDirRaw = aimDir;
        aimDir = transform.rotation * aimDir;
        //var aimAngle = Mathf.Atan2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        reticle.transform.localPosition = new Vector3(aimDir.x, 0.0f, aimDir.z);
        reticle.transform.LookAt(transform.position);

        //Shooting Primary
        if (Input.GetAxisRaw(primaryFire) != 0)
        {
            if (firePrimaryIsPressed == false)
            {
                Fire(aimDir);
                firePrimaryIsPressed = true;
            }
        }
        if (Input.GetAxisRaw(primaryFire) == 0)
        {
            firePrimaryIsPressed = false;
        }

    }
    void Fire(Vector3 aimDirRaw)
    {
        // Create the Bullet from the Bullet Prefab
        GameObject proj = Instantiate(projectile);
        proj.transform.position = reticle.transform.position;
        proj.transform.LookAt(transform.position);

        // Add velocity to the bullet
        proj.GetComponent<Rigidbody>().velocity = -reticle.transform.forward * 12;

        // Destroy the bullet after 2 seconds  
        Destroy(proj, 2.0f);
       
    }

   
}

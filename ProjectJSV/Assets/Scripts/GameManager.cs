using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private GameObject player;
	// Use this for initialization
	void Start () {
        GameObject currGameObject;
		for(int i = 0; i < Input.GetJoystickNames().Length; ++i)
        {
            if (Input.GetJoystickNames()[i] != "")
            {
                currGameObject = Instantiate(player, this.transform);
                currGameObject.transform.position = new Vector3(0.0f, 0.0f, i);
            }
        }

        print("Length = " + Input.GetJoystickNames().Length);
        print("Name1 = " + Input.GetJoystickNames()[0]);
        print("Name2 = " + Input.GetJoystickNames()[1]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

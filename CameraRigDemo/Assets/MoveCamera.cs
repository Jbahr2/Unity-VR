using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Vector3[] Positions;

    private GameObject playerObj = null;
    private GameObject house1 = null;
    private GameObject house2 = null;
    public Vector3 pos = new Vector3(0.0f,0.0f,-9.460979f);
    public float Speed = 2.0f;
	void Start()
    {

        if (playerObj == null)
            playerObj = GameObject.Find("VRCamera");
        if (house1 == null)
            house1 = GameObject.Find("House fix");
        if (house2 == null)
            house2 = GameObject.Find("House-9-2");
    }
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = playerObj.transform.position + new Vector3(0.0f,0.0f,0.0f);
        transform.position = Vector3.Lerp(transform.position, currentPos, Speed * Time.deltaTime);
        transform.rotation = playerObj.transform.rotation;
    }
}

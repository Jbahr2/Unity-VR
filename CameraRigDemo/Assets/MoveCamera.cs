using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Vector3[] Positions;

    private GameObject playerObj = null;
    private GameObject house1 = null;
    private GameObject house2 = null;
    private int mCurrentIndex = 0, dist;
    public Vector3 pos = 
    public float Speed = 2.0f;
	void Start()
    {

        if (playerObj == null)
            playerObj = GameObject.Find("Player");
        if (house1 == null)
            house1 = GameObjecct.Find("House fix");
        if (house2 == null)
            house2 = GameObjecct.Find("House-9-2");
        dist = house1.transform.position.z - house2.transform.position.z;
    }
	// Update is called once per frame
	void Update () {

        Vector3 currentPos = Positions[mCurrentIndex];

        transform.position = Vector3.Lerp(transform.position, currentPos, Speed * Time.deltaTime);

    }
}

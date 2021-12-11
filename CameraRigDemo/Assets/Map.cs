using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    // Start is called before the first frame update
    void Start()
    {
         left = GameObject.Find("Left Plane");
        right = GameObject.Find("Right Plane");
        left.SetActive(false);
        right.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (right.activeSelf == true)
            {
                left.SetActive(false);
                right.SetActive(false);
            }
            else if(right.activeSelf == false)
            {
                right.SetActive(true);
                left.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public int update = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Changes the position to x:1, y:1, z:0
        transform.position = new Vector3(15.984f, 0.51f, 1.018f);
 // It is also possible to set the position with a Vector2
 // This automatically sets the Z axis to 0
        //transform.position = new Vector2(1, 1);
 // Moving object on a single axis
        Vector3 newPosition = transform.position; // We store the current position
        newPosition.y = 0.51f; // We set a axis, in this case the y axis
        transform.position = newPosition; // We pass it back
    }

    // Update is called once per frame
    void Update()
    {
         transform.position += new Vector3(0 , update , 0);
         update = (update + 1) % 20;
    }
}

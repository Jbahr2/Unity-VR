using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float update = 0;
    private bool direction = false;
    // Start is called before the first frame update
    void Start()
    {
        // Changes the position to x:1, y:1, z:0
       // transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y);
 // It is also possible to set the position with a Vector2
 // This automatically sets the Z axis to 0
        //transform.position = new Vector2(1, 1);
 // Moving object on a single axis
        //Vector3 newPosition = transform.position; // We store the current position
       // newPosition.y = 0.51f; // We set a axis, in this case the y axis
        //transform.position = newPosition; // We pass it back
    }

    // Update is called once per frame
    void Update()
    {
        if (update <= 0f)
            direction = false;
        if (update >= .01f)
            direction = true;

         transform.position = new Vector3(this.transform.position.x, .5f + update , this.transform.position.z);

         if(direction == false)
         update = (update + .0002f);
         if(direction == true)
         update = (update - .0002f);
    }
}

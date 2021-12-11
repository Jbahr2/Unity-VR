using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class manipulationRayCast_: MonoBehaviour {
	public List<GameObject> selectedObjects = new List<GameObject>();
	public RaycastHit prevHit; 
	public bool prev;
public float xx = 15.0f;
public float yy = 15.0f;
    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 mOffset2;
    private float mZCoord2;
    public CharacterController controller;
    // Use this for initialization
    void Start()
	{
		LineRenderer ray = gameObject.AddComponent<LineRenderer>();

		//Find the Specular shader and change its Color to red

		ray.SetPosition(0, transform.localPosition);
		ray.SetPosition(1, transform.forward * 10f);

		ray.SetPosition(0, transform.forward + transform.position + new Vector3(0.0f, -10.0f, 0.0f));
		//ray.SetPosition (0, transform.forward+transform.position);//new Vector3(0f,0f,0.001f));\
		ray.SetPosition(1, transform.forward + transform.position * 10f);



		ray.enabled = true;
		ray.SetWidth(0.0f, 0.5f);
		prev = false;



	}
    void mouseRayCast()
    {
        //for joystick button, replace mousedown for Input. command for button.
        //for vive use the transform.forward for the joystick controller. 

        LineRenderer ray = GetComponent<LineRenderer>();

        Vector3 p = new Vector3(0f, -2f, 0f);
        ray.SetPosition(0, GameObject.Find("Knight").transform.position + new Vector3(0.25f, 0.25f, 0f));
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.x = 2f;
        ray.SetPosition(1, Camera.main.ScreenPointToRay(Input.mousePosition).direction + Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100f);
        ray.SetWidth(0.1f, 0.5f);

        if (Input.GetMouseButtonDown(0))
        {
            bool objHit = false;
            RaycastHit raycastHit = new RaycastHit();


            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit) && raycastHit.transform.tag == "Hit")
            {
        
                if (prev == true)
                {
                    prev = false;
                    //Set the main Color of the Material to green

                    //Find the Specular shader and change its Color to red
                }

                print("p: " + raycastHit.collider.transform.position);
                //set previous to previous color

                //talk about where the ray comes from - start without this displaced point.
                p = new Vector3(0f, -4f, 0f);
                ray.SetPosition(0, transform.forward + transform.position);//new Vector3(0f,0f,0.001f));\
                ray.SetPosition(1, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
                prevHit = raycastHit;
                prev = true;


                //Set the main Color of the Material to green

                //Find the Specular shader and change its Color to red


                print(raycastHit.collider.tag);
            }


        }

    }
    private Vector3 GetMouseAsWorldPoint()
    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    private Vector3 GetMouseAsWorldPoint2()
    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord2;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    void manipKey(){
		float x = 0.05f;
        float y = 0.05f;
		float z = 0.05f;
        if (prev == true)
        {
            if (Input.GetMouseButton(1))
            {
                //local coordinates
                mZCoord = Camera.main.WorldToScreenPoint(prevHit.transform.position).z;
                prevHit.transform.position = GetMouseAsWorldPoint() + mOffset;
                // Store offset = gameobject world pos - mouse world pos
                mOffset = prevHit.transform.position - GetMouseAsWorldPoint();
            }
            /* 
             W = Move Object Forward
             S = Move Object Backwards
             A = Move Object Left
             D = Move Object Right
             R = Move Object Up
             E = Move Object Down
             F = Object Rotate Up
             H = Object Rotate Down
             T = Object Rotate Left
             G = Object Rotate Right
             Esc = Deselect Object
             M = Toggle Map
             Space = Teleport to Mouse Position
             Hold Right Mouse button down to move Objects.
             Arrow keys to move Character and Z and X to turn.
             */
            if (Input.GetKeyDown(KeyCode.W))
            {
                prevHit.transform.localPosition = prevHit.transform.position + new Vector3(0f, 0f, z);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {

                prevHit.transform.localPosition = prevHit.transform.position + new Vector3(0f, 0f, -z);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {

                prevHit.transform.localPosition = prevHit.transform.position + new Vector3(-x, 0f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                prevHit.transform.localPosition = prevHit.transform.position + new Vector3(x, 0f, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                prevHit.transform.localPosition = prevHit.transform.position + new Vector3(0f, y, 0f);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                prevHit.transform.localPosition = prevHit.transform.position + new Vector3(0f, -y, 0f);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                prevHit.transform.localRotation = Quaternion.Euler(0f, yy, 0f);
                yy += 15.0f;
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                prevHit.transform.localRotation = Quaternion.Euler(0f, yy, 0f);
                yy -= 15.0f;
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                prevHit.transform.localRotation = Quaternion.Euler(xx, 0f, 0f);
                xx += 15.0f;
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                prevHit.transform.localRotation = Quaternion.Euler(xx, 0f, 0f);
                xx -= 15.0f;
            }
            if (Input.GetKeyDown("escape"))
            {
                Renderer rend;
                rend = prevHit.collider.GetComponent<Renderer>();
                prev = false;
                prevHit = new RaycastHit();
                //Set the main Color of the Material to green

                //Find the Specular shader and change its Color to red
     
            }
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                controller.enabled = false;
                mZCoord2 = Camera.main.WorldToScreenPoint(Input.mousePosition).z;
                controller.transform.position = new Vector3(Camera.main.ScreenPointToRay(Input.mousePosition).direction.x + controller.transform.localPosition.x, 0f, Camera.main.ScreenPointToRay(Input.mousePosition).direction.z + controller.transform.localPosition.z);
                // Store offset = gameobject world pos - mouse world pos
                mOffset2 = controller.transform.position - GetMouseAsWorldPoint2();
                controller.enabled = true;
            }
        controller.enabled = true;
    }

	// Update is called once per frame
	void Update () {
		//mouseRayCast ();
		//mouseRayCastplusButtonSelect();  
		//manipJoystick ();
		manipKey();
	}

}




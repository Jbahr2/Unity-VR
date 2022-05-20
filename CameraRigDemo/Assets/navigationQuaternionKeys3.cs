using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class navigationQuaternionKeys3 : MonoBehaviour
{
public CharacterController controller;
public Quaternion rotTmp;
public float speed;
private Vector3 playerVelocity;
private bool groundedPlayer;
private float gravityValue = -9.81f;
private Vector3 move;
public float mouseSensitivity = 100f;
public Transform playerBody;
float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        Slope();
        Move2();
    }
    void Mouse(){
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    void Move2(){
      Quaternion yaw= Quaternion.AngleAxis(0.0f*Time.deltaTime, transform.up);
      Quaternion pitch = Quaternion.AngleAxis(0.0f*Time.deltaTime, transform.right);
      Quaternion roll = Quaternion.AngleAxis(0.0f*Time.deltaTime, transform.forward);

      float x = Input.GetAxis("Horizontal");
      float z = Input.GetAxis("Vertical");
      float rot = Input.GetAxis("lookaround");

      Vector3 moveCal = transform.right * x + transform.forward * z;
      controller.Move(moveCal * 2 *Time.deltaTime);

      GetComponent<Transform>().Rotate(Vector3.up * rot * speed);


       if(Input.GetKey(KeyCode.Z)){
         yaw= Quaternion.AngleAxis(-speed*Time.deltaTime, transform.up);
      }
      if(Input.GetKey(KeyCode.X)){
        yaw= Quaternion.AngleAxis(speed*Time.deltaTime, transform.up);
      }

      transform.rotation = roll * pitch * yaw * transform.rotation;
    }
    void Slope()
    {
      groundedPlayer = controller.isGrounded;
      if (groundedPlayer && playerVelocity.y < 0)
          playerVelocity.y = 0.0f;

      if (move != Vector3.zero)
          gameObject.transform.forward = move;

      // Changes the height position of the player..

      playerVelocity.y += gravityValue * Time.deltaTime;
      controller.Move(playerVelocity * Time.deltaTime);

}}

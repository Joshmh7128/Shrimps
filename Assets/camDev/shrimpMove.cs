using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrimpMove : MonoBehaviour
{
    Rigidbody shrimpLeg;

    float zDirection;
    float xDirection;
    float yDirection;

    [SerializeField] Transform camera;

    [SerializeField]
    float moveSpeed = 1f;
    float jumpSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        shrimpLeg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ShrimpMove();
    }

    public void ShrimpMove() 
    {
        xDirection = Input.GetAxisRaw("Horizontal"); //this is the vector3.right axis
        zDirection = Input.GetAxisRaw("Vertical");  //this is the vector3.forward axis.
        Vector3 shrimpDirection = new Vector3(xDirection * camera.right.x, yDirection, zDirection * camera.forward.z);

        if (shrimpDirection.magnitude >= 0.1f)
        {
            shrimpLeg.AddForce(shrimpDirection * moveSpeed);
        }
        else if (shrimpDirection.magnitude < 0.1f)
        {
            Vector3 vel = shrimpLeg.velocity; // current velocity
            // apply X% of velocity in the other direction
            shrimpLeg.AddForce(-vel);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // rotate right
            transform.eulerAngles += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // rotate right
            transform.eulerAngles += new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //go up.
            Vector3 shrimpJump = new Vector3(0f, 1f, 0f);
            shrimpLeg.AddForce(shrimpJump * moveSpeed);
        }
        else
        {
            float jumpVel = shrimpLeg.velocity.y;
            shrimpLeg.AddForce(0f, -jumpVel, 0f);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            //GetKeydown is only when its pressed you dumb head - Cam's note to Cam
            Vector3 shrimpDescend = new Vector3(0f, -1f, 0f);
            shrimpLeg.AddForce(shrimpDescend * moveSpeed);
        }
        else
        {
            float descendVel = shrimpLeg.velocity.y;
            shrimpLeg.AddForce(0f, -descendVel, 0f);
        }



    }
}

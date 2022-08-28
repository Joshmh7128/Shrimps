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

    [SerializeField] Vector3 shrimpDirection; // the direction we want to move in 

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
        zDirection = Input.GetAxisRaw("Vertical");  //this is the vector3.forward axis
        
            // we want to move in the direction that the camera is facing
            Vector3 rightMovement = transform.right * xDirection;
            Vector3 forwardMovement = transform.forward * zDirection;
            // apply our force in multiple directions
            shrimpLeg.AddForce(rightMovement);
            shrimpLeg.AddForce(forwardMovement);

        if (Mathf.Abs(xDirection) + Mathf.Abs(zDirection) < 0.1f)
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

    private void OnDrawGizmos()
    {
        // draw our ray
        Gizmos.DrawLine(transform.position, transform.position + (shrimpDirection * moveSpeed));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrimpMove : MonoBehaviour
{
    Rigidbody shrimpLeg;

    float zDirection;
    float xDirection;
    float yDirection;

    [SerializeField]
    float moveSpeed = 1f;

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
        Vector3 shrimpDirection = new Vector3(xDirection, 0f, zDirection).normalized;

        if (shrimpDirection.magnitude >= 0.1f)
        {
            shrimpLeg.AddForce(shrimpDirection * moveSpeed);
        }
        else if (shrimpDirection.magnitude < 0.1f)
        {
            Vector3 vel = shrimpLeg.velocity; // current velocity
            // apply X% of velocity in the other direction
            shrimpLeg.AddForce(-vel * 0.75f);
        }

    }
}

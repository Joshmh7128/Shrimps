using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform lerpTarget; // where we lerp to
    [SerializeField] float lerpSpeed, lookSpeed; // our lerp speed
    Vector3 lerpLookPos; // where we look at

    // Update is called once per frame
    void Update()
    {
        // lerp our look position
        lerpLookPos = Vector3.Lerp(lerpLookPos, player.position, lookSpeed * Time.deltaTime);

        // lerp to that position
        transform.LookAt(lerpLookPos);

        // lerp to our position
        transform.position = Vector3.Lerp(transform.position, lerpTarget.position, lerpSpeed * Time.deltaTime);
    }
}

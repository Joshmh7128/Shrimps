using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField] Transform lerpTarget; // where we lerp to
    [SerializeField] float lerpSpeed; // our lerp speed

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        transform.position = Vector3.Lerp(transform.position, lerpTarget.position, lerpSpeed * Time.deltaTime);
    }
}

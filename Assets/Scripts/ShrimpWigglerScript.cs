using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpWigglerScript : MonoBehaviour
{
    float wiggleTime = 0.25f;
    [SerializeField] float wiggleForce; // how hard do we wiggle

    // all our wiggleable arms
    [SerializeField] List<Rigidbody> wiggleArms = new List<Rigidbody>();

    private void Start()
    {
        // start the wigglestep
        StartCoroutine(WiggleStep());       
    }

    IEnumerator WiggleStep()
    {
        // run our wiggle step
        yield return new WaitForSecondsRealtime(wiggleTime);
        // run our WiggleUpdate()
        WiggleUpdate();
        // restart 
        StartCoroutine(WiggleStep());
    }

    // updates the wiggle
    void WiggleUpdate()
    {
        // wiggle the arms!
        foreach (Rigidbody arm in wiggleArms)
        {
            Vector3 rand = new Vector3(Random.Range(-wiggleForce, wiggleForce), Random.Range(-wiggleForce, wiggleForce), Random.Range(-wiggleForce, wiggleForce));
            arm.AddForce(rand, ForceMode.Impulse);
        }
    }
}

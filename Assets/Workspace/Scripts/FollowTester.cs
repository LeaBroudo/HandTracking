using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Demos;

public class FollowTester : MonoBehaviour
{
    public DummyJointFollow dummyJointFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        // FOR TESTING
        if (Input.GetKeyDown(KeyCode.S)) {
            dummyJointFollow.TurnOffJointFollow();
        }
        
    }

    void OnTriggerEnter(Collider col) {
        dummyJointFollow.TurnOnJointFollow( this.GetComponent<Rigidbody>(), col.GetComponent<Rigidbody>());
    }
}

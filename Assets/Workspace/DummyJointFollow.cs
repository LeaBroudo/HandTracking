using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

namespace RootMotion.Demos {

    public class DummyJointFollow : MonoBehaviour
    {
        [Tooltip("Board target Rigidbody.")] 
        public Rigidbody target;
        [Tooltip("Pivot Transform of the body target.")] 
        // public Transform bodyTargetPivot;
        // [Tooltip("The body target keeps the puppet upright by a SpringJoint connected to the body.")] 
        // public Transform bodyTarget;

        private Rigidbody r;

        void Start() {
            r = GetComponent<Rigidbody>();

            // Ignore collision between the board and the board target
            //Physics.IgnoreLayerCollision(gameObject.layer, target.gameObject.layer, true);
        }

        void FixedUpdate() {
            // Match Rigidbody pos/rot and velocities with the target so the Puppet's physics would not affect the board's motion.
            r.MovePosition(target.position);
            r.MoveRotation(target.rotation);

            r.velocity = target.velocity;
            r.angularVelocity = target.angularVelocity;

        }
    }
}

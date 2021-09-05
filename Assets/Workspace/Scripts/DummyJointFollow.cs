using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

namespace RootMotion.Demos {

    public class DummyJointFollow : MonoBehaviour
    {
        public Rigidbody target;
        public bool isFollowing = true;
        
        private Rigidbody r;
        private FixedJoint fixedJoint;

        void Start() {
            r = GetComponent<Rigidbody>();
            fixedJoint = GetComponent<FixedJoint>();
        }
        
        void FixedUpdate() {
            
            if (isFollowing) {
                
                this.transform.position = fixedJoint.connectedBody.transform.position;
                
                // Match Rigidbody pos/rot and velocities with the target so the Puppet's physics would not affect the board's motion.
                r.MovePosition(target.position);
                r.MoveRotation(target.rotation);

                r.velocity = target.velocity;
                r.angularVelocity = target.angularVelocity;
            }
            
        }

        public void TurnOffJointFollow() {
            target = null;
            fixedJoint.connectedBody = null;
            isFollowing = false;
        }

        public void SuspendJointFollow() {
            isFollowing = false;
        }

        public void TurnOnJointFollow(Rigidbody targetToFollow, Rigidbody joint) {
            target = targetToFollow;
            fixedJoint.connectedBody = joint;
            isFollowing = true;
        }

        public void ResumeJointFollow() {
            isFollowing = true;
        }
    }
}

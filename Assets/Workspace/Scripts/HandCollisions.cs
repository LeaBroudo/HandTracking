using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OculusSampleFramework;
using UnityEngine.UI;

[System.Serializable]

public class HandCollisions : MonoBehaviour
{

    public IndexCollisionDetector indexCollider;
    private HashSet<Collider> grabCandidates;
    
    private OVRSkeleton skeleton;
    private HandGrabber handGrabber;

    void Start() {
        
        grabCandidates = new HashSet<Collider>();
        skeleton = GetComponent<OVRSkeleton>();
        handGrabber = GetComponent<HandGrabber>();

        // Makes it so the Index collider (and others in future) don't get triggered by a hand collider
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Body"), LayerMask.NameToLayer("HandCollider"));
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("HandCollider"), LayerMask.NameToLayer("HandCollider"));

        InitializeIndexCollider();
    }

    // Update is called once per frame
    void Update()
    {
        InitializeIndexCollider();
    }

    public void InitializeIndexCollider()
    {
        if (indexCollider.handCollisions == null || indexCollider.transformToFollow == null)
        {
            // Add collider to tip of index finger
            foreach (OVRBone bone in skeleton.Bones)
            {
                if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip)
                {
                    indexCollider.SetTransformToFollow(bone.Transform);
                    indexCollider.SetCollisionCallback(this.GetComponent<HandCollisions>());
                }
            }
        }
    }

    public void AddCandidate(Collider col)
    {
        grabCandidates.Add(col);
    }
    public void RemoveCandidate(Collider col)
    {
        grabCandidates.Remove(col);
    }

}

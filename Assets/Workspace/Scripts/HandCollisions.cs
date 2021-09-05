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
                    print("1");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PokeEvent : UnityEvent<GameObject> {}

public class HandCollisions : MonoBehaviour
{
    private OVRSkeleton skeleton;

    private HandGrabber handGrabber;

    public GameObject indexColliderObj;
 
    void Start() {
        
        Physics.IgnoreLayerCollision(7, 7);

        skeleton = GetComponent<OVRSkeleton>();
        handGrabber = GetComponent<HandGrabber>();
        
        AddCollidersToHands();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCollidersToHands() {

        List<Collider> grabVolumes = new List<Collider>();

        // Add collider to tip of index finger
        foreach(OVRBone bone in skeleton.Bones) {
            if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip) {
                
                IndexCollisionDetector detector = indexColliderObj.GetComponent<IndexCollisionDetector>();
                detector.SetTransformToFollow(bone.Transform);
                detector.SetCollisionCallback(handGrabber);
            }
        }
    }
}

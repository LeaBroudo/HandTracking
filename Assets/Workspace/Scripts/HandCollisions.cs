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
        
        skeleton = GetComponent<OVRSkeleton>();
        handGrabber = GetComponent<HandGrabber>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

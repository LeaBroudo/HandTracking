using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class HandGestures : MonoBehaviour
{

    private HandPresence handPresence;
    private OVRHand hand; 
    private OVRSkeleton skeleton;

    public GameObject g1;
    public GameObject g2;

    public bool isIndexPinching;
    public bool isHandPointing;
        
    // Start is called before the first frame update
    void Start()
    {
        handPresence = GetComponent<HandPresence>();
        hand = GetComponent<OVRHand>();
        skeleton = GetComponent<OVRSkeleton>();

        isIndexPinching = false;
        isHandPointing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (hand.HandConfidence == OVRHand.TrackingConfidence.Low) { //TODO: transparency for this conditional
        if (handPresence.isHandShown()) {  
            
            CheckIndexFingerPinch();
            CheckHandPoint();

        } 
        else {
            isHandPointing = false;
            isIndexPinching = false;
        }
    }

    public void CheckIndexFingerPinch() {

        bool isIndexPinching_new = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        float indexFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        OVRHand.TrackingConfidence confidence = hand.GetFingerConfidence(OVRHand.HandFinger.Index);

        //Debug.Log(skeleton.GetSkeletonType()+"\nisIndexFingerPinching: "+isIndexPinching_new+"\nindexFingerPinchStrength: "+indexFingerPinchStrength +"\nconfidence: "+confidence);
    
        if (confidence == OVRHand.TrackingConfidence.High) {

            isIndexPinching = isIndexPinching_new;
        } 
    
    }

    public void CheckHandPoint() {

            
        //Debug.Log("Pointer Pose:" + hand.PointerPose.position);
        if (g1 != null) g1.transform.position = this.transform.position;
        if (g2 != null) g2.transform.position = this.transform.position + hand.PointerPose.forward;

        bool isHandPointing_new = hand.IsPointerPoseValid;

        if (isHandPointing_new && !isHandPointing) {
            //Debug.Log("HandPointingStarted");
        } 
        else if (!isHandPointing_new && isHandPointing) {
            //Debug.Log("HandPointingEnded");
        } 
        
        if (isHandPointing_new) {
            //Debug.Log("HandIsPointing");
        }

        isHandPointing = isHandPointing_new;
    
    }
}

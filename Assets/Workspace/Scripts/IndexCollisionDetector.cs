using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexCollisionDetector : MonoBehaviour
{

    public Transform transformToFollow;
    public ConfigurableJoint configurableJoint;
    public HandCollisions handCollisions;

    // Start is called before the first frame update
    void Start()
    {
        configurableJoint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transformToFollow != null) {
            this.transform.position = transformToFollow.position;
        }
    }

    public void SetTransformToFollow(Transform trans) {
        print("2");
        transformToFollow = trans;
    }

    public void SetCollisionCallback(HandCollisions handCols)
    {
        handCollisions = handCols;
    }

    void OnTriggerEnter(Collider otherCollider) {

        Debug.Log("Triggered!!");
        if (handCollisions) handCollisions.AddCandidate(otherCollider);
    }

    void OnTriggerExit(Collider otherCollider) {
        Debug.Log("Trigger exit!!");
        if (handCollisions) handCollisions.RemoveCandidate(otherCollider);
    }

}

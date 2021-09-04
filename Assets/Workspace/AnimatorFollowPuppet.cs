using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFollowPuppet : MonoBehaviour
{
    public Rigidbody leftFoot;
    public Rigidbody rightFoot;
    public bool isFollowing = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing) {
            this.transform.position = (leftFoot.transform.position + rightFoot.transform.position) / 2f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp_Cam : MonoBehaviour
{
    public Transform targetToFollow;

    void Update()
    {
        // Camera cant move further than the boundries of the scene
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, -36.5f, 36.5f),
            Mathf.Clamp(targetToFollow.position.y, -22f, 22f),
            transform.position.z);

    }
}

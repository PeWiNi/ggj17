using UnityEngine;
using System.Collections;

public class FollowTransform : MonoBehaviour {
    public Transform trans;
    public Vector3 displacement = new Vector3(0, -1, 0);

    void Start() {
        if (!trans) trans = transform.parent;
    }

    // Use this for initialization
    void LateUpdate() {
        if (trans) transform.position = new Vector3(trans.position.x + displacement.x, trans.position.y + displacement.y, trans.position.z + displacement.z);
    }
}

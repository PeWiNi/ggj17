using UnityEngine;
using System.Collections;

public class FollowTransform : MonoBehaviour {
    public Transform trans;
    public Vector3 displacement = new Vector3(0, -1, 0);
    public bool doCollision = true;

    void Start() {
        if (!trans) trans = transform.parent;
    }

    // Use this for initialization
    void LateUpdate() {
        if (trans) transform.position = new Vector3(trans.position.x + displacement.x, trans.position.y + displacement.y, trans.position.z + displacement.z);
    }

    void OnCollisionStay(Collision _collision) {
        if (!doCollision) return;
        bool yes = true;
        foreach (var coll in _collision.contacts) {
            if (coll.otherCollider.transform == transform.parent) {
                Debug.Log("Colliding with parent");
                displacement -= new Vector3(0, .01f, 0);
                return;
            }
            if (coll.otherCollider.tag != "Ground")
                yes = false;
        }
        if (yes) {
            Vector3 dir = _collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            displacement += .01f * dir;
        }
    }
}

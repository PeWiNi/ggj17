using UnityEngine;
using System.Collections;

public class ChaseTransform : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target) {
            float dist = Vector3.Distance(transform.position, target.transform.position);
            transform.LookAt(target.transform);
            float speed = (dist / 2) * Time.deltaTime;
            Vector3 newPos = Vector3.MoveTowards(transform.position, target.transform.position, speed);
            transform.position = newPos;
        }
    }
}

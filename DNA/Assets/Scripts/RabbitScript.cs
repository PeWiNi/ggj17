using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RabbitScript : MonoBehaviour {

    public List<Vector3> nodes;
    int currentNode;

    public float speed = 2f;
    float threshold = .0025f;

    // Use this for initialization
    void Start () {
        currentNode = 0;
    }
	
	void FixedUpdate () {
        MoveTowardsNextNode();
    }

    void MoveTowardsNextNode() {
        // Check current position and go to next node if close to currentNode
        if (CloseEnough(nodes[currentNode], threshold))
            if (++currentNode == nodes.Count)
                currentNode = 0;
        transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode], speed);
    }

    /// <summary>
    /// Checks if the distance between two Vector3s is less than a certain threshold value
    /// Tailored for determining if the boomnana has reached its "endpoint", so only accounts for x and z
    /// </summary>
    /// <param name="endpoint">Desired point which the transform is supposed to reach</param>
    /// <param name="threshold">Floating point margin of error</param>
    /// <returns></returns>
    bool CloseEnough(Vector3 endpoint, float threshold) {
        bool ret = false;
        if ((transform.position.x + threshold >= endpoint.x &&
            transform.position.x - threshold <= endpoint.x) &&
            (transform.position.z + threshold >= endpoint.z &&
            transform.position.z - threshold <= endpoint.z))
            ret = true;
        return ret;
    }
}

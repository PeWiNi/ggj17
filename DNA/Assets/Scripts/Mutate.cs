using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutate : MonoBehaviour {
    Dictionary<int, int> sequences;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    void ScaleGO(Transform go, float value) {
        value = (Mathf.Abs(value) / 10) + 1;
        if (go != null) {
            go.localScale = new Vector3(value, value, value);
        }
    }

    void GravityGO(Rigidbody go, float value) {
        value = Mathf.Abs(value) / 10;
        if (go != null)
            go.mass = value;
    }
}

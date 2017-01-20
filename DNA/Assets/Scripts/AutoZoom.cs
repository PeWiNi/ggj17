using UnityEngine;
using System.Collections;

public class AutoZoom : MonoBehaviour {


   public int modifier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GameObject[] sequences = GameObject.FindGameObjectsWithTag("sequence");

        if (sequences.Length != modifier)
        { modifier = sequences.Length;

            transform.position = new Vector3(10f * (float)(modifier -1), transform.position.y, -10f * (float)modifier);

        }



    }
}

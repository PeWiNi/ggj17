using UnityEngine;
using System.Collections;

public class SliderControl : MonoBehaviour {

    public int value;
    public Vector3 camerapoints;

	// Use this for initialization
	void Start () {
        camerapoints = new Vector3();

    }
	
	// Update is called once per frame
	void Update () {

        camerapoints = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if (hit.transform.name == transform.name)
                    transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

    }
    
}

using UnityEngine;
using System.Collections;

public class SliderControl : MonoBehaviour {

    public int value;
    public bool selected = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << 8))) {
                if (selected && hit.transform == transform.parent) {
                    transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                    CalcValue(hit.point.y - transform.parent.position.y);
                }
                if (hit.transform.name == transform.name)
                    selected = true;
            }
        }

    }

    // OnMouseUp is called when the mouse button is released
    void OnMouseUp() {
        selected = false;
    }

    void CalcValue(float valueY) {
        value = Mathf.RoundToInt(valueY * 10);
    }
}

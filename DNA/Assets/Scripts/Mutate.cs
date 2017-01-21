using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutate : MonoBehaviour {
    List<int> SliderValues;
    SliderControl[] sliders;
    public GameObject ownerObject;

	// Use this for initialization
	void Start () {
        sliders = GetComponentsInChildren<SliderControl>();
    }
	
	// Update is called once per frame
	void Update () {
	    //if (Input.GetKeyDown(KeyCode.Space)) {
            FetchValuesFromSequence();
            //UpdateSpheres(SliderValues);
        //}
	}

    public void FetchValuesFromSequence() {
        if (SliderValues == null)
            SliderValues = new List<int>();
        SliderValues.Clear();
        for (int i = 0; i < sliders.Length; i++) {
            SliderValues.Add(sliders[i].value);
            if (sliders[i].selected) {
                UpdateSphere(i);
            }
        }
    }

    void UpdateSpheres(List<int> values) {
        for (int i = 0; i < SliderValues.Count; i++) {
            UpdateSphere(i);
        }
    }

    void UpdateSphere(int i) {
        if (ownerObject == null) return;
        float value = SliderValues[i];
        switch (i) {
            case (0):
                ScaleGO((ownerObject.GetComponentsInChildren<Transform>())[1], value);
                break;
            case (1):
                DisplaceGO((ownerObject.GetComponentsInChildren<FollowTransform>())[0], value, 0);
                break;
            case (2):
                GravityGO((ownerObject.GetComponentsInChildren<Rigidbody>())[1], value);
                break;
            case (3):
                ScaleGO((ownerObject.GetComponentsInChildren<Transform>())[2], value);
                break;
            case (4):
                DisplaceGO((ownerObject.GetComponentsInChildren<FollowTransform>())[1], value, 1);
                break;
            case (5):
                GravityGO((ownerObject.GetComponentsInChildren<Rigidbody>())[2], value);
                break;
            case (6):
                ScaleGO((ownerObject.GetComponentsInChildren<Transform>())[3], value);
                break;
            case (7):
                DisplaceGO((ownerObject.GetComponentsInChildren<FollowTransform>())[2], value, 2);
                break;
            case (8):
                GravityGO((ownerObject.GetComponentsInChildren<Rigidbody>())[3], value);
                break;
            case (9):
            case (10):
            case (11):
                break;
        }
    }

    void ScaleGO(Transform go, float value) {
        value = (Mathf.Abs(value) / 10) + 1;
        if (go != null) {
            go.localScale = new Vector3(value, value, value);
        }
    }

    void DisplaceGO(FollowTransform go, float value, int goIndex) {
        value = value / 10;
        if (value > 0) value += 1;
        if (value < 0) value -= 1;
        if (value == 0) value = (Random.Range(1, 100) > 50 ? 1 : -1);
        if (go != null) {
            bool x = Random.Range(1, 100) > 50;
            bool y = Random.Range(1, 100) > 50;
            bool z = Random.Range(1, 100) > 50;
            go.displacement = new Vector3(value, value, value);
        }
    }

    void GravityGO(Rigidbody go, float value) {
        value = Mathf.Abs(value) / 10;
        if (go != null)
            go.mass = value;
    }
}

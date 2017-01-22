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

    public void ApplySequences() {
        BodyPartChooser[] shapePickers = GetComponentsInChildren<BodyPartChooser>();
        foreach (var picker in shapePickers) {
            // 1: Head shape
            if (picker.isHead) {
                picker.newHeadChoice = sequences[1];
            }
            // 2: Torso shape
            if (picker.isTorso) {
                picker.newTorsoChoice = sequences[2];
                // 3: Arms 
                picker.GetComponent<Limbs>().newArmsChoice = sequences[3];
            }
            // 5: Butt/lower body shape
            if (picker.isButt) {
                //picker.newButtChoice = sequences[5];
            }
        }
        // 4: FullBody Scaling (!head)
        // 6: Leg count
        // 7: Tail(s)
        // 8: Orientation of bodyParts
        // 9: Accessories
        //10: Cosmetic (coloring and materials)
        //11: Name Generator
        //12: Fun factor (VFX and more)
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

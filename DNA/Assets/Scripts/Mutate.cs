using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutate : MonoBehaviour {
    Dictionary<int, int> sequence;
    public int[] visualSequence;

    // Use this for initialization
    void Start () {
        if (sequence != null) ApplySequences();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ApplySequences() {
        BodyPartChooser[] shapePickers = GetComponentsInChildren<BodyPartChooser>();
        foreach (var picker in shapePickers) {
            // 1: Head shape
            if (picker.isHead) {
                picker.newHeadChoice = sequence[1];
            }
            // 2: Torso shape
            if (picker.isTorso) {
                picker.newTorsoChoice = sequence[2];
                // 3: Arms 
                picker.GetComponent<Limbs>().newArmsChoice = sequence[3];
            }
            // 5: Butt/lower body shape
            if (picker.isButt) {
                picker.newButtChoice = sequence[5];
                // 6: Leg count
                picker.GetComponent<Limbs>().newLegsChoice = sequence[6];
            }
        }
        // 4: FullBody Scaling (!head)
        // 7: Tail(s)
        // 8: Orientation of bodyParts
        // 9: Accessories
        //10: Cosmetic (coloring and materials)
        //11: Name Generator
        //12: Fun factor (VFX and more)
    }

    public void SetSequence(Dictionary<int, int> sequence) {
        visualSequence = new int[sequence.Count];
        int i = 0;
        foreach (var seq in sequence.Values) 
        {
            visualSequence[i++] = seq;
        }
        this.sequence = sequence;
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutate : MonoBehaviour {
    Dictionary<int, int> sequence;
    public int[] visualSequence;

    // Use this for initialization
    void Start () {
        if (sequence != null) ApplySequences();
        //StartCoroutine(ExecuteAfterTime(1));
        gameObject.AddComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ApplySequences() {
        foreach (var picker in GetComponentsInChildren<BodyPartChooser>()) {
            // 1: Head shape
            if (picker.isHead) {
                picker.newHeadChoice = sequence[1];
            }
            // 2: Torso shape
            if (picker.isTorso) {
                picker.newTorsoChoice = sequence[2];
                // 3: Arms 
                picker.GetComponent<Limbs>().newArmsChoice = sequence[3];
                // 4: FullBody Scaling (!head)
                ScaleGO(picker.transform, sequence[4], sequence[4] % 3 == 1);
            }
            // 5: Butt/lower body shape
            if (picker.isButt) {
                picker.newButtChoice = sequence[5];
                // 6: Leg count
                picker.GetComponent<Limbs>().newLegsChoice = sequence[6];
                // 4: FullBody Scaling (!head)
                ScaleGO(picker.transform, sequence[4], sequence[4] % 3 == 2);
            }

        }
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

    void ScaleGO(Transform go, float value, bool smallScale) {
        value = (Mathf.Abs(value) / (smallScale ? 50 : 5)) + 1;
        if (go != null) {
            go.localScale = new Vector3(value, value, value);
        }
    }

    void GravityGO(Rigidbody go, float value) {
        value = Mathf.Abs(value) / 10;
        if (go != null)
            go.mass = value;
    }

    IEnumerator ExecuteAfterTime(float time) {
        yield return new WaitForSeconds(time);

        foreach (var rigid in GetComponentsInChildren<Rigidbody>()) {
            Destroy(rigid);
        }
        gameObject.AddComponent<Rigidbody>();
    }
}

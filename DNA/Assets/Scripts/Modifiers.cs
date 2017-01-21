using UnityEngine;
using System.Collections;

public class Modifiers : MonoBehaviour {

    public int modifierDrag;
    public int modifierMass;
    public int modifierVelocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeModifiers(GameObject newShape)
    {

        switch (newShape.transform.tag) {
            case "cube":    modif(1,1,-1);  break;
            case "cone": modif(-1,-1,1);  break;
            case "cylinder": modif(-1, 1, -1); break;
            case "helix": modif(1, -1, -1); break;
            case "pyramid": modif(-1, -1, -1); break;
            case "torus": modif(-1, 1, 1); break;
            case "sphere": modif(1, -1, -1); break;

        }
    }

    void modif(int drag, int mass, int velocity) {
        modifierDrag = drag;
        modifierMass = mass;
        modifierVelocity = velocity;
    }
}

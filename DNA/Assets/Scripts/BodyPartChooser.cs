using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class BodyPartChooser : MonoBehaviour {

    public bool isHead;
    //public List<Object> potentialHeads;
    public Object[] potentialHeads;

    [Range(0, 17)]
    public int newChoice=0;
    public int prevChoice = 0;

    public GameObject headSpace;
  
    // Use this for initialization
    void Start () {

        headSpace = GameObject.Find("Head");
        potentialHeads = Resources.LoadAll("Parts");

       
	}
	
	// Update is called once per frame
	void Update () {
       
        if (potentialHeads.Length<= 0)
        {
            potentialHeads = Resources.LoadAll("Parts");
        }

        if (headSpace == null)
        {
            headSpace = GameObject.Find("Head");
            return;
        }
        else {
            if (prevChoice != newChoice)
            {
                prevChoice = newChoice;
                Vector3 pos = headSpace.transform.position;
                Quaternion rot = headSpace.transform.rotation;
                //headSpace = null;
                GameObject headChoice = Instantiate(potentialHeads[newChoice], pos, rot) as GameObject;
                //GameObject toDestroy = headSpace.transform.GetChild(0).gameObject;
                
                headChoice.transform.parent = headSpace.transform;
                if (headSpace.transform.childCount>1) Destroy(headSpace.transform.GetChild(0).gameObject);
            }
        }

    }
}

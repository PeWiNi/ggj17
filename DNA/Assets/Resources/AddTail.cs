using UnityEngine;
using System.Collections;

public class AddTail : MonoBehaviour {

    public BodyPartChooser headParts;
    int skipHead;


    [Range(0, 23)]
    public int newHeadChoice = 0;
    public int prevHeadChoice = 0;
    // Use this for initialization
    void Start () {

        headParts = transform.parent.parent.transform.GetChild(1).GetComponent<BodyPartChooser>();
        skipHead = headParts.headIndex;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (newHeadChoice == skipHead) newHeadChoice++;
        if (prevHeadChoice != newHeadChoice )
        {
            prevHeadChoice = newHeadChoice;
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            //headSpace = null;
            GameObject headChoice = Instantiate(headParts.potentialHeads[newHeadChoice], pos, rot) as GameObject;
            //GameObject toDestroy = headSpace.transform.GetChild(0).gameObject;
            Vector3 newScale = Vector3.one*2;
     
            headChoice.transform.parent = transform;
            headChoice.transform.localScale = newScale;
            if (transform.childCount > 1) Destroy(transform.GetChild(0).gameObject);
        }
    }
}

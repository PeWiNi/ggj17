using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Limbs : MonoBehaviour {

    public BodyPartChooser body;
    public List<GameObject> pairs;

    [Range(0, 34)]
    public int newArmsChoice = 0;
    public int prevArmsChoice = 0;

    // Use this for initialization
    void Start () {
        pairs = new List<GameObject>();
        body = gameObject.GetComponent<BodyPartChooser>();
        
	}

    // Update is called once per frame
    void Update()
    {
        if (body.isTorso)
            if (prevArmsChoice != newArmsChoice)
            {
                prevArmsChoice = newArmsChoice;
                createArmPairs();
            }
        if (body.isButt)
        {
        }
    }

    public void createArmPairs()
    {
        // pairs = new List<GameObject>();
        /*foreach (GameObject arm in pairs)
            Destroy(arm);
        pairs.Clear();*/
        if (body.arms.Count < 1)
        {
           if(body.torsoSpace.transform.childCount>1) if (body.torsoSpace.transform.GetChild(1) != null)
                    Destroy(body.torsoSpace.transform.GetChild(1).gameObject);
            pairs.Clear();
            GameObject tempArm = Instantiate(body.potentialTorsos[Random.Range(0, body.potentialTorsos.Count)],
                    body.torsoSpace.transform.position, body.torsoSpace.transform.rotation) as GameObject;
            tempArm.transform.parent = body.torsoSpace.transform;
            pairs.Add(tempArm);
        }

        else foreach (GameObject pair in body.arms)
            {

                GameObject tempArm = Instantiate(body.potentialHeads[Random.Range(0, body.potentialHeads.Count)],
                    pair.transform.position, pair.transform.rotation) as GameObject;
                tempArm.transform.parent = pair.transform;
                pairs.Add(tempArm);
                tempArm = Instantiate(tempArm, pair.transform.position, pair.transform.rotation) as GameObject;
                tempArm.transform.parent = pair.transform;
                pairs.Add(tempArm);

            }

    }

    public void createLegs()
    {
    }
}

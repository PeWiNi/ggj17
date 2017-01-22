﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Limbs : MonoBehaviour {

    public GameObject leg;
    public BodyPartChooser body;
    public List<GameObject> pairs;

    [Range(0, 34)]
    public int newArmsChoice = 0;
    public int prevArmsChoice = 0;


    public List<GameObject> legs;
    [Range(0, 20)]
    public int newLegsChoice = 0;
    public int prevLegsChoice = 0;

    // Use this for initialization
    void Start () {
        pairs = new List<GameObject>();
        legs = new List<GameObject>();
        body = gameObject.GetComponent<BodyPartChooser>();
        leg = Resources.Load("Parts/leg") as GameObject;
        
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
            if (prevLegsChoice != newLegsChoice)
            {
                prevLegsChoice = newLegsChoice;
              
                //legs.Clear();
                createLegs(body.transform.GetChild(0),newLegsChoice);
            }
        }
    }

    public void createArmPairs()
    {
    
        if (body.arms.Count < 1)
        {
           if(body.transform.childCount>1) if (body.transform.GetChild(1) != null)
                    Destroy(body.transform.GetChild(1).gameObject);
            pairs.Clear();
            GameObject tempArm = Instantiate(body.potentialTorsos[Random.Range(0, body.potentialTorsos.Count)],
                    body.transform.position, body.transform.rotation) as GameObject;
            tempArm.transform.parent = body.transform;
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

    public void createLegs(Transform newShape, int legCount)
    {
        int legCountModifier=1;
        
        switch (newShape.tag)
        {
            case "cube": legCountModifier=body.arms.Count*4; break;
            case "cone": legCountModifier = body.arms.Count *2; break;
            case "cylinder": legCountModifier =(int) ( (float)body.arms.Count * 2.5f); break;
            case "helix": legCountModifier = (body.arms.Count/2)>0? body.arms.Count / 2 : 1; break;
            case "pyramid": legCountModifier = body.arms.Count * 4; break;
            case "torus": legCountModifier = (body.arms.Count / 3) > 0 ? body.arms.Count / 3 : 1; break;
            case "sphere": legCountModifier = body.arms.Count * 6; break;

        }

        int scaleModifier = legCountModifier * legCount;
        Vector3 newScale = Vector3.one *( 1f / (float)scaleModifier);
        GameObject tempLeg;
        for (int i = 0; i < legCount * legCountModifier; i++)
        {
            tempLeg = Instantiate(leg, newShape.transform.position, newShape.transform.rotation) as GameObject;
            tempLeg.transform.localScale = newScale;
            tempLeg.transform.parent = newShape.transform;

            legs.Add(tempLeg);
        }
       


    }
}

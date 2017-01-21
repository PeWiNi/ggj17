using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class BodyPartChooser : MonoBehaviour {

    public bool isHead;
    public bool isTorso;
    public bool isButt;

    public List<GameObject> potentialHeads;
   // public Object[] potentialHeads;
    public GameObject headSpace;

    [Range(0, 23)]
    public int newHeadChoice=0;
    public int prevHeadChoice = 0;

    
    public List <GameObject> potentialTorsos;
    public GameObject torsoSpace;

    [Range(0, 34)]
    public int newTorsoChoice = 0;
    public int prevTorsoChoice = 0;

    public List<GameObject> arms;

    public List<GameObject> potentialButts;
    public GameObject buttSpace;

    // Use this for initialization
    void Start () {

        potentialHeads = new List<GameObject>();
        potentialTorsos = new List<GameObject>();
       
        arms = new List<GameObject>();

        headSpace = GameObject.Find("Head");

        foreach (Object o in Resources.LoadAll("Parts"))
        {
            potentialHeads.Add((GameObject)o);
        }

        torsoSpace = GameObject.Find("Torso");
        selectTorsos();

        buttSpace = GameObject.Find("Butt");
        selectButts();
    }
	
	// Update is called once per frame
	void Update () {
        #region Head
        if (isHead)
        {
            if (potentialHeads.Count <= 0)
            {
                foreach (Object o in Resources.LoadAll("Parts"))
                {
                    potentialHeads.Add((GameObject)o);
                }
                selectTorsos();
            }

            if (headSpace == null)
            {
                headSpace = GameObject.Find("Head");
                return;
            }
            else
            {
                if (prevHeadChoice != newHeadChoice)
                {
                    prevHeadChoice = newHeadChoice;
                    Vector3 pos = headSpace.transform.position;
                    Quaternion rot = headSpace.transform.rotation;
                    //headSpace = null;
                    GameObject headChoice = Instantiate(potentialHeads[newHeadChoice], pos, rot) as GameObject;
                    //GameObject toDestroy = headSpace.transform.GetChild(0).gameObject;

                    headChoice.transform.parent = headSpace.transform;
                    if (headSpace.transform.childCount > 1) Destroy(headSpace.transform.GetChild(0).gameObject);
                }
            }
        }
        #endregion
        #region Torso
        if (isTorso)
        {
            if (torsoSpace == null)
            {
                torsoSpace = GameObject.Find("Torso");
                return;
            }

            if (prevTorsoChoice != newTorsoChoice)
            {
                prevTorsoChoice = newTorsoChoice;
                Vector3 pos = torsoSpace.transform.position;
                Quaternion rot = torsoSpace.transform.rotation;
                //headSpace = null;
                GameObject torsoChoice = Instantiate(potentialTorsos[newTorsoChoice%7], pos, rot) as GameObject;
                //GameObject toDestroy = headSpace.transform.GetChild(0).gameObject;

               
                if (torsoSpace.transform.childCount > 0)
                    for(int i=0;i<torsoSpace.transform.childCount;i++)
                        if (!torsoSpace.transform.GetChild(i).name.StartsWith("armPair"))
                            Destroy(torsoSpace.transform.GetChild(i).gameObject);


                torsoChoice.transform.parent = torsoSpace.transform;
                //int armPairs = newTorsoChoice -( newTorsoChoice / 5);
                int armPairs = newTorsoChoice % 5;
                foreach (GameObject arm in arms)
                    Destroy(arm);
                arms.Clear();
                gameObject.GetComponent<Limbs>().pairs = new List<GameObject>();
                for (int i = 0; i < armPairs; i++)
                {
                    GameObject armPair = new GameObject();
                    armPair.transform.name = "armPair" + i.ToString();
                    armPair.transform.parent = torsoSpace.transform;
                    arms.Add(armPair);
                }
            }

        }
        #endregion

        #region Butt

        #endregion
    }


    void selectTorsos()
    {
        for (int i = 0; i < potentialHeads.Count; i++)
        {
            int sameTagcounter=1;
            for (int j = i+1; j < potentialHeads.Count; j++)
            {
                if (potentialHeads[i].transform.tag == potentialHeads[j].transform.tag)
                    sameTagcounter++;
                else break;
            }

            potentialTorsos.Add(potentialHeads[Random.Range(i, i + sameTagcounter)]);


            i += sameTagcounter;

        }
    }

    void selectButts()
    {
        for (int i = 0; i < potentialHeads.Count; i++)
        {
            int sameTagcounter = 1;
            for (int j = i + 1; j < potentialHeads.Count; j++)
            {
                if (potentialHeads[i].transform.tag == potentialHeads[j].transform.tag)
                    sameTagcounter++;
                else break;
            }

            potentialButts.Add(potentialHeads[Random.Range(i, i + sameTagcounter)]);


            i += sameTagcounter;

        }
    }

}

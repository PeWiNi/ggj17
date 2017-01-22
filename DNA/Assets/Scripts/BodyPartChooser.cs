using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class BodyPartChooser : MonoBehaviour {

    public bool isHead;
    public bool isTorso;
    public bool isButt;
    public int headIndex;
    public List<GameObject> potentialHeads;
   // public Object[] potentialHeads;

    [Range(0, 23)]
    public int newHeadChoice=0;
    public int prevHeadChoice = 0;

    
    public List <GameObject> potentialTorsos;

    [Range(0, 34)]
    public int newTorsoChoice = 0;
    public int prevTorsoChoice = 0;

    public List<GameObject> arms;

    public List<GameObject> potentialButts;

    [Range(0, 6)]
    public int newButtChoice = 0;
    public int prevButtChoice = 0;

    // Use this for initialization
    void Start () {

        potentialHeads = new List<GameObject>();
        potentialTorsos = new List<GameObject>();
       
        arms = new List<GameObject>();

        foreach (Object o in Resources.LoadAll("Parts"))
        {
            potentialHeads.Add((GameObject)o);
        }
     
        selectTorsos();
    
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
 
            else
            {
                if (prevHeadChoice != newHeadChoice)
                {
                    prevHeadChoice = newHeadChoice;
                    Vector3 pos = transform.position;
                    Quaternion rot = transform.rotation;
                    //headSpace = null;
                    GameObject headChoice = Instantiate(potentialHeads[newHeadChoice], pos, rot) as GameObject;
                    //GameObject toDestroy = headSpace.transform.GetChild(0).gameObject;
                    headIndex = newHeadChoice;
                    headChoice.transform.parent = transform;
                    if (transform.childCount > 1) Destroy(transform.GetChild(0).gameObject);
                }
            }
        }
        #endregion
        #region Torso
        if (isTorso)
        {

            if (prevTorsoChoice != newTorsoChoice)
            {
                prevTorsoChoice = newTorsoChoice;
                Vector3 pos = transform.position;
                Quaternion rot = transform.rotation;
                //headSpace = null;
                GameObject torsoChoice = Instantiate(potentialTorsos[newTorsoChoice%7], pos, rot) as GameObject;
                //GameObject toDestroy = headSpace.transform.GetChild(0).gameObject;

               
                if (transform.childCount > 0)
                    for(int i=0;i<transform.childCount;i++)
                        if (!transform.GetChild(i).name.StartsWith("armPair"))
                            Destroy(transform.GetChild(i).gameObject);


                torsoChoice.transform.parent = transform;
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
                    armPair.transform.parent = transform;
                 //   armPair.transform.rotation= Quaternion.Euler(0, 0, 40);
                    armPair.AddComponent<FollowTransform>().trans=transform;
                   armPair.GetComponent<FollowTransform>().displacement = Vector3.zero;
                    arms.Add(armPair);
                }
            }

        }
        #endregion

        #region Butt
        if (isButt)
        {
            if (prevButtChoice != newButtChoice)
            {
                prevButtChoice = newButtChoice;
                Vector3 pos = transform.position;
                Quaternion rot = transform.rotation;
                GameObject buttChoice = Instantiate(potentialTorsos[newButtChoice], pos, rot) as GameObject;
                buttChoice.transform.parent = transform;
                if (transform.childCount > 2 ) Destroy(transform.GetChild(1).gameObject);
            }
        }
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

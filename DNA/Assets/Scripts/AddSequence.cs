using UnityEngine;
using System.Collections;

public class AddSequence : MonoBehaviour {

    public GameObject sequence;
    public int modifier;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

     
    }

    public void addSeq()
    {
        gameObject.GetComponent<AutoMove>().MoveMe();

        modifier = GameObject.Find("Main Camera").GetComponent<AutoZoom>().modifier;
        
        Vector3 tempPos = new Vector3(20 *modifier, 
                                transform.position.y, transform.position.z);
        GameObject temp = Instantiate(sequence, tempPos, Quaternion.identity) as GameObject;
       // temp.transform.parent = transform;

    }
}

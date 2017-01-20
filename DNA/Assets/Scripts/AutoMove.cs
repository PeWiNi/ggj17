using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour
{

    public int modifier;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //   MoveMe();
       /* GameObject[] sequences = GameObject.FindGameObjectsWithTag("sequence");
        foreach (GameObject gm in sequences)
            if (gm.transform.parent != transform)
                gm.transform.parent = transform;*/
    }

    public void MoveMe()
    {
        GameObject[] sequences = GameObject.FindGameObjectsWithTag("sequence");

        if (sequences.Length != modifier)
        {
            modifier = sequences.Length;

            transform.position = new Vector3(-10f * (float)(modifier - 1), transform.position.y, transform.position.z);

        }
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpawnCreatures : MonoBehaviour {
    public Logic logic;
    public GameObject spawnPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnCreature() {
        foreach(var user in logic.userSequences.Values) {
            GameObject tempCreature = Instantiate(spawnPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity) as GameObject;
            tempCreature.GetComponent<Mutate>().SetSequence(user);
        }
    }
}

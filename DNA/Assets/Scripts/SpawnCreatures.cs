using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        foreach(var user in logic.userSequences) {

        }
    }
}

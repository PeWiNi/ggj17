using UnityEngine;
using System.Collections;

public class SpawnCreatures : MonoBehaviour {
    public Logic logic;
    public GameObject spawnPrefab;
    public Vector3 spawnPos = new Vector3(0, 1.5f, 0);

    public void SpawnCreature() {
        if (!spawnPrefab && logic.userSequences != null) return;
        RabbitScript rabbit = GameObject.Find("Rabbit").GetComponent<RabbitScript>();
        foreach(var user in logic.userSequences.Values) {
            GameObject tempCreature = Instantiate(spawnPrefab, spawnPos, Quaternion.identity) as GameObject;
            tempCreature.GetComponent<Mutate>().SetSequence(user);
            if (rabbit)
            {
                rabbit.transform.position = spawnPos + 5 * Vector3.up;
                tempCreature.AddComponent<ChaseTransform>().target = rabbit.gameObject;
            }
        }
    }
}

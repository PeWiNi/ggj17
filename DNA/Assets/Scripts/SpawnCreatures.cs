using UnityEngine;
using System.Collections;

public class SpawnCreatures : MonoBehaviour {
    public Logic logic;
    public GameObject spawnPrefab;

    public void SpawnCreature() {
        if (!spawnPrefab && logic.userSequences != null) return;
        RabbitScript rabbit = GameObject.Find("Rabbit").GetComponent<RabbitScript>();
        foreach(var user in logic.userSequences.Values) {
            GameObject tempCreature = Instantiate(spawnPrefab, new Vector3(0, 1.5f, 0), Quaternion.identity) as GameObject;
            tempCreature.GetComponent<Mutate>().SetSequence(user);
            if (rabbit)
                tempCreature.AddComponent<ChaseTransform>().target = rabbit.gameObject;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSpawnBase : MonoBehaviour
{
    public void SpawnBase(GameObject spawnMe, GameObject spawner)
    {
        GameObject copySpawnObj = Instantiate(spawnMe,spawner.transform);
    }
}

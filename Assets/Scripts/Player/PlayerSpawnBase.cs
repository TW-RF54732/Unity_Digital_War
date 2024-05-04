using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSpawnBase : MonoBehaviour
{
    FindLibObject findLibObject;
    PlayerID playerID;

    [SerializeField]GameObject spawner,playerBase;
    [SerializeField] int SpawnRandomRange, testStartSpawnBase;

    public int baseCount = 0;
    int Id;
    private void Start()
    {
        startSet();
        startSpawnBase();
        
    }
    public void SpawnBase(GameObject spawnMe, GameObject spawner)
    {
        baseCount++;
        GameObject copySpawnObj = Instantiate(spawnMe,spawner.transform);
        copySpawnObj.transform.parent = playerBase.transform;
        copySpawnObj.name = $"Base {Id}-{baseCount}";
    }

    void startSet()
    {
        findLibObject = GameObject.FindAnyObjectByType<FindLibObject>();
        playerID = gameObject.GetComponent<PlayerID>();
        Id = playerID.getID();
        spawner.transform.position += new Vector3(Random.Range(-SpawnRandomRange,SpawnRandomRange),0.5f,Random.Range(-SpawnRandomRange,SpawnRandomRange));
    }
    void startSpawnBase()
    {
        //spawner = this.transform.Find("spawner").gameObject;
        SpawnBase(findLibObject.getObject(testStartSpawnBase), spawner);
    }
}

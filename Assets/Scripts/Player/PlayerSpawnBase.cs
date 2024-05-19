using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSpawnBase : MonoBehaviour
{
    FindLibObject findLibObject;
    PlayerID playerID;
    Resource resource;

    [SerializeField]GameObject spawner,playerBase;
    [SerializeField] int SpawnRandomRange, testStartSpawnBase, startBaseSoldier = 100,startResource = 100;

    public int baseCount = 0;
    int Id;
    private void Start()
    {
        startSet();
        startSpawnBase();
        
    }
    public GameObject SpawnBase(GameObject spawnMe, GameObject spawner)
    {
        baseCount++;
        GameObject copySpawnObj = Instantiate(spawnMe,spawner.transform);
        copySpawnObj.transform.parent = playerBase.transform;
        copySpawnObj.name = $"Base {Id}-{baseCount}";
        resource = copySpawnObj.GetComponent<Resource>();
        resource.setResourceAmount(startResource);
        return copySpawnObj;
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
        GameObject copyBase = SpawnBase(findLibObject.getObjectFromLib(testStartSpawnBase), spawner);
        BaseFight baseFight = copyBase.GetComponent<BaseFight>();
        baseFight.soldierAmount = startBaseSoldier;
    }
}

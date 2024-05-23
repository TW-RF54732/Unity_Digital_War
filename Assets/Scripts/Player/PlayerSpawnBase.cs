using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSpawnBase : MonoBehaviour
{
    FindLibObject findLibObject;
    PlayerID playerID;
    Resource resource;
    PlayerBaseManager playerBasemanager;

    [SerializeField]GameObject spawner,playerBase,playerCam;
    [SerializeField] int SpawnRandomRange, testStartSpawnBase, startBaseSoldier = 100,startResource = 100;

    int Id;
    private void Start()
    {
        startSet();
        startSpawnBase();
        
    }
    public GameObject SpawnBase(GameObject spawnMe, GameObject spawner)
    {
        GameObject copySpawnObj = Instantiate(spawnMe,spawner.transform);
        playerBasemanager.CheckInBase(copySpawnObj);
        resource = copySpawnObj.GetComponent<Resource>();
        resource.setResourceAmount(startResource);
        return copySpawnObj;
    }

    void startSet()
    {
        findLibObject = GameObject.FindAnyObjectByType<FindLibObject>();
        playerID = gameObject.GetComponent<PlayerID>();
        Id = playerID.getID();
        spawner.transform.position += new Vector3(Random.Range(-SpawnRandomRange, SpawnRandomRange), 0.5f, Random.Range(-SpawnRandomRange, SpawnRandomRange));
        playerBasemanager = playerBase.GetComponent<PlayerBaseManager>();
    }
    void startSpawnBase()
    {
        GameObject copyBase = SpawnBase(findLibObject.getObjectFromLib(testStartSpawnBase), spawner);
        BaseFight baseFight = copyBase.GetComponent<BaseFight>();
        baseFight.soldierAmount = startBaseSoldier;
        CameraController controller = playerCam.GetComponent<CameraController>();
        controller.CameraTarget = copyBase.transform;
    }
}

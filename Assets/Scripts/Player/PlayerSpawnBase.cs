using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSpawnBase : MonoBehaviour
{
    FindLibObject findLibObject;

    [SerializeField]GameObject spawner,playerBase;
    [SerializeField] int SpawnRandomRange, testStartSpawnBase;
    private void Start()
    {
        startSet();
        startSpawnBase();
    }
    public void SpawnBase(GameObject spawnMe, GameObject spawner)
    {
        GameObject copySpawnObj = Instantiate(spawnMe,spawner.transform);
        copySpawnObj.transform.parent = playerBase.transform;
        copySpawnObj.active = true;
    }

    void startSet()
    {
        findLibObject = GameObject.FindAnyObjectByType<FindLibObject>();
        //GameObject spawner = gameObject.transform.Find(name="spawner").gameObject;
        
        spawner.transform.position += new Vector3(Random.Range(-SpawnRandomRange,SpawnRandomRange),0.5f,Random.Range(-SpawnRandomRange,SpawnRandomRange));
    }
    void startSpawnBase()
    {
        //spawner = this.transform.Find("spawner").gameObject;
        SpawnBase(findLibObject.getObject(testStartSpawnBase), spawner);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager self;
    public GameObject spawnPoint;

    protected SpawnPoint[] spawnList;
    protected int nextSpawn;

    private void Awake()
    {
        if (self)
        {
            Debug.Log(self.gameObject.name + " has another instance of a singleton!");
            Destroy(this);
            return;
        }

        self = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnList = FindObjectsOfType<SpawnPoint>();

        if (spawnList.Length == 0)
        {

            Instantiate(spawnPoint, Vector3.zero, Quaternion.identity);
            spawnList = FindObjectsOfType<SpawnPoint>();
        }

    }

    Transform RandomSpawnPoint()
    {
        int spawnAt = Random.Range(0, spawnList.Length);
        return spawnList[spawnAt].gameObject.transform;
    }

    public void Respawn(GameObject spawnPrefab)
    {
        Transform spawnAt = RandomSpawnPoint();
        Instantiate(spawnPrefab, new Vector2(spawnAt.position.x, spawnAt.position.y), Quaternion.identity);
    }
}

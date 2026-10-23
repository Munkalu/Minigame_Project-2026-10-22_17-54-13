using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] GameObject mailboxPrefab;
    [SerializeField] float spawnX = 12f;
    [SerializeField] float obstacleInterval = 2f;
    [SerializeField] float mailboxInterval = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, obstacleInterval);
        InvokeRepeating("SpawnMailBox",2f, mailboxInterval);
    }
    void SpawnObstacle(){
        int i = Random.Range(0,obstaclePrefabs.Length);
        GameObject prefab = obstaclePrefabs[i];
        Vector3 position = new Vector3(spawnX,prefab.transform.position.y,0f);
        Instantiate(prefab,position,Quaternion.identity);
    }

    
    void SpawnMailBox()
    {
        Vector3 position = new Vector3(spawnX, mailboxPrefab.transform.position.y, 0f);
        Instantiate(mailboxPrefab,position, Quaternion.identity);
    }
}

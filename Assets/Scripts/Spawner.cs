using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] GameObject mailboxPrefab;
    [SerializeField] float spawnX = 12f;
    [SerializeField] float obstacleInterval = 2f;
    [SerializeField] float mailboxInterval = 3.5f;
    [SerializeField] LayerMask roofLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, obstacleInterval);
        InvokeRepeating("SpawnMailBox",2f, mailboxInterval);
    }
    void SpawnObstacle(){
        int i = Random.Range(0,obstaclePrefabs.Length);
       SpawnOnRoof(obstaclePrefabs[i]);
    }

    
    void SpawnMailBox()
    {
        SpawnOnRoof(mailboxPrefab);
    }
    void SpawnOnRoof(GameObject prefab){
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(spawnX,10f), Vector2.down, 30f, roofLayer);
        if(hit.collider == null) return;
        GameObject obj = Instantiate(prefab, new Vector3(spawnX, hit.point.y, 0f), Quaternion.identity);
        float bottom = float.MaxValue;
        foreach(Renderer r in obj.GetComponentsInChildren<Renderer>()){
            bottom = Mathf.Min(bottom, r.bounds.min.y);
        }
        obj.transform.position += new Vector3(0f, hit.point.y - bottom, 0f);
    }
}

using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] GameObject mailboxPrefab;
    [SerializeField] float spawnX = 12f;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float mailboxChance = .4f;
    [SerializeField] LayerMask roofLayer;
    [SerializeField] GameObject letterBagPrefab;
    [SerializeField] float letterBagChance = .15f;
    void Start()
    {
        InvokeRepeating("SpawnNext", 1f, spawnInterval);
    }
    void SpawnNext(){
        if(Random.value < letterBagChance){
            SpawnOnRoof(letterBagPrefab);
            return;
        }
        else if(Random.value < mailboxChance){
            SpawnOnRoof(mailboxPrefab);
            return;
        }
        else{
            int i = Random.Range(0, obstaclePrefabs.Length);
            SpawnOnRoof(obstaclePrefabs[i]);
        }

    }
    void SpawnOnRoof(GameObject prefab){
        Physics2D.SyncTransforms();   

        GameObject obj = Instantiate(prefab, new Vector3(spawnX, 0f, 0f), Quaternion.identity);

        
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        float left = float.MaxValue, right = float.MinValue, bottom = float.MaxValue;
        foreach (Renderer r in renderers)
        {
            left = Mathf.Min(left, r.bounds.min.x);
            right = Mathf.Max(right, r.bounds.max.x);
            bottom = Mathf.Min(bottom, r.bounds.min.y);
        }

       
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(left, 10f), Vector2.down, 30f, roofLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(right, 10f), Vector2.down, 30f, roofLayer);

        
        if (hitLeft.collider == null || hitRight.collider == null ||
            Mathf.Abs(hitLeft.point.y - hitRight.point.y) > 0.05f)
        {
            Destroy(obj);
            return;
        }

        
        obj.transform.position += new Vector3(0f, hitLeft.point.y - bottom, 0f);
    }
}

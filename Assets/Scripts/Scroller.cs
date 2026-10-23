using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializedField] float speed = 4f;
    [SerializedField] float destroyX = -12f;
    
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        if(transform.position.x <destroyX){
            Destroy(gameObject);
        }
    }
}

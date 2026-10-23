using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float destroyX = -12f;
    [SerializeField] bool loop = false;
    [SerializeField] float width = 20f;
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        if(transform.position.x <destroyX){
            if(loop){
                Vector3 pos = transform.position;
                pos.x += width*2;
                transform.position = pos;
            }
            else{
                Destroy(gameObject);
            }
        }
    }
}

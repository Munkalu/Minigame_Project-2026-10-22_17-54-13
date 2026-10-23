using UnityEngine;

public class LetterProjectile : MonoBehaviour
{
 [SerializeField] AudioClip clip;
   
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            return;
        }
        if(other.CompareTag("Mailbox")){
            Mailbox box = other.GetComponent<Mailbox>();
            if(box.delivered == false){
                box.delivered = true;
                GameManager.Instance.Deliver();
                AudioSource.PlayClipAtPoint(clip,transform.position);
            }
            else{
                GameManager.Instance.Miss();
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Roof")){
            GameManager.Instance.Miss();
            Destroy(gameObject);
        }
    }

    
}

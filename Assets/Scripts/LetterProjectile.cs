using UnityEngine;

public class LetterProjectile : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            return;
        }
        if(other.CompareTag("Mailbox")){
            Mailbox box = other.getComponent<Mailbox>();
            if(box.delivered == false){
                box.delivered = true;
                GameManager.Instance.Deliver();
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

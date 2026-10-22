using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float flapStrength = 7f;
    [SerializeField] float normalGravity = 2.5f;
    [SerializeField] float glideGravity = .25f;
    [SerializeField] float maxStamina = 100f;
    [SerializeField] float flapCost = 15f;
    [SerializeField] float staminaRegen = 25f;
    Rigidbody2D rb;
    float stamina;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = maxStamina;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && stamina>=flapCost)
        {
            rb.linearVelocity =new Vector2(rb.linearVelocity.x, flapStrength);
            stamina = stamina - flapCost;
        }
        if(Input.GetKey(KeyCode.Space) && rb.linearVelocity.y< 0){
            rb.gravityScale = glideGravity;
            stamina += staminaRegen * Time.deltaTime;
        }
        else{
            rb.gravityScale =normalGravity;
        }
        stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        
        
    }
}

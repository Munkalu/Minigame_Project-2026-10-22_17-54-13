using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float flapStrength = 8f;
    [SerializeField] float normalGravity = 2.5f;
    [SerializeField] float glideGravity = .25f;
    [SerializeField] float maxStamina = 100f;
    [SerializeField] float flapCost = 5f;
    [SerializeField] float staminaRegen = 25f;
    [SerializeField] GameObject letterPrefab;
    [SerializeField] int maxLetters = 5;
    [SerializeField] float invincibleTime = 1.5f;
    Rigidbody2D rb;
    float stamina;
    int letters;
    float invincibleTimer;
    public int Letters => letters;
    public float Stamina => stamina;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = maxStamina;
        letters = maxLetters;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && stamina>=flapCost)
        {
            rb.linearVelocity =new Vector2(rb.linearVelocity.x, flapStrength);
            stamina -= flapCost;
        }
        if(Input.GetKey(KeyCode.Space) && rb.linearVelocity.y< 0){
            rb.gravityScale = glideGravity;
            stamina += staminaRegen * Time.deltaTime;
        }
        else{
            rb.gravityScale =normalGravity;
        }
        stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        if((Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow)) && letters > 0){
            Instantiate(letterPrefab, transform.position + Vector3.down * .6f,Quaternion.identity);
            letters--;
        }
        invincibleTimer -= Time.deltaTime;
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Obstacle") && invincibleTimer <= 0){
            GameManager.Instance.LoseHeart();
            invincibleTimer = invincibleTime;
        }
        if(other.CompareTag("Restock")){
            letters = maxLetters;
            Destroy(other.gameObject);
        }
    }
}

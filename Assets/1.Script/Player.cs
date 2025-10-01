using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public Joystick joystick;

    public UserManager userManager;

    private void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void Start()
    {
        
    }

    public Tree target;

    void Update()
    {
        //transform.position += (Vector3)joystick.Direction * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player Update() F");
            if (target != null)
            {
                target.TakeDamage();
            }
        }
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collection")
        {
            Debug.Log("Player OnTriggerEnter2D()");
            target = collision.GetComponent<Tree>();
        }

        if(collision.tag == "Item")
        {
            Item item = collision.GetComponent<Item>();
            if(item != null)
            {
                //userManager.data.inventory.AddItem(item.key, item.amount);
                Destroy(collision.gameObject);
            }
            
        }
    }
}

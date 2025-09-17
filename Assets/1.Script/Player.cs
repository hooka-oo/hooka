using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public Joystick joystick;

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
        transform.position += (Vector3)joystick.Direction * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player Update() F");
            target.TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collection")
        {
            Debug.Log("Player OnTriggerEnter2D()");
            target = collision.GetComponent<Tree>();

        }
    }
}

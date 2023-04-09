using UnityEngine;

public class Hero : MonoBehaviour
{
    private Rigidbody2D rd;
    public float speed = 20f;
    public bool mouseControl = true;
    public Camera c;
    public float speedMulti = 1f;
    public float speedMultiMax = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        c = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Detect inputs both available in mouse and keyboard control
        UniversalControl();

        // Moves this object based on control
        if(mouseControl)
            MouseMovement();
        else
            KeyboardMovement();
    }

    void UniversalControl()
    {
        // Switch betweem mouse control
        if(Input.GetKeyDown(KeyCode.M))
            mouseControl = !mouseControl;
        
        // Detect key for rotation
        if(Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));

        if(Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, 0, -45 * Time.deltaTime));
    }

    void MouseMovement()
    {
        rd.velocity = Vector2.zero; // Stops Hero from moving forward

        // Convert mouse position to screen
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = c.ScreenToWorldPoint(mousePos); 
        worldPos.z = transform.position.z;

        transform.position = worldPos;
    }
    
    void KeyboardMovement()
    {
        rd.velocity = transform.up * speed * speedMulti;

        if(Input.GetKey(KeyCode.W))
            speedMulti += 0.25f * Time.deltaTime;
        
        if(Input.GetKey(KeyCode.S))
            speedMulti -= 0.25f * Time.deltaTime;

        speedMulti = Mathf.Clamp(speedMulti, 0, speedMultiMax);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Destroy(c.gameObject);
        Controller.spawnCount--;
    }
}
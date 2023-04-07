using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rd;
    public float speed = 20f;
    public bool mouseControl = true;
    public Camera c;


    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        c = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Switch betweem mouse control
        if(Input.GetKeyDown(KeyCode.M))
            mouseControl = !mouseControl;

        // Detect key for rotation
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -45 * Time.deltaTime));
        }

        // Moves this object based on control
        if(mouseControl)
        {
            rd.velocity = new Vector2(); // Stops Hero from moving forward

            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = c.ScreenToWorldPoint(mousePos); 
            worldPos.z = transform.position.z;

            transform.position = worldPos;
        }
        else
            rd.velocity = transform.up * speed;

    }
}

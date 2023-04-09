using Unity.Mathematics;
using UnityEngine;

public class FireEgg : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate = 0.2f;
    private float fireCD;
    
    // Start is called before the first frame update
    void Start()
    {
        fireCD = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
            Shoot();
    }

    void Shoot()
    {
        var t = Time.time;
        if(t < fireCD)
            return;
        
        Instantiate(projectile, transform.position, transform.rotation);
        fireCD = t + fireRate;
    }
}

using UnityEngine;

public class Plane : MonoBehaviour
{
    public int hp = 4;
    public Color currentC;

    void Start()
    {
        var oldC = GetComponent<Renderer>().material.color;
        currentC = new Color(oldC.r, oldC.g, oldC.b, oldC.a);
    }

    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject, 0);
            Controller.spawnCount--;
        }
    }
}

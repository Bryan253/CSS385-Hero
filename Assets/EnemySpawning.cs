using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    private Camera c;
    [SerializeField] private GameObject spawnCreature;
    [SerializeField] private int spawnCount = 0;
    public int maxSpawn = 10;
    
    void Start()
    {
        c = Camera.main;
    }

    void FixedUpdate()
    {
        while(spawnCount < maxSpawn)
            spawn();
    }

    void spawn()
    {
        // Prevent for spawn than 10
        if(spawnCount >= maxSpawn)
            return;
        
        // Finding area under 90% of main cam to spawn
        var width = c.pixelWidth;
        var height = c.pixelHeight;
        var spawnX = Random.Range(0.1f * width, 0.9f * width);
        var spawnY = Random.Range(0.1f * height, 0.9f * height);
        var screenVec = new Vector2(spawnX, spawnY);
        Vector2 spawnPt = c.ScreenToWorldPoint(screenVec);
        
        Instantiate(spawnCreature, spawnPt, Quaternion.identity);
        spawnCount++;
    }
}

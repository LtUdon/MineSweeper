using UnityEngine;

public enum spawnType
{
    BottomLeft  = 0,
    BottomRight = 1,
    TopLeft     = 2,
    TopRight    = 3,
    Center      = 4
}
public class grid : MonoBehaviour
{
    public GameObject box;

    public int sizeX = 10;
    public int sizeY = 10;

    [Range(0f, 100f)]
    public float mineDensityPercentage = 16f;

    [Tooltip("The value of \"Size Y\" will be set to \"Size X\" if true.")]
    public bool isSquare = true;

    public spawnType spawnType = spawnType.BottomLeft;

    private int trapCount = 0;
    private int totalCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Sol System";

        if (isSquare)
        {
            sizeY = sizeX;
        }

        SpawnBoxes(spawnType);

        // Debug
        Debug.Log("GRID: " + gameObject.name + "\n" +
            "sizeX = " + sizeX + "\n" +
            "sizeY = " + sizeY + "\n" +
            "isSquare = " + isSquare + "\n" +
            "Trap Count = " + trapCount + "/" + totalCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBoxes(spawnType type)
    {
        // Calculate offset based on spawn type
        Vector3 offset = type switch
        {
            spawnType.BottomLeft  => new Vector3(0, 0, 0),
            spawnType.BottomRight => new Vector3(-sizeX, 0, 0),
            spawnType.TopLeft     => new Vector3(0, -sizeY, 0),
            spawnType.TopRight    => new Vector3(-sizeX, -sizeY, 0),
            spawnType.Center      => new Vector3(-sizeX / 2f, -sizeY / 2f, 0),
            _                     => Vector3.zero
        };

        // Spawns boxes in a grid pattern with the applied offset
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Vector3 spawnPos = new Vector3(x, y, 0) + offset;

                // Set name on the instance, not the prefab
                GameObject instance = Instantiate(box, spawnPos, Quaternion.identity);
                instance.name = "Box (" + x + ", " + y + ")";
                // Set trap
                if (Random.Range(0f, 100f) < mineDensityPercentage)
                {
                    instance.GetComponent<box>().isTrap = true;
                    trapCount++;
                }
                totalCount++;
            }
        }
    }
}

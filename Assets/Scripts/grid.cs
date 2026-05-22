using UnityEngine;

public class grid : MonoBehaviour
{
    public int sizeX = 10;
    public int sizeY = 10;

    [Range(0f, 100f)]
    public float mineDensityPercentage = 16f;

    [Tooltip("The value of \"Size Y\" will be set to \"Size X\" if true.")]
    public bool isSquare = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Sol System";

        if (isSquare)
        {
            sizeY = sizeX;
        }

        // Debug
        Debug.Log("GRID: " + gameObject.name + "\n" +
            "sizeX = " + sizeX + "\n" +
            "sizeY = " + sizeY + "\n" +
            "isSquare = " + isSquare);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class box : MonoBehaviour
{
    public bool isTrap = false;
    public bool isOpened = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsBoxedClicked();
    }

    void IsBoxedClicked()
    {
        // The box is selected and is not opened yet
        if (Mouse.current.leftButton.wasPressedThisFrame && !isOpened)
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isOpened = true;
                if (isTrap)
                    Debug.Log("You opened a trap box!");
                else
                    Debug.Log("You opened a safe box!");
            }
        }
    }
}

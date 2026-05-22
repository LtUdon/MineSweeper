using UnityEngine;
using UnityEngine.InputSystem;

public class box : MonoBehaviour
{
    public bool isTrap = false;
    public bool isOpened = false;

    public Sprite closedSprite;
    public Sprite openedSprite;

    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        IsBoxedClicked();
    }

    void IsBoxedClicked()
    {
        // The box is selected and is not opened yet
        if (Mouse.current.leftButton.wasReleasedThisFrame && !isOpened)
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isOpened = true;
                if (isTrap)
                    Debug.Log(gameObject.name + " is a trap!");
                else
                    Debug.Log(gameObject.name + " is a safe box!");

                sr.sprite = openedSprite;
            }
        }
    }
}

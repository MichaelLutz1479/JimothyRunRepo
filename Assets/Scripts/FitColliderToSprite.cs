using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class FitColliderToSprite : MonoBehaviour
{
    [Header("Collider adjustment")]

    // Makes the collider slightly narrower than the sprite.
    [SerializeField] private float horizontalInset = 0.05f;

    // Makes the collider slightly shorter than the sprite.
    [SerializeField] private float verticalInset = 0.02f;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private Sprite previousSprite;
    private bool previousFlipX;
    private bool previousFlipY;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        UpdateCollider();
    }

    private void LateUpdate()
    {
        // Only rebuild when the animation frame or direction changes.
        if (spriteRenderer.sprite != previousSprite ||
            spriteRenderer.flipX != previousFlipX ||
            spriteRenderer.flipY != previousFlipY)
        {
            UpdateCollider();
        }
    }

    private void UpdateCollider()
    {
        Sprite currentSprite = spriteRenderer.sprite;

        if (currentSprite == null)
        {
            boxCollider.enabled = false;
            return;
        }

        boxCollider.enabled = true;

        Bounds spriteBounds = currentSprite.bounds;

        Vector2 newSize = spriteBounds.size;
        Vector2 newOffset = spriteBounds.center;

        // Make the collider slightly smaller if needed.
        newSize.x -= horizontalInset * 2f;
        newSize.y -= verticalInset * 2f;

        // Prevent invalid negative collider sizes.
        newSize.x = Mathf.Max(0.01f, newSize.x);
        newSize.y = Mathf.Max(0.01f, newSize.y);

        // Correct the offset when the SpriteRenderer is flipped.
        if (spriteRenderer.flipX)
        {
            newOffset.x *= -1f;
        }

        if (spriteRenderer.flipY)
        {
            newOffset.y *= -1f;
        }

        boxCollider.size = newSize;
        boxCollider.offset = newOffset;

        previousSprite = currentSprite;
        previousFlipX = spriteRenderer.flipX;
        previousFlipY = spriteRenderer.flipY;
    }
}
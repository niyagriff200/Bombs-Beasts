using UnityEngine;

public class ExplosionRadiusUI : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float duration = 1f;      // how long before it disappears
    private float timer = 0f;

    public void Initialize(float radius)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(radius * 2f, radius * 2f, 1f); // diameter
        Color color = spriteRenderer.color;
        color.a = 0.4f; // semi-transparent
        spriteRenderer.color = color;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            Destroy(gameObject);
            return;
        }

        // Fade out
        if (spriteRenderer != null)
        {
            Color c = spriteRenderer.color;
            c.a = Mathf.Lerp(0.4f, 0f, timer / duration);
            spriteRenderer.color = c;
        }
    }
}

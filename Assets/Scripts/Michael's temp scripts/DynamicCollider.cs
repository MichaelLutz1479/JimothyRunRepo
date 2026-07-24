using UnityEngine;


public class DynamicCollider : MonoBehaviour
{
    public PolygonCollider2D humanCollider;
    public PolygonCollider2D raccoonCollider;

    public void SetHuman()
    {
        humanCollider.enabled = true;
        raccoonCollider.enabled = false;

    }

    public void SetRaccoon()
    {
        humanCollider.enabled = false;
        raccoonCollider.enabled = true;

    }
}

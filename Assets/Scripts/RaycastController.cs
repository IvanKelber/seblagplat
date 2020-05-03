using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour
{
    [HideInInspector]
    public BoxCollider2D collider;
    public const float skinWidth = .015f;
    public LayerMask collisionMask;

    public float initialRaySpacing = .25f;

    [HideInInspector]
    public int horizontalRayCount;
    [HideInInspector]
    public int verticalRayCount;

    [HideInInspector]
    public float horizontalRaySpacing;
    [HideInInspector]
    public float verticalRaySpacing;
    [HideInInspector]
    public RaycastOrigins raycastOrigins;


    public virtual void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    public virtual void Start()
    {
        CalculateRaySpacing();
    }

    public void UpdateRaycastOrigins()
    {
        Bounds bounds = GetBounds();

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
        Debug.DrawRay(raycastOrigins.bottomLeft, Vector2.right *
        (raycastOrigins.bottomRight.x - raycastOrigins.bottomLeft.x), Color.white);
    }

    public void CalculateRaySpacing()
    {
        Bounds bounds = GetBounds();

        horizontalRayCount = Mathf.RoundToInt(bounds.size.y / initialRaySpacing);
        verticalRayCount = Mathf.RoundToInt(bounds.size.x / initialRaySpacing);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    Bounds GetBounds()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);
        return bounds;
    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }


}

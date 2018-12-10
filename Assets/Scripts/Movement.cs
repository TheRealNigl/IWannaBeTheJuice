using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    protected bool Jump { get; set; }
    protected float Speed { get; set; }
    protected Vector2 Location { get; set; }
    protected Vector2 LeftDirection { get; set; }
    protected Vector2 RightDirection { get; set; }
    protected SpriteRenderer Renderer { get; set; }
    protected Rigidbody2D Body { get; set; }
}

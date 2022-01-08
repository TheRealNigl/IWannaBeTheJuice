using UnityEngine;

public abstract class Background : MonoBehaviour
{
    protected Vector3 Location { get; set; }
    protected Vector3 Rotation { get; set; }
    protected MeshRenderer Renderer { get; set; }
    protected BoxCollider2D BoxCollider { get; set; }
    protected Rigidbody2D Body { get; set; }
    protected MeshFilter Mesh { get; set; }
}
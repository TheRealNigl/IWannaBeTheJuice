using UnityEngine;

public abstract class ScrollingObject : MonoBehaviour 
{
    protected Vector2 Direction ;
    protected Vector2 Location ;
    protected Transform Transform ;
    protected CircleCollider2D CircleCollider ;
    protected BoxCollider2D BoxCollider ;
    protected SpriteRenderer Renderer ;
    protected Rigidbody2D Body ;

    public abstract void OnNotify();
}
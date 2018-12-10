using UnityEngine;

public class JuiceDrop : ScrollingObject 
{
    private GameObject Object;
    private MoveLittle objectEvents = new MoveLittle();

    public void Start(){

        gameObject.name = "JuiceDrop";
        gameObject.tag = "Evil";

        Direction = Vector2.down;

        Location = new Vector2(RandomHelper.NextRandom(-8, 8), 8);

        Renderer = gameObject.GetComponent<SpriteRenderer>();
        if (Renderer == null) {
            Renderer = gameObject.AddComponent<SpriteRenderer>();
            Renderer.sprite = Resources.Load("Art/drop") as Sprite;
        }
        Body = gameObject.GetComponent<Rigidbody2D>();
        if (Body == null) {
            Body = gameObject.AddComponent<Rigidbody2D>();
            Body.bodyType = RigidbodyType2D.Dynamic;
            Body.position = Location;
        } else {
            Body = gameObject.GetComponent<Rigidbody2D>();
            Body.bodyType = RigidbodyType2D.Dynamic;
            Body.position = Location;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            Death();
        }
    }

    public void Death() {
        Destroy(this.gameObject);
    }

    public override void OnNotify() {
        // Move(objectEvents.GetJumpForce());
    }
}
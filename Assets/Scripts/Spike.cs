using UnityEngine;

public class Spike : ScrollingObject 
{
    private MoveLittle objectEvents = new MoveLittle();

    public void Start() {
        gameObject.name = "Spike";
        gameObject.tag = "Evil";

        Direction = Vector2.left;

        Location = new Vector2(15, 1);

        Renderer = gameObject.GetComponent<SpriteRenderer>();
        if(Renderer == null){
            Renderer = gameObject.AddComponent<SpriteRenderer>();
            Renderer.sprite = Resources.Load("Art/roll") as Sprite;
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
        //Destroy(this.gameObject);
    }

    public void FixedUpdate() {
        Body.AddForce(Direction * 650f * Time.deltaTime);
    }

    public override void OnNotify() {

    }
}
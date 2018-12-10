using UnityEngine;

public class Boss : Movement {

    public bool isDead;

    private float x, y;

    public void Start() {

        isDead = false;

        gameObject.name = "Boss";
        gameObject.tag = "Boss";

        LeftDirection = Vector2.left;
        RightDirection = Vector2.right;
        Speed = 200f;
        Location = Vector2.zero;

        Body = gameObject.GetComponent<Rigidbody2D>();
        if (Body == null) {
            gameObject.AddComponent<Rigidbody2D>();
            Body.bodyType = RigidbodyType2D.Dynamic;
        }
        Body.position = Location;
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void Move(){
        x = Mathf.Cos(Time.deltaTime);
        y = Mathf.Sin(Time.deltaTime);

        Body.AddForce(Vector2.up * new Vector2(x, y) * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {

    }
}

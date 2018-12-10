using UnityEngine;

public class Player : Movement
{
    private float xSpeed, ySpeed;
    private float Multiplyer;

    public void Start() {

        gameObject.name = "Player";
        gameObject.tag = "Player";

        LeftDirection = Vector2.left;
        RightDirection = Vector2.right;

        xSpeed = 55f;
        ySpeed = 35f;
        Multiplyer = 10f;

        Location = Vector2.zero;

        Body = gameObject.GetComponent<Rigidbody2D>();
        if(Body == null) {
            gameObject.AddComponent<Rigidbody2D>();
            Body.bodyType = RigidbodyType2D.Dynamic;
        }
        Body.position = Location;
    }

    public void Update() {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Body.AddForce(LeftDirection * xSpeed * Multiplyer * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Body.AddForce(RightDirection * xSpeed * Multiplyer * Time.deltaTime);
        }
        Jump = Input.GetKey(KeyCode.Space) ? true : false;
    }

    public void FixedUpdate() {

        if (Jump) {
            Body.bodyType = RigidbodyType2D.Dynamic;
            Body.AddForce(new Vector2(0f, Vector2.up.y * ySpeed));
        } else if(!Jump && IsGrounded()) {
            Body.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private bool IsGrounded() {

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        int GroundLayer = LayerMask.NameToLayer("Ground");

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, GroundLayer);
        if (hit.collider != null) {
            return true;
        } else {
            return false;
        }
    }

    public Vector2 StartLocation(){
        return Location;
    }
}
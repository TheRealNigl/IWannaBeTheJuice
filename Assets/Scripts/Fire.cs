using UnityEngine;

public class Fire : ScrollingObject
{
    private MoveLittle objectEvents = new MoveLittle();
    private MeshRenderer MeshRenderer;
    private MeshFilter MeshFilter;

    public void Start() {
        gameObject.name = "Fire";
        gameObject.tag = "Evil";

        Location = new Vector3(RandomHelper.NextRandom(-5, 5), -5.5f, 0);
        transform.position = Location;

        MeshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (MeshRenderer == null) {
            MeshRenderer = gameObject.AddComponent<MeshRenderer>();
            MeshRenderer.material = Resources.Load("Art/Fire") as Material;
        } else {
            MeshRenderer.material = Resources.Load("Art/Fire") as Material;
        }
        MeshFilter = gameObject.GetComponent<MeshFilter>();
        if (MeshFilter == null) {
            MeshFilter = gameObject.AddComponent<MeshFilter>();
        }
        Body = GetComponent<Rigidbody2D>();
        if (Body == null) {
            Body = gameObject.AddComponent<Rigidbody2D>();
            Body.bodyType = RigidbodyType2D.Static;
            Body.position = Location;
        } else {
            Body = gameObject.GetComponent<Rigidbody2D>();
            Body.bodyType = RigidbodyType2D.Static;
            Body.position = Location;
        }
    }

    public override void OnNotify() {

        Move(objectEvents.GetJumpForce());
    }

    private void Move(float jumpForce) {

        Body.AddForce(Direction * jumpForce * Time.deltaTime);
    }
}
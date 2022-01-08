using UnityEngine;

public class Ground : Background 
{
    public void SetSpawn(Vector3 location, Vector3 rotation)
    {
        gameObject.name = "Ground";
        gameObject.tag = "Ground";

        //Location = Camera.main.ScreenToWorldPoint(new Vector3(0, -5, 0));
        Location = location;

        Body = gameObject.GetComponent<Rigidbody2D>();
        if (Body == null){
            Body = gameObject.AddComponent<Rigidbody2D>();
            Body.bodyType = RigidbodyType2D.Static;
            transform.position = Location;
            transform.Rotate(rotation, Space.World);
        } else {
            Body.bodyType = RigidbodyType2D.Static;
            transform.position = Location;
            transform.Rotate(rotation, Space.World);
        }
        Renderer = gameObject.GetComponent<MeshRenderer>();
        if (Renderer == null){
            Renderer = gameObject.AddComponent<MeshRenderer>();
        }
        BoxCollider = gameObject.GetComponent<BoxCollider2D>();
        if (BoxCollider == null){
            BoxCollider = gameObject.AddComponent<BoxCollider2D>();
        }
        Mesh = gameObject.GetComponent<MeshFilter>();
        if(Mesh == null){
            Mesh = gameObject.AddComponent<MeshFilter>();
        }
    }
}
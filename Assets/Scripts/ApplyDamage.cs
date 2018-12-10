using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    private int Damage { get; set; }

    private ApplyDamage(){
        Damage = -1;
    }

    public int AddDamage(){
        return Damage;
    }
}
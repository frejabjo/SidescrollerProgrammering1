using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool IsPlayer = false;

    public int DamageValue = -1;
    public bool DealtDamageLastFrame = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(DealtDamageLastFrame == true)
        {
            DealtDamageLastFrame = false;
            return;
        }


        if (IsPlayer)
        {
            var EnemyScript = collision.gameObject.GetComponent<Goomba>();
            if (EnemyScript != null)
            {
                EnemyScript.TakeDamage(DamageValue);
                DealtDamageLastFrame = true;
            }
        }
        else
        {
            var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
            if (PlayerScript != null)
            {
                PlayerScript.TakeDamage(DamageValue);
                DealtDamageLastFrame = true;

            }
        }

    }
}

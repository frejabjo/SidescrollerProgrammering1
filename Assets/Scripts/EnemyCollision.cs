using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Goomba myEnemyScript = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 enemyScale = myEnemyScript.transform.localScale;
        enemyScale.x = -enemyScale.x;
        myEnemyScript.transform.localScale = enemyScale;
        myEnemyScript.MovementSign *= -1;
    }
}

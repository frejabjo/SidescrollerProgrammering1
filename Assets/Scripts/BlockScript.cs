using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    public Vector2 Dimensions = new Vector2(16.0f, 16.0f);
    public Vector2 LowerLeftCorner = new Vector2();

   void Update()
    {
        LowerLeftCorner = new Vector2(transform.position.x - (Dimensions.x * 0.5f),
            transform.position.y - (Dimensions.y * 0.5f));
    }


    public static bool CheckCollision(CollisionScript aObject1, CollisionScript aObject2) // a i "aObject" står för argument
    {
     if (aObject1.LowerLeftCorner.x < aObject2.LowerLeftCorner.x + aObject2.Dimensions.x && 
         aObject1.LowerLeftCorner.x + aObject1.Dimensions.x > aObject2.LowerLeftCorner.x &&
         aObject1.LowerLeftCorner.y < aObject2.LowerLeftCorner.y + aObject2.Dimensions.y &&
         aObject1.LowerLeftCorner.y + aObject2.Dimensions.y < aObject2.LowerLeftCorner.y)
        {
            return true;
        }
        return false;
    }



}
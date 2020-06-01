using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koszulka : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("matador"))
        {

            Destroy(gameObject);

            player.i.nextlvl();

        }
        else if (col.gameObject.CompareTag("Dead"))
        {

            player.i.deads("Your Polo tshirt was destroyed");
          //  player.i.reload();


        }
    }
}

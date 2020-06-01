using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enevtlap : MonoBehaviour
{
    // Start is called before the first frame update
 
        // Start is called before the first frame update

        public int s;
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("matador"))
            {
                switch (s)
                {
                    case 0:
                         
                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                }

                player.i.timee = (int)Time.time+ 10;
                player.i.mode  = s;

            Destroy(gameObject);
            }
            else if (col.gameObject.CompareTag("Dead"))
            {

                Destroy(gameObject);
                //  player.i.reload();


            }
        }
    

}

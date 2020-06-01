using System.Collections;
using System.Collections.Generic;
using SgLib;
using UnityEngine;

public class block : MonoBehaviour
{
    // Start is called before the first frame update
     int hp_max = 0;
    public int hp = 0;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ball"))
        {
            // SoundManager.Instance.PlaySound(SoundManager.Instance.eploring);
            //   gameManager.CheckGameOver(gameObject);
            //player.spawn_ball();
            hp--;

            player.i.punkty++;
        
            player.i.t_punkty.text = "" + player.i.punkty ;

            if ((PlayerPrefs.GetInt("gamemode_surv", 0) == 1))
                player.i.t_punkty.text += " Surv";


             var cc = GetComponent<SpriteRenderer>().color;

             cc.a = (float)((float)hp / (float)hp_max);
             GetComponent<SpriteRenderer>().color = cc;

            SoundManager.Instance.PlaySound(SoundManager.Instance.hitGold);


            player.i.run_hit(col.contacts[0].point, cc);

            if (hp <=0)
            {

               
                if (longer) Instantiate(player.i.glng, transform.position, Quaternion.identity);
                if (slow) Instantiate(player.i.gslow, transform.position, Quaternion.identity);
                if (faster) Instantiate(player.i.gfast, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }


    public bool longer = false;
    public bool slow = false;
    public bool faster = false;
    private void Start()
    {
        max_points+= hp;

        hp_max = hp;
    }

    public static int  max_points = 0;

    private void LateUpdate()
    {

    }

}

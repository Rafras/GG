using UnityEngine;
using System.Collections;
using SgLib;

public class BallController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private bool isChecked;
    // Use this for initialization
    void Start()
    {
     //   gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
      //  gameObject.SetActive(false);
     //   spriteRenderer = GetComponent<SpriteRenderer>();
      //  transform.position += (Random.value >= 0.5f) ? (new Vector3(0.2f, 0)) : (new Vector3(-0.2f, 0));
     //   gameObject.SetActive(true);


        GetComponent<Rigidbody2D>().simulated = false;

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.01f);
        StartCoroutine(waits());
    }

    IEnumerator waits()
    {
        yield return new WaitForSeconds(1);

        GetComponent<Rigidbody2D>().simulated = true;
        print("WaitAndPrint " + Time.time);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Dead"))
        {
            player.i.lives_count--;

            if (player.i.lives_count < 0)
            {


                player.i.deads("Your did't survive spikes");
                    
            }
            else
            {
                for (var i = 0; i < 3; i++)
                {

                    if (player.i.lives_count <= i)
                        player.i.lives[i].SetActive(false);
                    else player.i.lives[i].SetActive(true);
                }
                SoundManager.Instance.PlaySound(SoundManager.Instance.eploring);
                //   gameManager.CheckGameOver(gameObject);
                player.spawn_ball();
            }
        }
    }



    private void Update()
    {
        var rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb.velocity);
        if ( Mathf.Abs(rb.velocity.x) <   0.01f && Mathf.Abs(rb.velocity.y)  < 0.01f)
        {
            rb.AddForce(new Vector2(0,111f));
        }

    }



}

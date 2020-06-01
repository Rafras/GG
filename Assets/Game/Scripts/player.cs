using System;
using SgLib;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class player : MonoBehaviour
{

    public static float site = 1;

    public Transform transf;

    public Text t_punkty;
    public int punkty = 0;

    public GameObject[] lives;

    public bool started = false;

    public GameObject start;
    public GameObject dead;
    public GameObject next;

    public Text whydead;

    public bool win = false;

    public int lvl_name = 1;

    public GameObject glng;
    public GameObject gslow;

    public GameObject gfast;


    public int lives_count = 3;


    public Transform left;
    public Transform right;


    public Text points;
    public GameObject rnk;
    public Text max_points;
    public void reload()
    {
        block.max_points = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public int timee;
    public int mode = -1;

    public void showrnk(bool cc)
    {
        rnk.SetActive(cc);

        if (cc)
        {
            points.text = t_punkty.text;
            max_points.text =""+ block.max_points;
        }

    }

    public GameObject[] lvlbtn;

    public void check_lvls_has()
    {

        for (var lvls = 0; lvls < 10; lvls++)
        {
            var j = PlayerPrefs.GetInt("" + (lvls+1), 0);

            lvlbtn[lvls].GetComponentInChildren<Text>().text = (lvls+1) + " lvl";

            if (j == 0)
            {
                lvlbtn[lvls].GetComponentInChildren<Image>().color = new Color(0.5f, 0.5f, 0.5f);
             
            }
            else
            {
                lvlbtn[lvls].GetComponentInChildren<Image>().color = new Color(1, 1, 1);

     

            }
        }

    }

    public GameObject flip;


    public bool gamemode_surv = false;
    public void Update()
    {

        if (mode == -1)
        {

            ball.GetComponent<Rigidbody2D>().mass = 1;
            flip.transform.localScale = new Vector3(1,1,1);
        }

        if (timee > Time.time)
        {
            switch (mode)
            {
                case 0:
                    ball.GetComponent<Rigidbody2D>().mass = 0.01f;
                    break;


                case 1:

                    ball.GetComponent<Rigidbody2D>().mass = 3f;

                    break;
                case 2:

                    flip.transform.localScale = new Vector3(2, 1, 1);

                    break;
            }
        }
        else
        {
            mode = -1;
        }

    }


    public void Start()
    {

        check_lvls_has();



        StartCoroutine(waitss());

    }



    public GameObject part;
    public void run_hit(Vector3 vv,Color c)
    {


        var ggg = Instantiate(part, vv, Quaternion.identity);
        c.a = 1;
        ggg.GetComponent<ParticleSystem>().startColor = c;
        StartCoroutine(waitssxx(ggg));

    }
    IEnumerator waitssxx(GameObject gg)
    {
        yield return new WaitForSeconds(1f);

        Destroy(gg);

    }

    IEnumerator waitss()
    {
        yield return new WaitForSeconds(0.01f);


        ttt.text = SceneManager.GetActiveScene().name + " Lvl";

        ttt.text += " / Best Score " + block.max_points;

        if (PlayerPrefs.GetInt("gamemode_surv", 0) == 1)
        {


            player.i.punkty = PlayerPrefs.GetInt("gamemode_surv_p", 0);

            player.i.t_punkty.text = "" + player.i.punkty + " Surv";




            ttt.text += " Survival mode";
        }

    }


public void play_surviv()
    {

        if (pausegm)
        {
            pausegm = false;
            butnpaus.GetComponentInChildren<Text>().text = "||";
            Time.timeScale = 1;
            SoundManager.Instance.PlaySound(SoundManager.Instance.clickButton);
            start.SetActive(false);
            return;
        }


        PlayerPrefs.SetInt("gamemode_surv" , 1);
         PlayerPrefs.SetInt("gamemode_surv_p", 0);
        //  int r =Random.Range(1, 10);

        //  SceneManager.LoadScene(r);
        SoundManager.Instance.PlaySound(SoundManager.Instance.clickButton);

        started = true;
        spawn_ball();
        start.SetActive(false);
    }


    public void deads(string s)
    {


        if (win) return;

    


        PlayerPrefs.SetInt("gamemode_surv", 0);


        SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
        whydead.text = s;
        dead.SetActive(true);
        showrnk(true);
    }

    public void stgame()
    {

        if (pausegm)
        {
            pausegm = false;
            butnpaus.GetComponentInChildren<Text>().text = "||";
            Time.timeScale = 1;
            SoundManager.Instance.PlaySound(SoundManager.Instance.clickButton);
            start.SetActive(false);
            return;
        }

        PlayerPrefs.SetInt("gamemode_surv", 0);
        PlayerPrefs.SetInt("gamemode_surv_p", 0);
        SoundManager.Instance.PlaySound(SoundManager.Instance.clickButton);


        punkty = 0;
        t_punkty.text =""+ 0;
        started = true;
        spawn_ball();
        start.SetActive(false);
        //showrnk(true);
    }


    public void selectload_lvl(string lvl)
    {
        if (PlayerPrefs.GetInt("gamemode_surv", 0) == 1) return;
        SoundManager.Instance.PlaySound(SoundManager.Instance.clickButton);


     var j =   PlayerPrefs.GetInt("" + lvl, 0);
        

     if (j == 1)

        SceneManager.LoadScene(lvl);

        //   PlayerPrefs.SetInt("lvl", lvl_name);
    }
    public void nextlvl()
    {
        if (PlayerPrefs.GetInt("gamemode_surv", 0) == 1)
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.rewarded);
            PlayerPrefs.SetInt("gamemode_surv_p", player.i.punkty);

            int r = UnityEngine.Random.Range(1, 10);

            SceneManager.LoadScene("" + r);

            return;
        }

        Destroy(ballp);
        SoundManager.Instance.PlaySound(SoundManager.Instance.rewarded);
        win = true;
        next.SetActive(true);
        //lvl_name++;
        var nm = SceneManager.GetActiveScene().name;


      

        PlayerPrefs.SetInt("" + (Int32.Parse(nm) + 1), 1);




 

        showrnk(true);
        //   PlayerPrefs.SetInt("lvl", lvl_name);
    }


    public Text ttt;

    private bool pausegm = false;





    public GameObject butnpaus;
    public void pausegamwe()
    {
        pausegm = !pausegm;

        if (pausegm)
        {
            butnpaus.GetComponentInChildren<Text>().text = "|>";
            Time.timeScale = 0;

            start.SetActive(true);


        }
        else
        {
            butnpaus.GetComponentInChildren<Text>().text = "||";
            Time.timeScale = 1;
            start.SetActive(false);
        }

    }

    public void load_nexlvl()
    {

        if (PlayerPrefs.GetInt("gamemode_surv", 0) == 1)
        {

            PlayerPrefs.SetInt("gamemode_surv_p",  player.i.punkty);

            int r =  UnityEngine.Random.Range(1,10);

            SceneManager.LoadScene("" + r);

            return;
        }

            block.max_points = 0;


        var nm = SceneManager.GetActiveScene().name;

       if (Int32.Parse(nm) + 1 > 10) SceneManager.LoadScene("10");


        SceneManager.LoadScene(""+(Int32.Parse(nm) +1));
        //SceneManager.LoadScene(lvl_name + "");

    }
    public GameObject ball;

    public static player i;


    private void Awake()
    {


        i = this;

        ttt.text = SceneManager.GetActiveScene().name + " Lvl";

        //ttt.text += " / Best Score " + block.max_points;

        if (PlayerPrefs.GetInt("gamemode_surv", 0) == 1)
        {


            player.i.punkty = PlayerPrefs.GetInt("gamemode_surv_p", 0);

            player.i.t_punkty.text = "" + player.i.punkty + " Surv";


     

            ttt.text += " Survival mode";
        }

        block.max_points = 0;

        PlayerPrefs.SetInt("1", 1);
   
      /*  lvl_name = PlayerPrefs.GetInt("lvl");
        if (lvl_name == 0) lvl_name = 1;

        if (SceneManager.GetActiveScene().name != lvl_name+"")
        {
            load_nexlvl();
        }
        */

    }

    float speed = 5;
    // Update is called once per frame

    public static GameObject ballp;

    public static void spawn_ball()
    {

        if (ballp != null) Destroy(ballp);

        var JJ = i.transform.position;
        JJ.y += 3.5f;
        JJ.x -= 1;
        ballp =  Instantiate(i.ball, JJ, Quaternion.identity);

      //  ballp.transform.position = i.transf.position;
    }

    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);

            transform.localScale = new Vector3(-1, 1, 1);
            GetComponentInChildren<Animator>().SetBool("walk", true);
            site =1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

            transform.Translate(Time.deltaTime * -speed, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
            site = -1;
            GetComponentInChildren<Animator>().SetBool("walk", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("walk", false);
        }

        var uuu = i.transform.position;
        if (i.left.position.x + 2.8f > uuu.x)
        {

            uuu.x = i.left.position.x + 2.8f;
             
            i.transform.position = uuu;
        }
        else if (i.right.position.x - 2.8f < uuu.x)
        {
            uuu.x = i.right.position.x - 2.8f;

            i.transform.position = uuu;
        }


    }
}

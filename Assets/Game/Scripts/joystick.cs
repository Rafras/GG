using SgLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour
{
    // Start is called before the first frame update



    void Start()
    {
        
    }


    const float hit = 10;

    private void FixedUpdate()
    {
            if (Input.GetMouseButton(0))
            {

               SoundManager.Instance.PlaySound(SoundManager.Instance.tick);

            var rb = GetComponent<Rigidbody2D>();


                // transform.Rotate(0, 0, 331);

                var b = GetComponent<Rigidbody2D>();
                //  b.MoveRotation(33);

                // b.AddTorque(5);


                //   transform.localEulerAngles = new Vector3(0f,0f,-45f);

                if (player.site == -1) b.AddTorque(-45f * hit * Mathf.Deg2Rad, ForceMode2D.Impulse); else b.AddTorque(45f* hit * Mathf.Deg2Rad, ForceMode2D.Impulse);



            }


            transform.position = transform.parent.position;
    }

    // Update is called once per frame



}

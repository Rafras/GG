using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update

     GameObject arr;

    float point = 1.87f;



    public GameObject prfarr;


    private void Start()
    {
        arr = Instantiate(prfarr);
    }

    private void FixedUpdate()
    {




        var bp = player.ballp.transform.position;
        var x = Mathf.Lerp(transform.position.x, bp.x  ,0.1f);
        var y = Mathf.Lerp(transform.position.y, Mathf.Max(bp.y,0), 0.1f);
        var gg = transform.position;
        gg.x = x;
     
        gg.y = y;
        transform.position = gg;


 /*      var aaarr  = arr.transform.position;

        Vector2 ViewportPosition = GetComponent<Camera>().WorldToViewportPoint(player.i.gameObject.transform.position);
   // var proportionalPosition = new Vector2(ViewportPosition.x * CanvasRect.sizeDelta.x, ViewportPosition.y * CanvasRect.sizeDelta.y);

        Vector2 proportionalPosition = new Vector2(
 ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
 ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

        aaarr.x = proportionalPosition.y;*/

        if (y < point)
        {

            arr.SetActive(false);
                

        }else
        {
            arr.SetActive(true);


            var rx = bp.x - player.i.transform.position.x;

            bp.x -=  rx;
            bp.y -= 2;
            arr.transform.position = bp;

        }

     
    }
}

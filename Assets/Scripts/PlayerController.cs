using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 80.0f;
    private Rigidbody2D rb = null;
    [SerializeField] GameObject ballPrefab,canvas,twicaZone2,twicaZone3,countor,valsePrefab;
    [SerializeField] Transform shotPoint;
    public int ballCount,finishCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, 0)*Time.deltaTime*100;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, 0)*Time.deltaTime*100;
        }

        if (Input.GetKeyDown(KeyCode.Space) && finishCount < 10)
        {
            Vector3 pos = shotPoint.position;
            pos.x = pos.x*4.7f;
            pos.y = 170;
            pos.z = 0;
            GameObject go = Instantiate(ballPrefab, pos, shotPoint.rotation);
            go.transform.SetParent(canvas.transform, false);

            BallController ballController;
            ballController = ballPrefab.GetComponent<BallController>();
            ballController.ballSE = true;
            finishCount++;
        }

        if (Input.GetKeyDown(KeyCode.T) && ballCount == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (ballCount > 2)
        {
            twicaZone2.SetActive(true);
            Debug.Log("TwiceZone2");
            countor.SetActive(false);
        }

        if (ballCount > 4)
        {
            twicaZone3.SetActive(true);
            Debug.Log("TwiceZone3");
        }

        if (ballCount > 100)
        {
            GameObject go2 = Instantiate(valsePrefab,new Vector3(126,40,0),Quaternion.identity);
            go2.transform.SetParent(canvas.transform, false);
            Debug.Log("Valse");
            Invoke("Valse",2);
        }

        if (ballCount > 500)
        {
            //SceneManager.LoadScene("Scene2");
        }
    }

    void Valse()
    {
        SceneManager.LoadScene("Scene2");
    }
}
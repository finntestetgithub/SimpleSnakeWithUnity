using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Rigidbody2D snakeHead;
    Vector2 dirCurrent;
    private bool isAlive;

    Vector2 dirRight = new Vector2(1, 0);
    Vector2 dirLeft = new Vector2(-1, 0);
    Vector2 dirUp = new Vector2(0, 1);
    Vector2 dirDown = new Vector2(0, -1);

    //Init Snake (Direction, start Movement)
    void Start()
    {
        isAlive = true;
        snakeHead = GetComponent<Rigidbody2D>();
        dirCurrent = dirRight;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) && dirCurrent != dirLeft)
        {
            dirCurrent = dirRight;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && dirCurrent != dirRight)
        {
            dirCurrent = dirLeft;
        }
        if (Input.GetKey(KeyCode.UpArrow) && dirCurrent != dirDown)
        {
            dirCurrent = dirUp;
        }
        if (Input.GetKey(KeyCode.DownArrow) && dirCurrent != dirUp)
        {
            dirCurrent = dirDown;
        }
    }

    private IEnumerator Move()
    {
        while(isAlive)
        {
            if (snakeHead != null)
            {
                snakeHead.transform.Translate(dirCurrent);
            }
            yield return new WaitForSeconds(0.5F);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.gameObject.CompareTag("Food"))
        {
            snakeHead.transform.position = new Vector2(-9.5F, 1.5F);
            Destroy(snakeHead);
            isAlive = false;
        }
    }
}

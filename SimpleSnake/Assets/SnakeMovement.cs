using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public Rigidbody2D snakeHead;
    public GameObject snakeBody;
    Vector2 dirCurrent;
    private bool isAlive;
    private float speed = 0.4F;

    Vector2 dirRight = new Vector2(1, 0);
    Vector2 dirLeft = new Vector2(-1, 0);
    Vector2 dirUp = new Vector2(0, 1);
    Vector2 dirDown = new Vector2(0, -1);

    private LinkedList<GameObject> snakeBodyPosition = new LinkedList<GameObject>();
    private Vector2 posBeforeMove;
    private Vector2 posLastBody;

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
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 1;
        }
        else
        {
            speed = 0.4F;
        }
    }

    //Snake moves every 0.4 seconds. (Head moves in dirCurrent, last body part gets removed and placed below head)
    private IEnumerator Move()
    {
        while(isAlive)
        {
            if (snakeHead != null)
            {
                posBeforeMove = snakeHead.transform.position;
                snakeHead.transform.Translate(dirCurrent);

                if (snakeBodyPosition.Count != 0)
                {
                    posLastBody = snakeBodyPosition.Last.Value.gameObject.transform.position;
                    Destroy(snakeBodyPosition.Last.Value.gameObject);
                    snakeBodyPosition.RemoveLast();
                    snakeBodyPosition.AddFirst(Instantiate(snakeBody, posBeforeMove, Quaternion.identity));
                }
            }
            yield return new WaitForSeconds(speed);
        }
    }

    //Get List of all Snake-Body Positions.
    public LinkedList<Vector2> getSnakeBodyPosition()
    {
        LinkedList<Vector2> snakeBodyPositions = new LinkedList<Vector2>();
        if (snakeBodyPosition.Count != 0)
        {
            foreach (GameObject body in snakeBodyPosition)
            {
                snakeBodyPositions.AddFirst(body.gameObject.transform.position);
            }
        }
        return snakeBodyPositions;
    }

    //Collision-Detection. When snake collides with food, snake enlarges. Otherwise the game ends.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.gameObject.CompareTag("Food"))
        {
            snakeHead.transform.position = new Vector2(-9.5F, 1.5F);
            Destroy(snakeHead);
            isAlive = false;
        }
        else
        {
            if(snakeBodyPosition.Count == 0)
            {
                snakeBodyPosition.AddFirst(Instantiate(snakeBody,posBeforeMove, Quaternion.identity));
            }
            else
            {
                snakeBodyPosition.AddLast(Instantiate(snakeBody, posLastBody, Quaternion.identity));
            }
        }
    }
}

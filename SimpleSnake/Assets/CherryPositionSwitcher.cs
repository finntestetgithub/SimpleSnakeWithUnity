using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryPositionSwitcher : MonoBehaviour
{
    public SpriteRenderer cherry;
    public SnakeMovement snakeMovementScript;
    public SpriteRenderer wallTop;
    public SpriteRenderer wallBot;
    public SpriteRenderer wallRight;
    public SpriteRenderer wallLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        snakeMovementScript = GameObject.Find("snakehead").GetComponent<SnakeMovement>();
        cherry = GetComponent<SpriteRenderer>();
        wallTop = GetComponent<SpriteRenderer>();
        wallBot = GetComponent<SpriteRenderer>();
        wallRight = GetComponent<SpriteRenderer>();
        wallLeft = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(cherry != null)
        {
            //cherry.transform.
        }
    }

    private void possibleRandom()
    {
        bool isNotValid = true;
        while (isNotValid)
        {
            float x = Random.Range(wallLeft.transform.position.x + 1, wallRight.transform.position.x - 1);
            float y = Random.Range(wallBot.transform.position.x + 1, wallTop.transform.position.y - 1);

            int xRounded = (int)x;
            int yRounded = (int)y;

            if(x % xRounded > 0.5)
            {
                //x = (x)
            }
        }
    }
}

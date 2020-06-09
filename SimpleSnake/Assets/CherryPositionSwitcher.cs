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

    private float maxY;
    private float maxX;
    private float minY;
    private float minX;
    
    // Start is called before the first frame update
    void Start()
    {
        snakeMovementScript = GameObject.Find("snakehead").GetComponent<SnakeMovement>();
        cherry = GetComponent<SpriteRenderer>();
        wallTop = GetComponent<SpriteRenderer>();
        wallBot = GetComponent<SpriteRenderer>();
        wallRight = GetComponent<SpriteRenderer>();
        wallLeft = GetComponent<SpriteRenderer>();

        minX = wallLeft.transform.position.x + 1;
        maxX = wallRight.transform.position.x - 1;
        minY = wallBot.transform.position.y + 1;
        maxY = wallBot.transform.position.y - 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(cherry != null)
        {
            float[] xy = possibleRandom();
            Vector2 newCherryPosition = new Vector2(xy[0], xy[1]);
            cherry.transform.position = newCherryPosition;
        }
    }

    private float[] possibleRandom()
    {
        bool isNotValid = true;
        float[] xy = new float[2];

        //TO-DO: Add check if Snake is not placed!
        while (isNotValid)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minX, maxX);
            xy = convertIntoRealCoordinates((int) x, (int) y);
            isNotValid = false;
        }
        return xy;
    }

    //TO-DO: Testing!!
    private float[] convertIntoRealCoordinates(int x, int y)
    {
        float[] newXY = new float[2];
        float newX = 0F;
        float newY = 0F;

        if(x < -9)
        {
            newX = -10.5F;
        }
        else
        {
            newX = x + 0.5F;
        }

        if (y < -3)
        {
            newY = -4.5F;
        }
        else
        {
            newY = y + 0.5F;
        }

        newXY[0] = newX;
        newXY[1] = newY;

        return newXY;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for switching the food (cherry) position after collision with snake
public class CherryPositionSwitcher : MonoBehaviour
{
    public SpriteRenderer food;
    public SnakeMovement snakeMovementScript;

    public SpriteRenderer wallTop;
    public SpriteRenderer wallBot;
    public SpriteRenderer wallRight;
    public SpriteRenderer wallLeft;

    private float maxFoodY;
    private float maxFoodX;
    private float minFoodY;
    private float minFoodX;
    
    //Initialisation
    void Start()
    {
        snakeMovementScript = GameObject.Find("snakehead").GetComponent<SnakeMovement>();

        minFoodX = wallLeft.gameObject.transform.localPosition.x+1;
        maxFoodX = wallRight.gameObject.transform.localPosition.x-1;
        minFoodY = wallBot.gameObject.transform.localPosition.y+1;
        maxFoodY = wallTop.gameObject.transform.localPosition.y-1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(food != null)
        {
            food.transform.position = PossibleRandomXY();
        }
    }

    //Calculates random xy-coordinates of new food.
    //Checks if food is inside of the borders + not colliding with snake.
    private Vector2 PossibleRandomXY()
    {
        Vector2 xy = new Vector2(0, 0);
        bool isNotValid = true;

        while(isNotValid)
        {
            LinkedList<Vector2> snakeBodyPositions = snakeMovementScript.getSnakeBodyPosition();

            float x = Random.Range(minFoodX, maxFoodX);
            float y = Random.Range(minFoodY, maxFoodY);

            xy = new Vector2((int)x + 0.5F, (int)y + 0.5F);

            if(!snakeBodyPositions.Contains(xy)){
                isNotValid = false;
            }
        }
        return xy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
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
            float[] newFoodXY = possibleRandomXY();
            Vector2 newCherryPosition = new Vector2(newFoodXY[0], newFoodXY[1]);
            food.transform.position = newCherryPosition;
        }
    }

    private float[] possibleRandomXY()
    {
        float[] finalFoodXY = new float[2];
        bool isNotValid = true;

        //TO-DO: Add check if Snake is not placed!
        while(isNotValid)
        {
            float x = Random.Range(minFoodX, maxFoodX);
            float y = Random.Range(minFoodY, maxFoodY);
            finalFoodXY[0] = (int)x + 0.5F;
            finalFoodXY[1] = (int)y + 0.5F;
            isNotValid = false;
        }
        return finalFoodXY;
    }
}

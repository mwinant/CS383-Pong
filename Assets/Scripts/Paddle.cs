using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    float height;
    string input;
    public bool isRight;
    void Start()
    {
        height = transform.localScale.y;
        speed = 5f;
        
    }

    public void Init(bool isRightPaddle){
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;
        if (isRightPaddle){
            //place paddle on right side of the screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; //Move a bit to the left
            input = "PaddleRight";
        }
        else{
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x; //Move a bit to the right
            input = "PaddleLeft";
        }
        transform.position = pos;
        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0){
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0){
            move = 0;
        }

        transform.Translate (move * Vector2.up);

    }
}

using UnityEditor;
using UnityEngine;

public class ObstacleLogic : MonoBehaviour
{

    [SerializeField] float Speed;
    private GameObject top;
    private GameObject bottom;
    /*[SerializeField] float minBottomScale = 0.5f;
    [SerializeField] float maxBottomScale = 3f;*/
    private float firstValueT;
    private float firstValueB;
    private float firstPosX;
    private bool isReady;
    private bool ToMove = true;
    
    
    // Start is called before the first frame update

    private void Awake()
    {
        Event_logic.PlayerDied += Stop;
        
        top = gameObject.transform.GetChild(0).gameObject;
        bottom = gameObject.transform.GetChild(1).gameObject;


        firstValueT = top.transform.localScale.y;
        firstValueB = bottom.transform.localScale.y;
        firstPosX = transform.position.x;

    }
    /*private void OnDisable()
    {
        Event_logic.PlayerDied -= Stop;
    }*/
    private void Stop()
    {
        ToMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ToMove) return;

        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        Swaping();
        ChangeBorder();
    }
    private void Swaping()
    {

        if (transform.position.x < -7f)
        {
            transform.position = new Vector2(1.5f, transform.position.y);
            isReady = true;
        }
    }

    private void ChangeBorder()

    {
        if (!isReady) return;
        bottom.transform.localScale += new Vector3(0, 0, 0);

        top.transform.localScale += new Vector3(0, 0, 0);

        int randomNum = Random.Range(0, 19);

        if (firstValueB > randomNum)
        {
            float difference = firstValueB - randomNum;



            bottom.transform.localScale = new Vector3(1, randomNum, 1);

            top.transform.localScale = new Vector3(1, firstValueB + difference, 1);



            isReady = false;

        }

        else if (firstValueB < randomNum)

        {
            float difference = randomNum - firstValueB;

            bottom.transform.localScale = new Vector3(1, randomNum, 1);

            top.transform.localScale = new Vector3(1, firstValueB - difference, 1);

            isReady = false;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Event_logic.OnPlayerScore();
    }

}

using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(Rigidbody))]

public class followMouse : MonoBehaviour
{
    public float Zaxis;
    public Camera cam;
    private Rigidbody2D rb;

    private float xMovement;
    private float yMovement;

    public float mouseSensitivity;

    //private bool isMovingRight;
    //private Vector2 lastPos;

    public GameObject leftController;
    public GameObject rightController;

    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
        
    }


    void Update()
    {

        if(Time.time < 0.2f)
        {
            return;
        }
        //moving right
        /*if(transform.position.x > lastPos.x)
        {
            isMovingRight = true;
        }
        else
        {
            isMovingRight = false;
        }*/
        if(gameOver == false)
        {
            xMovement += Input.GetAxis("Mouse X");
            yMovement += Input.GetAxis("Mouse Y");
        }
        else
        {
            Cursor.visible = true;
        }
        


        //if(isMovingRight == true)
        //{
        //    leftController.GetComponent<SpriteRenderer>().enabled = false;
        //    rightController.GetComponent<SpriteRenderer>().enabled = true;
        //}
        //else
        //{
        //    leftController.GetComponent<SpriteRenderer>().enabled = true;
        //    rightController.GetComponent<SpriteRenderer>().enabled = false;
        //}

        //lastPos = transform.position;

    }


    // Update is called once per frame
    void FixedUpdate()
    {


        //float xMovement = Input.GetAxis("Mouse X");
        //float yMovement = Input.GetAxis("Mouse Y");

        //transform.Translate(new Vector2(xMovement, yMovement));
        if (gameOver == false)
        {
            rb.MovePosition(transform.position + (new Vector3(xMovement, yMovement, 0) * mouseSensitivity));

            xMovement = 0f;
            yMovement = 0f;
        }
        

        //Vector3 mousePosition = Input.mousePosition;



        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //transform.position = new Vector3(mousePosition.x, mousePosition.y, Zaxis);

        //Debug.Log(cam.ScreenToWorldPoint(mousePosition).ToString());
        

    }
}

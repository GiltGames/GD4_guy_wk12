using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public Vector2 inputDirection,lookDirection;
    Animator anim;
    [SerializeField] GameObject gmoDpad;
    [SerializeField] Transform trnKnob;
    [SerializeField] Vector3 vecStart, vecEnd;
    [SerializeField] float fltDpadRadius;
    [SerializeField] float fltDpadRadiusMin;
    [SerializeField] bool isMoveOK;
    [SerializeField] float fltRightLimit;
    [SerializeField] Touch tchMainTouch;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //makes the character look down by default
        lookDirection = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        //getting input from keyboard controls


        calculateMobileInput();
#if UNITY_STANDALONE


        //calculateDesktopInputs();

#elif UNITY_WEBGL || UNITY_EDITOR

#else

      //calculateTouchInput();
#endif
        //sets up the animator
        animationSetup();

        //moves the player
        transform.Translate(inputDirection * moveSpeed * Time.deltaTime);
    }


    void calculateDesktopInputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(x, y).normalized;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }

    }


    void animationSetup()
    {
        //checking if the player wants to move the character or not
        if (inputDirection.magnitude > 0.1f)
        {
            //changes look direction only when the player is moving, so that we remember the last direction the player was moving in
            lookDirection = inputDirection;

            //sets "isWalking" true. this triggers the walking blend tree
            anim.SetBool("isWalking", true);
        }
        else
        {
            // sets "isWalking" false. this triggers the idle blend tree
            anim.SetBool("isWalking", false);

        }

        //sets the values for input and lookdirection. this determines what animation to play in a blend tree
        anim.SetFloat("inputX", lookDirection.x);
        anim.SetFloat("inputY", lookDirection.y);
        anim.SetFloat("lookX", lookDirection.x);
        anim.SetFloat("lookY", lookDirection.y);


        if (Input.touchCount > 1)
        { 
            attack(); 
        }


    }

    public void attack()
    {
        anim.SetTrigger("Attack");
    }

    void calculateMobileInput()
    {


        if (Input.GetMouseButtonDown(0))

        {
            
            
            vecStart = Input.mousePosition;

            fltRightLimit = Screen.width * .75f;

            if (vecStart.x < fltRightLimit)
            {

                gmoDpad.SetActive(true);
                gmoDpad.transform.position = vecStart;



            }
        }


        if (Input.GetMouseButton(0) && gmoDpad.activeInHierarchy == true)
        {
            vecEnd = Input.mousePosition;

            float x = vecEnd.x - vecStart.x;
            float y = vecEnd.y - vecStart.y;    

            Vector3 diff = vecEnd - vecStart;

            if (diff.magnitude > fltDpadRadius)
            {

                trnKnob.position = vecStart + diff.normalized * fltDpadRadius;

            }

            else

            {
                trnKnob.position = vecEnd;

            }

            if (diff.magnitude > fltDpadRadiusMin)
            {
                inputDirection = new Vector2(x, y).normalized;

            }
            else
            {
                inputDirection = Vector2.zero;
            }

        }



        if (Input.GetMouseButtonUp(0))

        {
            gmoDpad.SetActive(false);
            inputDirection = Vector2.zero;
            

        }

    }




    void calculateTouchInput()
    {
        if (Input.touchCount > 0)
        {

            tchMainTouch = Input.GetTouch(0);

            if (tchMainTouch.phase == TouchPhase.Began)

            {


                vecStart = tchMainTouch.position;

                if (vecStart.x < fltRightLimit)
                {

                    gmoDpad.SetActive(true);
                    gmoDpad.transform.position = vecStart;



                }
            }


            if ((tchMainTouch.phase == TouchPhase.Moved || tchMainTouch.phase == TouchPhase.Ended) && gmoDpad.activeInHierarchy == true)
            {
                vecEnd = tchMainTouch.position;

                float x = vecEnd.x - vecStart.x;
                float y = vecEnd.y - vecStart.y;

                Vector3 diff = vecEnd - vecStart;

                if (diff.magnitude > fltDpadRadius)
                {

                    trnKnob.position = vecStart + diff.normalized * fltDpadRadius;

                }

                else

                {
                    trnKnob.position = vecEnd;

                }

                if (diff.magnitude > fltDpadRadiusMin)
                {
                    inputDirection = new Vector2(x, y).normalized;

                }
                else
                {
                    inputDirection = Vector2.zero;
                }

            }

        }

        else

        {
            gmoDpad.SetActive(false);
            inputDirection = Vector2.zero;


        }

    }




    public void FnMouseOverPanel()
    {
        isMoveOK = true;

    }

   
}

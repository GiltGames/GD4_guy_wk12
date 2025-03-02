using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

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
    [SerializeField] PlayerInput inpPlayerInput;
    [SerializeField] InputAction inpAction;
    [SerializeField] InputAction inpAttack;
    [SerializeField] Transform trnAttackArea;
    [SerializeField] Transform trnPossAttackTop;
    [SerializeField] Transform trnPossAttackBottom;
    [SerializeField] Transform trnPossAttackLeft;
    [SerializeField] Transform trnPossAttackRight;
    public bool isCrown;
    [SerializeField] TMP_Text txtGameOverWin;
    [SerializeField] GameObject gmoGameOver;
    public bool isStart;
    [SerializeField] GameObject gmoStartScreen;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //makes the character look down by default
        lookDirection = new Vector2(0, -1);
        inpPlayerInput = GetComponent<PlayerInput>();
        inpAction = inpPlayerInput.actions.FindAction("Move");
        trnAttackArea = trnPossAttackBottom;

    }

    // Update is called once per frame
    void Update()
    {
        //getting input from keyboard controls

        if (isStart)
        {
            calculateMobileInput();
        }
      //  calculateNewSystemInputs();

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

            float dTop = Mathf.Pow(lookDirection.x,2.0f) + Mathf.Pow((1 - lookDirection.y),2.0f);
            float dRight = Mathf.Pow(1-lookDirection.x, 2.0f) + Mathf.Pow((lookDirection.y), 2.0f);
            float dBottom = Mathf.Pow(lookDirection.x, 2.0f) + Mathf.Pow((-1 - lookDirection.y), 2.0f);
            float dLeft = Mathf.Pow(-1-lookDirection.x, 2.0f) + Mathf.Pow((lookDirection.y), 2.0f);

            trnAttackArea.gameObject.SetActive(false);

            if (dTop < dBottom && dTop < dRight && dTop < dLeft)
            {
                trnAttackArea = trnPossAttackTop;
                // top is smallest
            }
            if (dRight < dBottom && dRight < dTop && dRight < dLeft)
            {
                trnAttackArea = trnPossAttackRight;
                //dRight smaller;
            }
            if (dLeft < dBottom && dLeft < dTop && dLeft < dRight)
            {
                trnAttackArea = trnPossAttackLeft;
                //dLeft smaller;
            }
              
            if (dBottom < dLeft && dBottom < dTop && dBottom < dRight)
            {
                trnAttackArea = trnPossAttackBottom;
                //dBottom smaller;
            }

           

            //set attack direction
            

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
            trnAttackArea.gameObject.SetActive(true);



        }


    }

    public void attack()
    {
        anim.SetTrigger("Attack");

        trnAttackArea.gameObject.SetActive(true);
        trnAttackArea.GetComponent<MBSAttack>().fltAttackTimeEnd = Time.time + .5f;

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




  /*  void calculateTouchInput()
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
  */



    public void FnMouseOverPanel()
    {
        isMoveOK = true;

    }


   void  calculateNewSystemInputs()
    {

       /* float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(x, y).normalized;
       */
       inputDirection = inpAction.ReadValue<Vector2>();



        if (inpAttack.IsPressed() )
        {
            attack();
        }




    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {

            if (isCrown)
            {
                txtGameOverWin.text = "You have retrieved the Crown";


            }

            else
            {
                txtGameOverWin.text = "You have failed to retrieve the Crown";
            }

            gmoGameOver.SetActive(true);
            Time.timeScale = 0f;
            isStart = false;
            isCrown = false;
           

        }


        if (collision.tag == "Crown")
        {
            Destroy(collision.gameObject);
            isCrown = true;


        }


    }


    public void FnStart()
    {
        isStart = true;
        gmoStartScreen.SetActive(false);

    }

}

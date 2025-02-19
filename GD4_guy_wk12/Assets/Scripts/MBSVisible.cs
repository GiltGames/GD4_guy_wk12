using UnityEngine;

public class MBSVisible : MonoBehaviour
{
    [SerializeField] GameObject gmoPlayer;
    [SerializeField] Transform trnEyes;
    [SerializeField] Transform trnFeet;
    [SerializeField] Transform trnTop;
    [SerializeField] Transform trnBottom;
    [SerializeField] Transform trnLeft;
    [SerializeField] Transform trnRight;
    [SerializeField] float fltRange=20;
    [SerializeField] bool isVisible;
    [SerializeField] float fltDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gmoPlayer = FindFirstObjectByType<playerMovement>().gameObject;
        trnEyes = gmoPlayer.transform.Find("Eyes");
        trnFeet = gmoPlayer.transform.Find("Feet");

    }

    // Update is called once per frame
    void Update()
    {
        fltDistance = (gmoPlayer.transform.position - transform.position).magnitude;


        if (fltDistance< fltRange)
        {
            RaycastHit2D hit1 = Physics2D.Raycast((trnTop.position), (trnEyes.position - trnTop.position), 1000);
            RaycastHit2D hit2 = Physics2D.Raycast((trnBottom.position), (trnEyes.position - trnBottom.position), 1000);
            RaycastHit2D hit3 = Physics2D.Raycast((trnRight.position), (trnEyes.position - trnRight.position), 1000);
            RaycastHit2D hit4 = Physics2D.Raycast((trnLeft.position), (trnEyes.position - trnLeft.position), 1000);
            RaycastHit2D hit5 = Physics2D.Raycast((trnTop.position), (trnFeet.position - trnTop.position), 1000);
            RaycastHit2D hit6 = Physics2D.Raycast((trnBottom.position), (trnFeet.position - trnBottom.position), 1000);
            RaycastHit2D hit7 = Physics2D.Raycast((trnRight.position), (trnFeet.position - trnRight.position), 1000);
            RaycastHit2D hit8 = Physics2D.Raycast((trnLeft.position), (trnFeet.position - trnLeft.position), 1000);

            /*   Debug.DrawRay((trnFeet.position), (trnTop.position - trnTop.position),Color.blue,1000);

               Debug.Log("Rays");

               Debug.Log("1" + hit1.transform.name);
               Debug.Log("2" + hit2.transform.name);
               Debug.Log("3" + hit3.transform.name);
               Debug.Log("4" + hit4.transform.name);
               Debug.Log("5" + hit5.transform.name);
               Debug.Log("6" + hit6.transform.name);
               Debug.Log("7"+hit7.transform.name);
            */
            string strTargetTmp = "Player";

            if (hit1.collider != null)
            {
                if (hit1.collider.tag == strTargetTmp)
                {
                    isVisible = true;
                }
            }
            if (hit2.collider != null)
            {
                if (hit2.collider.tag == strTargetTmp)
                {
                    isVisible = true;
                }
            }
            if (hit3.collider != null)
            {
                if (hit3.collider.tag == strTargetTmp)
                {
                    isVisible = true;
                }
            }
            if (hit4.collider != null)
            {
                if (hit4.collider.tag == strTargetTmp)
                {
                    isVisible = true;
                }
            }
            if (hit5.collider != null)
            {
                if (hit5.collider.tag == strTargetTmp)
                {
                    Debug.Log("Feet to top");

                    isVisible = true;
                }
            }
            if (hit6.collider != null)
            {
                if (hit6.collider.tag == strTargetTmp)
                {
                    isVisible = true;
                }
            }
            if (hit7.collider != null)
            {
                if (hit7.collider.tag == strTargetTmp)
                {
                    isVisible = true;
                }
            }
            if (hit8.collider != null)
            {
                if (hit8.collider.tag == strTargetTmp)
                {
                    isVisible = true;
                }
            }


        }

        
        if (isVisible)
        {
            transform.GetComponent<Renderer>().enabled = true;
            isVisible = false;
        }
        else

        {

            transform.GetComponent<Renderer>().enabled = false;

        }
    }
}

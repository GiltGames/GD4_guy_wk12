using UnityEngine;

public class MBSDisplayStats : MonoBehaviour
{
    [SerializeField] MBSEnemy mbsEnemy;
    [SerializeField] Vector3 vecMouse;
    [SerializeField] float fltDetect=1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       vecMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vecMouse.z = 0;

        if((transform.position - vecMouse).magnitude < fltDetect && Input.GetMouseButton(0))
        {
            mbsEnemy.FnShowStats();

        }
        else
        {
            mbsEnemy.FnStopShowStats();

        }



    }

    private void OnMouseEnter()
    {

        Debug.Log("Mouse in");
        mbsEnemy.FnShowStats();
    }


    private void OnMouseExit()
    {

        Debug.Log("Mouse out");
        mbsEnemy.FnStopShowStats();
    }


}

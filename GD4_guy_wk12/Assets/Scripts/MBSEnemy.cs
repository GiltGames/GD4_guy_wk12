using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class MBSEnemy : MonoBehaviour
{
    [SerializeField] Transform trnPlayer;
    [SerializeField] float fltMoveSpeed;
    [SerializeField] float fltSenseRange;
    [SerializeField] MBSPlayerHealth mbsPlayerHealth;
    [SerializeField] float fltDamage;
    [SerializeField] float fltDistance;
    [SerializeField] Vector3 vecOffset;
    [SerializeField] LayerMask layerMask;
    [SerializeField] VisualEffect vfxEffect;
    [SerializeField] Transform trnAttack;
    [SerializeField] Enemy enEnemy;
    [SerializeField] GameObject gmoStatsCard;
    [SerializeField] TMP_Text tmpName, tmpDesc, tmpHealt, tmpSpeed, tmpDam, tmpSense;
    [SerializeField] Image imPic;
    public bool isLOS;


   
    

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trnPlayer = FindFirstObjectByType<playerMovement>().transform;
        mbsPlayerHealth = trnPlayer.GetComponent<MBSPlayerHealth>();
        vfxEffect = trnAttack.GetComponent<VisualEffect>();
       trnAttack.gameObject.SetActive(false);

        fltMoveSpeed =  enEnemy.fltSpeed;
        fltDamage = enEnemy.fltDamage;
        fltSenseRange = enEnemy.fltSenseRange;  


    }

    // Update is called once per frame
    void Update()
    {
        vecOffset = trnPlayer.position - transform.position;
        fltDistance = vecOffset.magnitude;
        vfxEffect.SetVector3("Target", trnPlayer.position);


        if (fltDistance < fltSenseRange)
        {
            Debug.Log(gameObject.name + " checking for sight");

       

            RaycastHit2D hit = Physics2D.Raycast((transform.position + vecOffset.normalized), vecOffset,1000);
            // should ignore the Visible which is on layer 6


            Debug.DrawRay(transform.position, vecOffset*2);
           

            if (hit.collider != null)
            {
                Debug.Log("Enemy Sees "+ hit.collider.gameObject.name);
                if (hit.collider.transform == trnPlayer)
                {
                    transform.Translate(vecOffset.normalized * Time.deltaTime * fltMoveSpeed);
                   isLOS = true;

                }

               else
                {
                    isLOS = false;
                }
                 





            }

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touched Player");

        if (collision.transform == trnPlayer)
        {
            mbsPlayerHealth.FnDamage(fltDamage * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
   
    
        Debug.Log("Still Touching Player");

        if (other.transform == trnPlayer)
        {
            mbsPlayerHealth.FnDamage(fltDamage * Time.deltaTime);
            trnAttack.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        
        Debug.Log("Touched Player");

        if (other.transform == trnPlayer)
        {
            mbsPlayerHealth.FnDamage(fltDamage * Time.deltaTime);
            trnAttack.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trnAttack.gameObject.SetActive(false);

    }

  


    public void FnShowStats()

    {
        gmoStatsCard.gameObject.SetActive(true);
        tmpName.text = "Name: "+enEnemy.strName;
        tmpDesc.text = enEnemy.strDescription;
        tmpDam.text = "I do " + enEnemy.fltDamage + " damage";
        tmpHealt.text = "Health: "+enEnemy.fltHealth;
        tmpSpeed.text ="Speed: "+ enEnemy.fltSpeed;
        tmpSense.text = "Sense Range: " + enEnemy.fltSenseRange;
        imPic.sprite = enEnemy.sprImage;
        Time.timeScale = 0;


    }

    public void FnStopShowStats()

    {
        gmoStatsCard.gameObject.SetActive(false);
        Time.timeScale = 1.0f;


    }


}

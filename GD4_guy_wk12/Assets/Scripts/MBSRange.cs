using UnityEngine;

public class MBSRange : MonoBehaviour
{
    [SerializeField] MBSEnemy mbsEnemy;
    [SerializeField] float fltAttackTimer;
    [SerializeField] float fltAttackInterval;
    [SerializeField] float fltAttackVariability;
    [SerializeField] float fltMissileSpeed;
    [SerializeField] GameObject gmoMissileSource;
    [SerializeField] GameObject gmoMissile;
    [SerializeField] Vector3 vecOffset;
    [SerializeField] Transform trnPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trnPlayer = FindFirstObjectByType<playerMovement>().transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (mbsEnemy.isLOS)
        {
            fltAttackTimer += Time.deltaTime;
        }

        if (fltAttackTimer > fltAttackInterval)
        {
            fltAttackTimer = 0;
            FnLaunch();

        }


    }

    void FnLaunch()
    {
        vecOffset = trnPlayer.position = transform.position;

        gmoMissile = Instantiate(gmoMissileSource, transform.position, Quaternion.identity);
        
        gmoMissile.GetComponent<MBSMissile>().FnStart(vecOffset.normalized,fltMissileSpeed);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        


    }

}

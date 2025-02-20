using Unity.Hierarchy;
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
    [SerializeField] float fltDamage;
    [SerializeField] float fltMinDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trnPlayer = FindFirstObjectByType<playerMovement>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        vecOffset = trnPlayer.position - transform.position;

        if (mbsEnemy.isLOS)
        {
            fltAttackTimer += Time.deltaTime;
        }

        if (fltAttackTimer > fltAttackInterval && vecOffset.magnitude > fltMinDistance)
        {
            fltAttackTimer = -Random.Range(0,fltAttackVariability);
            FnLaunch();

        }


    }

    void FnLaunch()
    {
        

        gmoMissile = Instantiate(gmoMissileSource,transform.position,Quaternion.Euler(90,0,0));
        
        gmoMissile.GetComponent<MBSMissile>().FnStart(vecOffset.normalized,fltMissileSpeed,fltDamage);


    }


}

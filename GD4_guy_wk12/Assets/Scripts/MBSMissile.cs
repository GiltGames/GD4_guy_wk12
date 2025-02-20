using UnityEditorInternal;
using UnityEngine;

public class MBSMissile : MonoBehaviour
{
    [SerializeField] Vector3 vecDirection;
    [SerializeField] float fltSpeed;
    [SerializeField] float fltDamage;
    [SerializeField] GameObject gmoExplodePlayer;
    [SerializeField] GameObject gmoExplodeMaze;
    [SerializeField] MBSPlayerHealth mbsHealth;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       mbsHealth = FindFirstObjectByType<MBSPlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vecDirection*fltSpeed*Time.deltaTime,Space.World);


    }

   public void FnStart(Vector3 Dir, float Speed,float dam)
    {
        vecDirection = Dir;
        fltSpeed = Speed;
        fltDamage = dam;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                Destroy(Instantiate(gmoExplodePlayer, transform.position, Quaternion.Euler(90, 0, 0)),3);
                fltSpeed = 0;
                Destroy(gameObject, 1f);
                mbsHealth.FnDamage(fltDamage);

            }

            if (collision.tag != "Player")

            {
                Destroy(Instantiate(gmoExplodeMaze, transform.position, Quaternion.Euler(90, 0, 0)), 3);
                Destroy(gameObject, 1f);
                fltSpeed = 0;

            }



        }

    }


}

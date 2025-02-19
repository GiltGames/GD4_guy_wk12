using UnityEngine;

public class MBSPotion : MonoBehaviour
{
    [SerializeField] Potion potPotion;
    [SerializeField] Color colPotionColour;
        [SerializeField] int intPotionType;
    [SerializeField] float fltPotency;
    [SerializeField] float fltDuration;
    [SerializeField] MBSPlayerHealth mbsHealth;

    [SerializeField] MBSAura mbsAura;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mbsHealth = FindFirstObjectByType<MBSPlayerHealth>();
        GetComponent<SpriteRenderer>().color = potPotion.colColorLiquid;
        mbsAura = FindFirstObjectByType<MBSAura>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag =="Player")
            {



                switch (potPotion.intType)
                {
                    case 0:
                        FnType1();

                        break;


                }


                Destroy(gameObject);
            }



        }
    }


    void FnType1()
    {
        mbsHealth.FnHealth(potPotion.fltPotency);

        Color col = Color.red;
        mbsAura.FnSetAura(col,0.4f);
        
        

       

    }



}

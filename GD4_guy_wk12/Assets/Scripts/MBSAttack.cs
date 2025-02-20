using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MBSAttack : MonoBehaviour
{
    [SerializeField] TextMeshPro txtSpeech;
    [SerializeField] float fltEndSpeech=0;
    [SerializeField] float fltSpeechTime=2.0f;
    public float fltAttackTimeEnd;
    [SerializeField] MBSSpeak mbsSpeech;
    [SerializeField] GameObject gmoExplosionSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
       mbsSpeech = FindFirstObjectByType<MBSSpeak>();
    }


    private void Update()
    {
       

        


    }

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enters attack area");

        if (other.tag == "Invulnerable")
        {
            mbsSpeech.FnSpeech("I can't hurt it",fltSpeechTime + Time.time);


        }

        if (other.tag == "Enemy")

        {
            mbsSpeech.FnSpeech("Go for the eyes, Boo!", fltSpeechTime + Time.time);
            other.GetComponent<MBSEnemy>().FnHitEnemy(1.0f);

        }


        if (other.tag == "Missile")

        {
            mbsSpeech.FnSpeech("Go for the eyes, Boo!", fltSpeechTime + Time.time);
            Instantiate(gmoExplosionSource,other.transform.position,Quaternion.Euler(90,0,0));
            Destroy(other.gameObject);
            



        }

        gameObject.SetActive(false);

    }


  /*  private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Within attack area: -" + other.tag);
        Debug.Log(other.tag);

        if (other.tag == "Invulnerable")
        {
            mbsSpeech.FnSpeech("I can't hurt it", fltSpeechTime + Time.time);


        }

        if (other.tag == "Enemy")

        {
            mbsSpeech.FnSpeech("Go for the eyes, Boo!", fltSpeechTime + Time.time);
            other.GetComponent<MBSEnemy>().FnHitEnemy(1.0f);

        }


        gameObject.SetActive(false);

    }
  */

    void FnSpeech(string TextTmp, float timeend)
    {
        txtSpeech.text = TextTmp;
        fltEndSpeech = timeend;


    }

}

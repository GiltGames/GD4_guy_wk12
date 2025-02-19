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
        
        gameObject.SetActive(false);

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Within attack area");
        Debug.Log(other.tag);

        if (other.tag == "Invulnerable")
        {
            mbsSpeech.FnSpeech("I can't hurt it", fltSpeechTime + Time.time);


        }

        gameObject.SetActive(false);

    }


    void FnSpeech(string TextTmp, float timeend)
    {
        txtSpeech.text = TextTmp;
        fltEndSpeech = timeend;


    }

}

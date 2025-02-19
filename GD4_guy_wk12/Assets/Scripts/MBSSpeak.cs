using TMPro;
using UnityEngine;

public class MBSSpeak : MonoBehaviour
{
    [SerializeField] TextMeshPro txtSpeech;
    [SerializeField] float fltEndSpeech = 0;
    [SerializeField] float fltSpeechTime = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtSpeech = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fltEndSpeech)
        {
            txtSpeech.text = "";
        }

    }

    public void FnSpeech(string TextTmp, float timeend)
    {
        txtSpeech.text = TextTmp;
        fltEndSpeech = timeend;


    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MBSDialogueSpecific : MonoBehaviour
{
    [SerializeField] MBSDialogue mbsDialogue;
    [SerializeField] GameObject gmoEffect1;
    //[SerializeField] GameObject gmoEffect2;
    [SerializeField] bool isEffect1;
    [SerializeField] bool isEffect2;
    [SerializeField] Image imgUIImage;
    [SerializeField] Sprite sprImageSource;

    //assign in inspector

    // Speciic script triggered by events in the conversation


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imgUIImage = gmoEffect1.GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (mbsDialogue.intFlagCurrent ==1)
        {
            if (!isEffect1 && mbsDialogue.intFlagSetCurrent == 1)
            {
                gmoEffect1.SetActive(true);
                imgUIImage.sprite = sprImageSource;
                imgUIImage.color = Color.white;

                isEffect1 = true;
            }

            if (!isEffect2 && mbsDialogue.intFlagSetCurrent ==2)
            {

                gmoEffect1.SetActive(true);
                imgUIImage.sprite = sprImageSource;
                imgUIImage.color = Color.red;

                isEffect2 = true;

            }



        }


    }

    IEnumerator IETurnOff()
    {

        yield return  new WaitForSeconds(2);
        gmoEffect1.SetActive(false);

    }

}

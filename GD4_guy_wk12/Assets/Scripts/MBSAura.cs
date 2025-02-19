using UnityEngine;

public class MBSAura : MonoBehaviour
{
    [SerializeField] GameObject gmoAura;
    [SerializeField] Material matAura;
    [SerializeField] float fltAuraOffTime;
    [SerializeField] Material matAuraOffTime;
    [SerializeField] bool isAuraOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        matAura = gmoAura.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fltAuraOffTime && isAuraOn)
        {
            FnAuraOff();
        }


    }

    public void FnSetAura(Color color, float Off)
    {
        gmoAura.SetActive(true);
        matAura.color = color;
        fltAuraOffTime = Time.time + Off;
        isAuraOn = true;
    }


    public void FnAuraOff()
    {

        gmoAura.SetActive(false);
        isAuraOn = false;
    }


}

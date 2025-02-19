using UnityEngine;

public class MBSAura : MonoBehaviour
{
    [SerializeField] GameObject gmoAura;
    [SerializeField] Material matAura;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FnSetAura(Color color)
    {
        gmoAura.SetActive(true);
        matAura.color = color;

    }


    public void FnAuraOff()
    {

        gmoAura.SetActive(false);
    }


}

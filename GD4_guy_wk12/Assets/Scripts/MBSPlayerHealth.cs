using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MBSPlayerHealth : MonoBehaviour
{
    [SerializeField] float fltHealth;
    [SerializeField] float fltHealthMax;
    [SerializeField] Slider sldHealth;
    [SerializeField] GameObject gmoGameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fltHealth = fltHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FnDamage(float fltDamageTmp)
    {
        fltHealth -= fltDamageTmp;

        sldHealth.value = fltHealth;


        if (fltHealth <= 0)
        {
            FnDeath();
        }

    }

    void FnDeath()
    {
        gmoGameOverScreen.SetActive(true);
        Time.timeScale = 0f;


    }

    public void FnRestart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }


    public void FnHealth(float fltHealTmp)
    {
        fltHealth += fltHealTmp;

        


        if (fltHealth > fltHealthMax)
        {
            fltHealth = fltHealthMax;
        }
        sldHealth.value = fltHealth;
    }


}

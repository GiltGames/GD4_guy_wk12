using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MBSPlatformDiisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string info = "Running in: ";
#if UNITY_EDITOR
        info += "the Editor";

#elif UNITY_WEBGL
info += "the WebGL mode";

#else
info += "something else";

#endif
        text.text = info;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 4)
        {
            gameObject.SetActive(false);
        }


    }
}

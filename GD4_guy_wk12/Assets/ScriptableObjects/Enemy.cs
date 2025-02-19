using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class Enemy : ScriptableObject
{
   
    public string strName;
    public Sprite sprImage;
    public float fltHealth;
    public float fltSpeed;
    public float fltDamage;
    public bool isVulnerable;
    public string strDescription;
    public bool isHostile;
    public float fltSenseRange;

}

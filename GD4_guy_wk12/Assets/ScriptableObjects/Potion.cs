using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Scriptable Objects/Potion")]
public class Potion : ScriptableObject
{
    public string strPotion;
    public int intType;
    public Color colColorLiquid;
    public float fltPotency;
    public float fltDuration;



}

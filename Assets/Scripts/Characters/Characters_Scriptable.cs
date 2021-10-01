using UnityEngine;


[CreateAssetMenu(fileName = "Characters", menuName = "Game/Characters", order = 1)]
public class Characters_Scriptable : ScriptableObject
{
    public float maxLife;
    public float currentLife;
    public float characSpeed;


    public void InitLife()
    {
        currentLife = maxLife;
    }

}

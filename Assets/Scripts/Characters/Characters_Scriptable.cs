using UnityEngine;


[CreateAssetMenu(fileName = "Characters", menuName = "Game/Characters", order = 1)]
public class Characters_Scriptable : ScriptableObject
{
    public int maxLife;
    public int currentLife;
    public float characSpeed;


    public void InitLife()
    {
        currentLife = maxLife;
    }

}

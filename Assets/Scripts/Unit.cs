using UnityEngine;

public class Unit : MonoBehaviour
{
    public Health Health { get; private set; } 

    public void Init(int maxHealth)
    {
        Health = new Health(maxHealth);
    }
}

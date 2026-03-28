using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int hp;
    public int damege;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Walka z " + enemyName);
        }
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CombatManager combatManager;
    public string enemyName;
    public int hp;
    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            combatManager.StartCombat();
            combatManager.currentEnemy = this.gameObject;
        }
    }
}

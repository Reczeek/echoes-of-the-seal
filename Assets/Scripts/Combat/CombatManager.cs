using UnityEngine;

public class CombatManager : MonoBehaviour
{
   public int playerHP;
    public int playerMaxHP;
    public int playerAP;
    public int playerMaxAP;

    public int enemyHP;
    public int enemyMaxHP;

    public bool isPlayerTurn;
    public bool isParryWindow; 

    void StartCombat()
    {
        isPlayerTurn = true;
        Debug.Log("Walka rozpoczęta");
    }

    void PlayerAttack()
    {
        enemyHP -= 10;
        Debug.Log("Enemy HP = " + enemyHP);
        isPlayerTurn = false;
    }

    void EnemyAttack()
    {
        playerHP -= 8;
        isParryWindow = true;
        Debug.Log("Przeciwnik atakuje!");
    }

    void Parry()
    {
        if (isParryWindow == true)
        {
            Debug.Log("Sparowano!");
            playerAP += 1;
            isParryWindow = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isParryWindow)
        {
            Parry();
        }
    }
}

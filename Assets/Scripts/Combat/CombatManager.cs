using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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
    public GameObject combatUI;
    public Slider playerHPBar;
    public Slider enemyHPBar;
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI parryIndicator;
    public GameObject currentEnemy;

    public void StartCombat()
    {
        isPlayerTurn = true;
        combatUI.SetActive(true);
        playerHPBar.value = playerHP;
        playerHPBar.maxValue = playerMaxHP;
        enemyHPBar.value = enemyHP;
        enemyHPBar.maxValue = enemyMaxHP;
        Debug.Log("Walka rozpoczęta");
    }

    public void PlayerAttack()
    {
        enemyHP -= 10;
        enemyHPBar.value = enemyHP;
        Debug.Log("Enemy HP = " + enemyHP);
        isPlayerTurn = false;
        StartCoroutine(EnemyTurn());
        CheckCombatEnd();
    }

    public void EnemyAttack()
    {
        playerHP -= 8;
        playerHPBar.value = playerHP;
        isParryWindow = true;
        parryIndicator.gameObject.SetActive(true);
        Debug.Log("Przeciwnik atakuje!");
        CheckCombatEnd();
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f); // czeka 1 sekundę
        EnemyAttack();
    }

    public void CheckCombatEnd()
    {
        if (enemyHP <= 0)
        {
            Debug.Log("Wygrałeś!");
            Destroy(currentEnemy);
            combatUI.SetActive(false);
        }
        if (playerHP <= 0)
        {
            Debug.Log("Przegrałeś!");
            combatUI.SetActive(false);
        }
    }

    public void Parry()
    {
        if (isParryWindow == true)
        {
            Debug.Log("Sparowano!");
            playerAP += 1;
            isParryWindow = false;
            parryIndicator.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isParryWindow)
        {
            Parry();
        }
    }

        public void UseSkill()
    {
        Debug.Log("Użyto umiejętności");
    }

    public void UseItem()
    {
        Debug.Log("Użyto przedmiotu");
    }

    public void Flee()
    {
        Debug.Log("Ucieczka!");
        combatUI.SetActive(false);
    }
}

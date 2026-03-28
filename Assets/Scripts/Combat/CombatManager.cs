using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    }

    public void EnemyAttack()
    {
        playerHP -= 8;
        playerHPBar.value = playerHP;
        isParryWindow = true;
        Debug.Log("Przeciwnik atakuje!");
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

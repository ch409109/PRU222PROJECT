using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
	[Header("Health Bar")]
	public Image firstPlayerHealthBar;
	public Image secondPlayerHealthBar;

	[Header("Mana Bar")]
	public Image firstPlayerManaBar;
	public Image secondPlayerManaBar;

	public void UpdateFirstPlayerHealthBar(float curentHP, float maxHP)
	{
		firstPlayerHealthBar.fillAmount = curentHP / maxHP;
	}

	public void UpdateSecondPlayerHealthBar(float curentHP, float maxHP)
	{
		secondPlayerHealthBar.fillAmount = curentHP / maxHP;
	}

	public void UpdateFirstPlayerManaBar(float currentMana, float maxMana)
	{
		firstPlayerManaBar.fillAmount = currentMana / maxMana;
	}

	public void UpdateSecondPlayerManaBar(float currentMana, float maxMana)
	{
		secondPlayerManaBar.fillAmount = currentMana / maxMana;
	}
}

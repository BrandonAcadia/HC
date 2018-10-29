using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
	//debug vairables. delete after done.
	public Text equipped;
	public Text canequipbear;


	//end of debug
	public Text CoinTotalText;
	public Text BearText;
	public Text BearEquipText;
	public Text AlienEquipText;
	//public Text MoneyText;
	public string NotEnough = "Not Enough Coins!";
	public string Buy = "Buy";
	public string Equip = "Use";
	public string CurrentlyUsing = "Currently Using!";

	//Buttons
	//public GameObject alienButton;
	public GameObject equipAlienButton;
	public GameObject bearButton;
	public GameObject equipBearButton;
	//public GameObject moneyButton;
	public GameObject equipMoneyButton;


	private int currentTotalCoins;
	private int canEquipBear;
	//private int canEquipMoney;
	public int priceBear = 5;
	//public int priceMoney = 100;
	private int equippedSkin;

	// Use this for initialization

	void Awake () {
		PlayerPrefs.SetInt ("EquippedSkin", 0);
		equippedSkin = PlayerPrefs.GetInt ("EquippedSkin");





	}

	void Start () {
		//Debug Code

		PlayerPrefs.SetInt ("Total Coins", 10);
		PlayerPrefs.SetInt ("CanEquipBear", 0);
		canequipbear.text = "Can Equip " + PlayerPrefs.GetInt("CanEquipBear").ToString();
		equipped.text = "skin: " + PlayerPrefs.GetInt ("EquippedSkin").ToString ();

		//End of Debug Code

		PlayerPrefs.SetString ("Bear", NotEnough);
		PlayerPrefs.SetString ("Alien", Equip);

		AlienEquipText.text = PlayerPrefs.GetString ("Alien");
		BearEquipText.text = PlayerPrefs.GetString ("Bear");


		switch (equippedSkin) {

		case 0:
			PlayerPrefs.SetString ("Alien", CurrentlyUsing);
			equipAlienButton.GetComponent<Button> ().interactable = false;
			equipBearButton.GetComponent<Button> ().interactable = true;

			AlienEquipText.text = PlayerPrefs.GetString ("Alien");
			break;
		case 1:
			PlayerPrefs.SetString ("Bear", CurrentlyUsing);
			equipBearButton.GetComponent<Button> ().interactable = false;
			equipAlienButton.GetComponent<Button> ().interactable = true;
			BearEquipText.text = PlayerPrefs.GetString ("Bear");
			break;
		case 2:
			PlayerPrefs.SetString ("Money", CurrentlyUsing);

			break;
		}


		canEquipBear = PlayerPrefs.GetInt ("CanEquipBear");
		if (canEquipBear == 1 && equippedSkin != 1) {
			PlayerPrefs.SetString ("Bear", Equip);
			BearEquipText.text = PlayerPrefs.GetString ("Bear");
			bearButton.SetActive (false);
			equipBearButton.SetActive (true);

		}

		BearText.text = PlayerPrefs.GetString("Bear");
		BearEquipText.text = PlayerPrefs.GetString ("Bear");

		CoinTotalText.text = "Your Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
		currentTotalCoins = PlayerPrefs.GetInt ("Total Coins");
		bearButton.GetComponent<Button> ().interactable = false;

		if (currentTotalCoins >= priceBear && canEquipBear != 1) {
			bearButton.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetString ("Bear", Buy);
			BearText.text = PlayerPrefs.GetString("Bear");
		}




	}

	void Update () {

		if (currentTotalCoins < priceBear) {
			bearButton.GetComponent<Button> ().interactable = false;
			PlayerPrefs.SetString ("Bear", NotEnough);

		}

		equippedSkin = PlayerPrefs.GetInt ("EquippedSkin");

		switch (equippedSkin) {

		case 0:
			PlayerPrefs.SetString ("Alien", CurrentlyUsing);
			equipAlienButton.GetComponent<Button> ().interactable = false;
			equipBearButton.GetComponent<Button> ().interactable = true;
			PlayerPrefs.SetString ("Alien", CurrentlyUsing); 
			PlayerPrefs.SetString ("Bear", Equip);
			AlienEquipText.text = PlayerPrefs.GetString ("Alien");
			BearEquipText.text = PlayerPrefs.GetString ("Bear");

			break;
		case 1:
			PlayerPrefs.SetString ("Bear", CurrentlyUsing);
			PlayerPrefs.SetString ("Alien", Equip);
			AlienEquipText.text = PlayerPrefs.GetString ("Alien");
			BearEquipText.text = PlayerPrefs.GetString ("Bear");
			equipBearButton.GetComponent<Button> ().interactable = false;
			equipAlienButton.GetComponent<Button> ().interactable = true;
			break;
		case 2:
			PlayerPrefs.SetString ("Money", CurrentlyUsing);

			break;
		}


			//canEquipBear = PlayerPrefs.GetInt ("CanEquipBear");
			BearEquipText.text = PlayerPrefs.GetString ("Bear");
			AlienEquipText.text = PlayerPrefs.GetString ("Alien");




	}

	//Code for alien skin.
	public void EquipAlienItem (){
			PlayerPrefs.SetInt ("EquippedSkin", 0);
			/**PlayerPrefs.SetString ("Alien", CurrentlyUsing); 
			PlayerPrefs.SetString ("Bear", Equip);
			AlienEquipText.text = PlayerPrefs.GetString ("Alien");
			BearEquipText.text = PlayerPrefs.GetString ("Bear");
			equipBearButton.GetComponent<Button> ().interactable = true;
			equipAlienButton.GetComponent<Button> ().interactable = false;
			//equipMoneyButton.GetComponent<Button> ().interactable = true;**/


	}
	//Code for bear skin.
	public void BuyBearItem (){
			currentTotalCoins = currentTotalCoins - 5;
			PlayerPrefs.SetInt ("Total Coins", currentTotalCoins);
			CoinTotalText.text = "Your Coins: " + PlayerPrefs.GetInt ("Total Coins").ToString();
			PlayerPrefs.SetString ("Bear", Equip);
			BearEquipText.text = PlayerPrefs.GetString ("Bear"); 
			PlayerPrefs.SetInt("CanEquipBear", 1);
			canEquipBear = PlayerPrefs.GetInt("CanEquipBear");


	}

	public void EquipBearItem (){

			PlayerPrefs.SetInt ("EquippedSkin", 1);
			/**PlayerPrefs.SetString ("Bear", CurrentlyUsing);
			PlayerPrefs.SetString ("Alien", Equip);
			AlienEquipText.text = PlayerPrefs.GetString ("Alien");
			BearEquipText.text = PlayerPrefs.GetString ("Bear");
			equipBearButton.GetComponent<Button> ().interactable = false;
			equipAlienButton.GetComponent<Button> ().interactable = true;
			//equipMoneyButton.GetComponent<Button> ().interactable = true;**/


	}
	//End of code for bear.

	//Code for money skin.


}

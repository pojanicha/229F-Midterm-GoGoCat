using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
	private int Coin = 0;
	private int maxCoin = 10;
	private int currentCoin;
	private int addTime = 5;

	public TextMeshProUGUI CoinText;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Coin")) //Check if the collide object has tag "Coin"
		{
			Coin++;
			currentCoin++;
			CoinText.text = "Coin: " + Coin.ToString();
			Debug.Log(Coin);
			Destroy(other.gameObject);

			if (currentCoin == maxCoin)
			{
				TimeControl.Instance.AddTime(addTime);
				currentCoin = 0;
			}
		}
	}
}

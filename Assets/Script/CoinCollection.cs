using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
	private int Coin = 0;

	public TextMeshProUGUI CoinText;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Coin")) //Check if the collide object has tag "Coin"
		{
			Coin++;
			CoinText.text = "Coin: " + Coin.ToString();
			Debug.Log(Coin);
			Destroy(other.gameObject);
		}
	}
}

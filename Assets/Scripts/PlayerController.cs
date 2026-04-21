using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

 // Movement along X and Y axes.
 private float movementX;
 private float movementY;

private int count;
public TextMeshProUGUI countText;
public GameObject endText;
private int numCoinsToWin = 15;

 // Start is called before the first frame update.
 void Start()
    {
 // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        endText.SetActive(false);
        count = 0;
        SetCountText();
    }
 

 void OnTriggerEnter(Collider other) 
    {
	 // Check if the object the player collided with has the "PickUp" tag.
	 if (other.gameObject.CompareTag("PickUp")) 
		{
	 // Deactivate the collided object (making it disappear).
		    other.gameObject.SetActive(false);
		    count = count + 1;
		    SetCountText();
		}
	}

void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
       // Destroy the current object
       Destroy(gameObject); 
       // Update the winText to display "You Lose!"
       endText.gameObject.SetActive(true);
       endText.GetComponent<TextMeshProUGUI>().text = "You Lose!";
   }
}

void SetCountText()
{
	countText.text = "Count: " + count.ToString();
	if ( count >= numCoinsToWin ) {
		endText.SetActive(true);
		endText.GetComponent<TextMeshProUGUI>().text = "You win!";
		Destroy(GameObject.FindGameObjectWithTag("Enemy"));
	}
}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 110*Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("Coin sound");
            PlayerManager.numberofCoins += 1;
            Destroy(gameObject);
            Debug.Log("coins =" + PlayerManager.numberofCoins);
        }
    }
}

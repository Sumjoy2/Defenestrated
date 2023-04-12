using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    
    // Start is called before the first frame update
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        //PickUpObject();
    }
    
    // Update is called once per frame
    //void PickUpObject()
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (Input.GetButtonDown("Fire2"))
        if(other.CompareTag("Player"))
        {                       
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }            
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPanel;

    [SerializeField]
    private int _currentSelectedItem;
    private int _currentItemCost;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamond);
            }

            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance._selectionImg.enabled = false;
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        //0 = Flame sword
        //1 = boots of flight
        //2 = Key to Castle
        Debug.Log("Select Item" + item);

        UIManager.Instance._selectionImg.enabled = true;

        //switch
        switch(item)
        {
            case 0: //flame sword

                UIManager.Instance.UpdateShopSelection(50);
                _currentSelectedItem = item;
                _currentItemCost = 200;
                break;
            case 1: //Boots of flight
                UIManager.Instance.UpdateShopSelection(-50);
                _currentSelectedItem = item;
                _currentItemCost = 400;
                break;
            case 2: //keys to the castle
                UIManager.Instance.UpdateShopSelection(-150);
                _currentSelectedItem = item;
                _currentItemCost = 100;
                break;
        }
    }

    //buyitem method
    //check player gems is greater than or equal to item cost
    //if it is, then award item, else cancel sale;

    public void BuyItem()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (player.diamond >= _currentItemCost)
        {

            if (_currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
                Debug.Log("You can exit now");
            }

            player.diamond -= _currentItemCost;
            Debug.Log("Purchased " + _currentSelectedItem);
            UIManager.Instance.OpenShop(player.diamond);

        }
        else
        {
            UIManager.Instance._selectionImg.enabled = false;
            _shopPanel.SetActive(false);
        }
    }

}



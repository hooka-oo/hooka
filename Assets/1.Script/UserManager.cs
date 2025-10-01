using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    public UserData userData;

    public string itemName;
    public int count;

    void Awake()
    {
        userData = SaveManager.LoadData<UserData>("UserData");

        if(userData == null)
        {
            userData = new UserData();
            userData.coin = 100;
        }

        

//Wood 획득 시 유저 데이터 저장하기

       
        SaveManager.SaveData("UserData", userData);
    }

    public void AddItem(string key, int count)
    {
        for(int i = 0; i < userData.userItems.Count; i++) 
        {
            if (userData.userItems[i].key == key)
            {
                userData.userItems[i].count += count;
                SaveManager.SaveData("UserData", userData);
                return;
            }
        }

        UserItem userItem = new UserItem();
        userItem.key = key;
        userItem.count = count;

        userData.userItems.Add(userItem);

        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            userData.coin += 10;
            userData.playTime = Time.time;
            
            UserItem userItem = new UserItem();
            userItem.key = itemName;
            userItem.count = count;
            userData.userItems.Add(userItem); //UserItem 객체 담아야ㅎ
            SaveManager.SaveData("UserData", userData);
        }
    }

}


[System.Serializable]
public class UserData
{
    //public Inventory inventory = new Inventory();
    public int coin;
    public string nickname;
    public float playTime;
    public List<UserItem> userItems = new List<UserItem>();
}

[System.Serializable]
public class Inventory
{
    Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string key, int amount)
    {
        if (!items.ContainsKey(key))
        {
            items[key] = 0;
        }
        items[key] += amount;
    }

    public int GetCount(string key)
    {
        if (items.ContainsKey(key))
        {
            return items[key];
        }
        else
        {
            return 0;
        }
    }

}

[System.Serializable] // 인스펙터 노출 & 직렬화 : 데이터를 나열시켜서 저장하고 불러오기 좋은 형태로 만들어줌
public class UserItem
{
    public string key;
    public int count;
}
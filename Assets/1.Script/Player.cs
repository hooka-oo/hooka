using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public List<UserItem> inventory = new List<UserItem>(); //인벤토리 리스트
    void Start()
    {
        AddItem("나무", 1);
        AddItem("돌", 10);
        AddItem("나무", 3);
        Debug.Log(GetCount("돌"));
        Debug.Log(GetCount("나무"));
    }

    public string key; //아이템 식별자
    public int count; // 수량

    private int FindIndexByKey(string key) //검색함수
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].key == key) //현재 슬롯의 키가 찾는 키와 같으면
                return i; // 그 인데스 반환
        }
        return -1; // 없을 시 종료
    }

    public void AddItem(string key, int amount)
    {
        if (amount <= 0) return; // 무의미한 호출이면 빠져나감 

        int idx = FindIndexByKey(key);
        if(idx >= 0) // 이미 있는 슬롯의 경우
        {
            inventory[idx].count += amount;
        }
        else
        {
            UserItem item = new UserItem();
            item.key = key;
            item.count = amount;
            inventory.Add(item);
        }
    }

    public bool RemoveItem (string key, int amount)
    {
        if (amount <= 0) return false;

        int idx = FindIndexByKey(key);
        if (idx < 0) return false; // 키가 없는 경우
        if (inventory[idx].count < amount) return false; // 수량이 부족한 경우

        inventory[idx].count -= amount;
        if (inventory[idx].count == 0)
            inventory.RemoveAt(idx); //0개면 idx번째 슬롯 제거

        return true;
    }

    public int GetCount(string key)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].key == key)
                return inventory[i].count;
        }
        return 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1f, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1f, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1f, 0) * speed * Time.deltaTime;
        }

    }

    
}

[System.Serializable]
public class UserItem
{
    public string key; //아이템 식별자
    public int count; //개수
}
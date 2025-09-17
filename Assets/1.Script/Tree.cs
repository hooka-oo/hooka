using UnityEngine;

public class Tree : Resource
{
    int hp = 3;
    public Transform woodPrefab;

    public void TakeDamage()
    {
        if (hp <= 0)
            return;
        if (gameObject.activeSelf == false)
            return;
        hp--;
        if (hp <= 0)
        {

            gameObject.SetActive(false);
            Transform wood = Instantiate(woodPrefab);
            wood.transform.position = (Vector2)transform.position;
            Debug.Log("Tree TakeDamage");
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stone : MonoBehaviour
{
    public int index = 0;
    private float gap = 3.4f;
    int x = 0;
    int y = 0;
    
    private Action<int, int> swapFunc = null;
    
    public void Init(int i, int j, int index, Sprite sprite, Action<int, int> swapFunc)
    {
        this.index = index;
        this.GetComponent<SpriteRenderer>().sprite = sprite;
        this.swapFunc = swapFunc;
        
        UpdatePosition(i, j);
    }
    
    public void UpdatePosition(int i, int j)
    {
        x = i;
        y = j;
        StartCoroutine(Move());
    }
    
    IEnumerator Move()
    {
        float elapsedTime = 0;
        float duration = 0.2f;
        Vector2 start = this.gameObject.transform.localPosition;
        Vector2 end = new Vector2(-5 + (gap * x), (gap * y) - 5);
        
        while(elapsedTime < duration)
        {
            this.gameObject.transform.localPosition = Vector2.Lerp(start, end, (elapsedTime / duration));
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        this.gameObject.transform.localPosition = end;
    }
    
    public bool isEmpty()
    {
        return index == 16;
    }
    
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && swapFunc != null)
        {
            swapFunc(x, y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Board : MonoBehaviour
{   
    
    private SpriteRenderer _Sprite;
    private Vector2 sizeBoard;
    private int _height = GameManager.Instance.Height; 
    private int _width = GameManager.Instance.Width;
   
    private void Awake()
    {
        _Sprite = GetComponent<SpriteRenderer>();
        sizeBoard = new Vector2 ((float)_width + 0.5f, (float)_height + 0.5f);
    }
    private void Start()
    {
        UpdateSizeBoard(sizeBoard);
    }
    private void UpdateSizeBoard(Vector2 sizeBoard)
    {
        _Sprite.size = sizeBoard;
    }

}

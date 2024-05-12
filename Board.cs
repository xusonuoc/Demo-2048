using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Board : MonoBehaviour
{   
    
    private SpriteRenderer _Sprite;
    private Vector2 sizeBoard;
    private int _height;
    private int _width;
   
    private void Awake()
    {
        _height = GameManager.Instance.Height;
        _width = GameManager.Instance.Width;
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

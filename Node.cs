using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Node right;
    public Node left;
    public Node up;
    public Node down;
    public Block Block;

    private int _height = GameManager.Instance.Height;
    private int _width = GameManager.Instance.Width;


    private void OnEnable()
    {
        GameManager.slide += OnSlide;
    }

    private void OnDisable( )
    {
        GameManager.slide -= OnSlide;
    }

    private void OnSlide(string key_board)
    {
        switch (key_board)
        {
            case "w" :
                if (up != null) return;
                
                SlideUp(this);
                break;
            case "s":
                if (down != null) return;
                break;
            case "a":
                if (left != null) return;
                break;
            case "d":
                if (right != null) return;
                break;
            default : 
                break;
        }
    }

    private void SlideUp(Node currentNode)
    {
        Debug.Log(currentNode.gameObject);
        if (currentNode == null) return;
        SlideUp(currentNode.down);
    }

    public void SetNeighbors(List<Node> newlist, int x, int y)
    {
        //if (x == 0 && y == 0 || x == 0 && y == _width - 1  || x == _height - 1 && y == 0 || x == _height - 1 && y == _width - 1)
        //{
        //    left = newlist[x + 1];
        //    Debug.Log(_width);
        //}
        int currentPosList = y + (4 * x);
        if (x > 0 )
        {
            left = newlist[currentPosList - 4];
        }
        if (x < _width - 1) 
        {
            right = newlist[currentPosList + 4];
        }
        if ( y  < _height - 1) 
        {
            up = newlist[currentPosList + 1];
        }
        if (y  > 0)
        {
            down = newlist[currentPosList - 1];
        }
    }
}

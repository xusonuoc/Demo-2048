
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

    private int _height ;
    private int _width ;

    private void Awake()
    {
        _height = GameManager.Instance.Height;
        _width = GameManager.Instance.Width;
    }

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
        Node currentNode = this;
        switch (key_board)
        {
            case "W" :
                Debug.Log("W");
                if (up != null) return;
                Debug.Log(currentNode);
                SlideUp(currentNode);
                break;
            case "S":
                if (down != null) return;
                SlideDown(currentNode);
                break;
            case "A":
                if (left != null) return;
                SlideLeft(currentNode);
                break;
            case "D":
                if (right != null) return;
                SlideRight(currentNode);
                break;
            default : 
                break;
        }
    }

    private void SlideUp(Node currentNode)
    {
        
        if (currentNode.down == null) return;

        if (currentNode.Block != null)
        {
            Node nextNode = currentNode.down;
            while (nextNode.down != null && nextNode.Block == null)
            {

                nextNode = nextNode.down;
                
            }
            if (nextNode.Block != null)
            {
                if (currentNode.Block.value == nextNode.Block.value)
                {
                    nextNode.Block.Double();
                    nextNode.Block.transform.parent = currentNode.transform;
                    currentNode.Block = nextNode.Block;
                    nextNode.Block = null;
                }
                else
                {
                    Debug.Log("!Doubled");
                    nextNode.Block.transform.parent = currentNode.transform;
                    currentNode.down.Block = nextNode.Block;
                    nextNode.Block = null;
                }
            }
        }
        else
        {
            Node nextNode = currentNode.down;
            while (nextNode.down != null && nextNode.Block == null)
            {
                nextNode = nextNode.down;
                Debug.Log(nextNode);
            }
            if (nextNode.Block != null)
            {
                //nextNode.Block.transform.parent = currentNode.transform;
                nextNode.Block.transform.parent = currentNode.transform;
                currentNode.Block = nextNode.Block;
                nextNode.Block = null;
                SlideUp(currentNode);
                Debug.Log("Slide to Empty");
            }
        }
       

        if (currentNode.down == null) return;
        SlideUp(currentNode.down);
    }

    private void SlideDown(Node currentNode)
    {

        if (currentNode.up == null) return;

        if (currentNode.Block != null)
        {
            Node nextNode = currentNode.up;
            while (nextNode.up != null && nextNode.Block == null)
            {

                nextNode = nextNode.up;

            }
            if (nextNode.Block != null)
            {
                if (currentNode.Block.value == nextNode.Block.value)
                {
                    nextNode.Block.Double();
                    nextNode.Block.transform.SetParent(currentNode.transform, false);
                    currentNode.Block = nextNode.Block;
                    nextNode.Block = null;
                }
                else
                {
                    Debug.Log("!Doubled");
                    nextNode.Block.transform.SetParent(currentNode.transform, false);
                    currentNode.up.Block = nextNode.Block;
                    nextNode.Block = null;
                }
            }
        }
        else
        {
            Node nextNode = currentNode.up;
            while (nextNode.up != null && nextNode.Block == null)
            {
                nextNode = nextNode.up;
                Debug.Log(nextNode);
            }
            if (nextNode.Block != null)
            {
                //nextNode.Block.transform.parent = currentNode.transform;
                nextNode.Block.transform.parent = currentNode.transform;
                currentNode.Block = nextNode.Block;
                nextNode.Block = null;
                SlideDown(currentNode);
                Debug.Log("Slide to Empty");
            }
        }


        if (currentNode.up == null) return;
        SlideDown(currentNode.up);
    }

    private void SlideRight(Node currentNode)
    {

        if (currentNode.left == null) return;

        if (currentNode.Block != null)
        {
            Node nextNode = currentNode.left;
            while (nextNode.left != null && nextNode.Block == null)
            {

                nextNode = nextNode.left;

            }
            if (nextNode.Block != null)
            {
                if (currentNode.Block.value == nextNode.Block.value)
                {
                    nextNode.Block.Double();
                    nextNode.Block.transform.SetParent(currentNode.transform, false);
                    currentNode.Block = nextNode.Block;
                    nextNode.Block = null;
                }
                else
                {
                    Debug.Log("!Doubled");
                    nextNode.Block.transform.SetParent(currentNode.transform, false);
                    currentNode.left.Block = nextNode.Block;
                    nextNode.Block = null;
                }
            }
        }
        else
        {
            Node nextNode = currentNode.left;
            while (nextNode.left != null && nextNode.Block == null)
            {
                nextNode = nextNode.left;
                Debug.Log(nextNode);
            }
            if (nextNode.Block != null)
            {
                //nextNode.Block.transform.parent = currentNode.transform;
                nextNode.Block.transform.parent = currentNode.transform;
                currentNode.Block = nextNode.Block;
                nextNode.Block = null;
                SlideRight(currentNode);
                Debug.Log("Slide to Empty");
            }
        }


        if (currentNode.up == null) return;
        SlideRight(currentNode.left);
    }

    private void SlideLeft(Node currentNode)
    {

        if (currentNode.right == null) return;

        if (currentNode.Block != null)
        {
            Node nextNode = currentNode.right;
            while (nextNode.right != null && nextNode.Block == null)
            {

                nextNode = nextNode.right;

            }
            if (nextNode.Block != null)
            {
                if (currentNode.Block.value == nextNode.Block.value)
                {
                    nextNode.Block.Double();
                    nextNode.Block.transform.SetParent(currentNode.transform, false);
                    currentNode.Block = nextNode.Block;
                    nextNode.Block = null;
                }
                else
                {
                    Debug.Log("!Doubled");
                    nextNode.Block.transform.SetParent(currentNode.transform, false);
                    currentNode.right.Block = nextNode.Block;
                    nextNode.Block = null;
                }
            }
        }
        else
        {
            Node nextNode = currentNode.right;
            while (nextNode.right != null && nextNode.Block == null)
            {
                nextNode = nextNode.right;
                Debug.Log(nextNode);
            }
            if (nextNode.Block != null)
            {
                //nextNode.Block.transform.parent = currentNode.transform;
                nextNode.Block.transform.parent = currentNode.transform;
                currentNode.Block = nextNode.Block;
                nextNode.Block = null;
                SlideLeft(currentNode);
                Debug.Log("Slide to Empty");
            }
        }


        if (currentNode.up == null) return;
        SlideLeft(currentNode.right);
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

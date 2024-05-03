using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance;}

    public static Action<string> slide;

    [SerializeField] public int Height = 4;
    [SerializeField] public int Width = 4;

    [SerializeField] private Node _node;
    [SerializeField] private Transform[] _nodes;
    private List<Node> _nodesList;

    [SerializeField] private Board _board;

    [SerializeField] private Block _block;
    [SerializeField] private Transform[] _blocks;
    private List<Block> _blocksList;
    private void Awake()
    {
        if (GameManager.instance != null) Debug.LogError("Only 1 singleton availible");
        GameManager.instance = this;
        
    }
    private void Start()
    {
        Initialized();

        Node[,] grid = new Node[Width, Height];

        //// Khởi tạo grid và gắn các Node bên cạnh cho mỗi Node
        //for (int x = 0; x < Width; x++)
        //{
        //    for (int y = 0; y < Height; y++)
        //    {
        //        GameObject nodeObject = new GameObject("Node_" + x + "_" + y);
        //        Node node = nodeObject.AddComponent<Node>();
        //        grid[x, y] = node;

        //        // Gắn các Node bên cạnh cho Node hiện tại
        //        node.SetNeighbors(grid, x, y);
        //    }

        //}


    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            SpawnBlock();
        }

        if (Input.GetKeyUp(KeyCode.W)) {
            slide("W");
            Debug.Log(Input.GetKeyUp(KeyCode.W));
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            slide("A");
            Debug.Log(Input.GetKeyUp(KeyCode.A));
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            slide("S");
            Debug.Log(Input.GetKeyUp(KeyCode.S));
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            slide("D");
            Debug.Log(Input.GetKeyUp(KeyCode.D));
        }
    }
    private void Initialized()
    {
        _nodesList = new List<Node>();
        for (int x = 0; x < Width; x++) 
            for (int y = 0; y < Height; y++)
            {
                var node = Instantiate(_node,new Vector2(x,y), Quaternion.identity);
                node.name = "Node" + ((y+1) + (4*x));
                _nodesList.Add(node);
            }

        _nodes = new Transform[_nodesList.Count]; 
        
        for (int i = 0; i < _nodesList.Count; i++)
        {
            _nodes[i] = _nodesList[i].transform;
        }

        var center = new Vector2((float)Height / 2 - 0.5f ,(float)Width / 2 - 0.5f) ;

        var board = Instantiate(_board, center, Quaternion.identity);

        _blocks = new Transform[_nodesList.Count];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Node currentNode = _nodesList[y + (Width * x)];
                currentNode.SetNeighbors(_nodesList, x, y);

            }
        }

        Debug.Log(_nodesList[1]);

    }

    private void SpawnBlock()
    {
        
        int intPosSpawn = UnityEngine.Random.Range(0, Height * Width);
        if (AllBlocksNull())
        {
            Debug.Log("Game Over");
            return;
        }
       
        if (_blocks[intPosSpawn] != null)
        {
            Debug.Log(_blocks[intPosSpawn]);
            SpawnBlock();
            return;
        }

        float chance = UnityEngine.Random.Range(0f, 1f);
        if (chance < .2)
        {

            var block = Instantiate(_block, _nodes[intPosSpawn]);

            // Gắn block làm con của Node để nó nằm bên trong Node
            block.transform.parent = _nodesList[intPosSpawn].transform;

            _blocks[intPosSpawn] = block.transform;
        }
        else
        {
            
            var block = Instantiate(_block, _nodes[intPosSpawn]);
            _blocks[intPosSpawn] = _nodes[intPosSpawn];

        }

    }

    private bool AllBlocksNull()
    {
        foreach (var block in _blocks)
        {
            if (block == null)
            {
                return false;
            }
        }
        return true;
    }
}

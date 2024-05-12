using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public int value;

    [SerializeField] private int score;
    [SerializeField] private TextMeshPro valueDisplay;
    [SerializeField] private  int _speed = 2;
    void Start()
    {
        //// Lấy Text component từ đối tượng con
        //textComponent = GetComponentInChildren<Text>();
        //if (textComponent != null)
        //{
        //    // Thay đổi text của đối tượng con
        //    textComponent.text = "New Text";
        //}
    }

    public void UpdateValue(int inValue)
    {

        value = inValue;
        valueDisplay.text = value.ToString();
    }

    private void Update()
    {
        if(transform.localPosition != Vector3.zero) 
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, _speed*Time.deltaTime);
        }
    }
}

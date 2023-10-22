using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum RoolType : byte
{
    AllPoped,
    OneColor
}

public class BallHolder : MonoBehaviour
{
    [SerializeField] private RoolType type;
    
    private IRool _rool;
    private List<Ball> _balls;

    private void Awake()
    {
        switch (type)
        {
            case RoolType.AllPoped:
                _rool = new AllPopedRool();
                break;
                
            case RoolType.OneColor:
                _rool = new OneColorRool();
                break;
        }
    }

    private void Start()
    {
        _balls = GetComponentsInChildren<Ball>().ToList();

        foreach (Ball ball in _balls)
        {
            ball.Pop += OnBallPopAction;
        }
    }

    private void OnBallPopAction()
    {
        if (_rool.Check(_balls))
            Debug.Log("U win!!!");
    }
}
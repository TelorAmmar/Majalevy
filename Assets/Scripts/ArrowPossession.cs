using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPossession : MonoBehaviour
{
    [SerializeField]private int _maxArrow = 10;

    public int MaxArrow
    {
        get
        {
            return _maxArrow;
        }
        set
        {
            _maxArrow = value;
        }
    }

    public int _numberOfArrows = 10;

    public int NumberOfArrows
    {
        get
        {
            return _numberOfArrows;
        }
        set
        {
            _numberOfArrows = value;
            if(_numberOfArrows <= 0)
            {
                _numberOfArrows = 0;
                HasArrow = false;
            }
            else
            {
                HasArrow = true;
            }
        }
    }

    private bool _hasArrow = true;

    public bool HasArrow
    {
        get
        {
            return _hasArrow;
        }
        set
        {
            _hasArrow = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArrowUsed()
    {
        if(HasArrow)
        {
            NumberOfArrows -= 1;
        }
    }
}

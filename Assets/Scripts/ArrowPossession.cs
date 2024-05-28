using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowPossession : MonoBehaviour
{
    public UnityEvent<int, int> arrowChanged;

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
            arrowChanged?.Invoke(_numberOfArrows, _maxArrow);

            if (_numberOfArrows <= 0)
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

    public bool PickArrow(int arrowRestore)
    {
        if(NumberOfArrows < MaxArrow)
        {
            int maxPickArrow = Mathf.Max(MaxArrow - NumberOfArrows, 0);
            int actualPick = Mathf.Min(maxPickArrow, arrowRestore);
            NumberOfArrows += actualPick;
            CharacterEvents.characterPickArrow(gameObject, actualPick);
            return true;
            
        }
        
        return false;
    }
}

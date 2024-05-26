using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEvents
{
    public static UnityAction<GameObject, int> charaterDamaged; //charater damaged * damage value

    public static UnityAction<GameObject, int> charaterHealed; //character healed * amount healed

    public static UnityAction<GameObject, int> characterPickArrow; //character pick arrow

}
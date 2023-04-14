using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DishClick : MonoBehaviour
{
    [SerializeField] private CanteenLevelManager clm;
    private void OnMouseDown()
    {
        if(!clm.isClicked) 
        {
            if (clm.wishDish.sprite == GetComponent<SpriteRenderer>().sprite)
            {
                clm.isClicked= true;
                clm.human.sprite = clm.humans[clm.randomHuman].happy;
                clm.wishDish.sprite = clm.marks[1];
                GameManager.instance.win = true;
            }
            else
            {
                clm.isClicked = true;
                clm.human.sprite = clm.humans[clm.randomHuman].sad;
                clm.wishDish.sprite = clm.marks[0];
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    [SerializeField] GameObject[] redHeart;
    [SerializeField] GameObject[] greyHeart;

    private void Start()
    {
        for(int i = 0; i < redHeart.Length; i++)
        {
            redHeart[i].SetActive(true);
            greyHeart[i].SetActive(false);
        }
    }

    private void DiactivateRedHeart(int hp)
    {
        if(hp <= 0)
        {
            for(int i = redHeart.Length - 1; i >= 0; i--)
            {
                redHeart[i].SetActive(false);
            }
        }
        else
        {
            redHeart[hp].SetActive(false);
        }
    }

    private void ActivateGreyHeart(int hp)
    {
        if (hp <= 0)
        {
            for (int i = redHeart.Length - 1; i >= hp; i--)
            {
                greyHeart[i].SetActive(true);
            }
        }
        else
        {
            greyHeart[hp].SetActive(true);
        }
    }

    public void SubtractHP(int hp)
    {
        DiactivateRedHeart(hp);
        ActivateGreyHeart(hp);
    }
}

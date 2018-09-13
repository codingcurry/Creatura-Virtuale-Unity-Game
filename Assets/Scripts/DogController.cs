using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DogController : MonoBehaviour
{
    public Text affection;
    public Text hunger;
    private int _affectionLevel = 90;
    private int _hungerLevel = 90;
    private int _petCounter = 0;

    public Sprite Steak;
    public Sprite Chicken;
    public Sprite Fish;
    public Sprite Carrot;
    public Sprite Potato;
    public Sprite Mushroom;
    public Sprite Eggplant;
    public Sprite Pepper;
    public GameObject Food;
    public GameObject ChickenIcon;
    public GameObject FishIcon;
    public GameObject CarrotIcon;
    public GameObject PotatoIcon;
    public GameObject MushroomIcon;
    public GameObject EggplantIcon;
    public GameObject PepperIcon;



    public Animator DogAnimation;
    public Animator AchievementAnimation;

    public AudioSource Bite;
    public AudioSource Pat;

    // Use this for initialization
    void Start()
    {
        ChickenIcon.SetActive(false);
        FishIcon.SetActive(false);
        CarrotIcon.SetActive(false);
        PotatoIcon.SetActive(false);
        MushroomIcon.SetActive(false);
        EggplantIcon.SetActive(false);
        PepperIcon.SetActive(false);
        affection.text = _affectionLevel + "";
        hunger.text = _hungerLevel + "";
        InvokeRepeating("DecreaseHungerLevel", 0, 2);
        InvokeRepeating("DecreaseAffectionLevel", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        PetInteraction();
    }

    void PetInteraction()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(click, Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject.tag == "pet")
                {
                    _petCounter++;
                    Pat.Play();
                    if(_petCounter%10==0&&_petCounter!=0)
                    {
                        HeartAnimation();
                        if (_petCounter == 10)
                        {
                           AchievementAnimation.SetTrigger("AchievementGot");
                            ChickenIcon.SetActive(true);
                        }
                        else if (_petCounter == 20)
                        {
                            AchievementAnimation.SetTrigger("AchievementGot");
                            FishIcon.SetActive(true);
                        }
                        else if (_petCounter == 30)
                        {
                            AchievementAnimation.SetTrigger("AchievementGot");
                            CarrotIcon.SetActive(true);
                        }
                        else if (_petCounter == 40)
                        {
                            AchievementAnimation.SetTrigger("AchievementGot");
                            PotatoIcon.SetActive(true);
                        }
                        else if (_petCounter == 50)
                        {
                            AchievementAnimation.SetTrigger("AchievementGot");
                            MushroomIcon.SetActive(true);
                        }
                        else if (_petCounter == 60)
                        {
                            AchievementAnimation.SetTrigger("AchievementGot");
                            EggplantIcon.SetActive(true);
                        }
                        else if (_petCounter == 70)
                        {
                            AchievementAnimation.SetTrigger("AchievementGot");
                            PepperIcon.SetActive(true);
                        }
                    }
                    IncreaseAffectionLevel();
                }
                else if (hit.transform.gameObject.tag == "feed")
                {
                    IncreaseHungerLevel();
                    Bite.Play();
                }
                else if (hit.transform.gameObject.tag == "food_steak")
                {
                    Food.gameObject.GetComponent<SpriteRenderer>().sprite = Steak;
                }
                else if (hit.transform.gameObject.tag == "food_chicken")
                {
                    Food.gameObject.GetComponent<SpriteRenderer>().sprite = Chicken;
                }
                else if (hit.transform.gameObject.tag == "food_fish")
                {
                    Food.gameObject.GetComponent<SpriteRenderer>().sprite = Fish;
                }
                else if (hit.transform.gameObject.tag == "food_carrot")
                {
                    Food.gameObject.GetComponent<SpriteRenderer>().sprite = Carrot;
                }
                else if (hit.transform.gameObject.tag == "food_potato")
                {
                    Food.gameObject.GetComponent<SpriteRenderer>().sprite = Potato;
                }
                else if (hit.transform.gameObject.tag == "food_mushroom")
                {
                    Food.gameObject.GetComponent<SpriteRenderer>().sprite = Mushroom;
                }
                else if (hit.transform.gameObject.tag == "food_eggplant")
                {
                    Food.gameObject.GetComponent<SpriteRenderer>().sprite = Eggplant;
                }
                else if (hit.transform.gameObject.tag == "food_pepper")
                {
                    Food.gameObject.GetComponent<SpriteRenderer>().sprite = Pepper;
                }

            }
        }
    }
    void IncreaseAffectionLevel()
    {
        _affectionLevel++;
        if (_affectionLevel > 100)
        {
            _affectionLevel = 100;
            DecreaseHungerLevel();
            DecreaseHungerLevel();
            DecreaseHungerLevel();
            DecreaseHungerLevel();
            DecreaseHungerLevel();
        }
        affection.text = _affectionLevel + "";
    }
    void IncreaseHungerLevel()
    {
        _hungerLevel++;
        if (_hungerLevel > 100)
        {
            _hungerLevel = 100;
            DecreaseAffectionLevel();
            DecreaseAffectionLevel();
            DecreaseAffectionLevel();
            DecreaseAffectionLevel();
            DecreaseAffectionLevel();
        }
        hunger.text = _hungerLevel + "";
    }

    void DecreaseAffectionLevel()
    {
        _affectionLevel--;
        affection.text = _affectionLevel + "";
        if (_affectionLevel <= 0)
        {
            DogAnimation.SetTrigger("DogDeath");
            Invoke("GameOver", 2);
        }
    }

    void DecreaseHungerLevel()
    {
        _hungerLevel--;
        hunger.text = _hungerLevel + "";
        if (_hungerLevel <= 0)
        {
            DogAnimation.SetTrigger("DogDeath");
            Invoke("GameOver", 2);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    void HeartAnimation()
    {
        DogAnimation.SetTrigger("DogHappy");
    }
}


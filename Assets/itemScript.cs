using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemScript : MonoBehaviour
{

    public TrailRenderer it1, it2, it3;
    public Color normal = new Color(153f / 255f, 255f / 255f, 134f / 255f);
    public Color rare = new Color(173f / 255f, 255f / 255f, 255f / 255f);
    public Color legendary = new Color(255f / 255f, 162f / 255f, 0f / 255f);

    public Material mat_normal, mat_rare, mat_legendary;

    public MeshRenderer m1, m2, m3;

    public Image i1, i2, i3;

    public Animator boxAnim, itemAnim;

    public Sprite borg, drink, book, box, chip;

    public Button reset, back;

    public GameObject counter;
    public TMP_Text counter_txt;

    // Start is called before the first frame update
    void Start()
    {
        counter_txt.SetText(globalVars.lootboxes_left.ToString());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource bgm;

    public float show_items_delay = 7f;
    public void generateItems()
    {
        globalVars.lootboxes_left--;
        counter_txt.SetText(globalVars.lootboxes_left.ToString());

        StartCoroutine(generator((int)show_items_delay));
    }

    public int box_chance = 40;
    public int double_box_chance = 5;


    IEnumerator generator(int secs)
    {
        Debug.Log("showing items");
        
        it1.startColor = normal;
        it1.endColor = normal;
        it2.startColor = normal;
        it2.endColor = normal;
        it3.startColor = normal;
        it3.endColor = normal;
        m1.material = mat_normal;
        m2.material = mat_normal;
        m3.material = mat_normal;

        int rareboxnr = Random.Range(0, 3);
        int rng = Random.Range(0, 100);

        switch(rareboxnr)
        {
            case 0:
                if(rng < box_chance) // rolled a lootbox!
                {
                    it1.startColor = legendary;
                    it1.endColor = legendary;
                    m1.material = mat_legendary;
                    i1.sprite = box;
                    globalVars.lootboxes_left++;
                }
                else // rolled another rare item!
                {
                    it1.startColor = rare;
                    it1.endColor = rare;
                    m1.material = mat_rare;
                    i1.sprite = drink;
                    globalVars.drinks++;
                }
                if(rng<double_box_chance)
                {
                    it2.startColor = legendary;
                    it2.endColor = legendary;
                    m2.material = mat_legendary;
                    i2.sprite = box;
                    globalVars.lootboxes_left++;
                }
                else
                {
                    rng = Random.Range(0, 3);
                    if (rng == 0) // borger
                    {
                        i2.sprite = borg;
                        globalVars.borgers++;
                    }
                    else if (rng == 1) // chip
                    {
                        i2.sprite = chip;
                        globalVars.chips++;
                    }
                    else //book
                    {
                        i2.sprite = book;
                        globalVars.books++;
                    }
                }
                rng = Random.Range(0, 3);
                if (rng == 0) // borger
                {
                    i3.sprite = borg;
                    globalVars.borgers++;
                }
                else if (rng == 1) // chip
                {
                    i3.sprite = chip;
                    globalVars.chips++;
                }
                else //book
                {
                    i3.sprite = book;
                    globalVars.books++;
                }
                break;

            case 1:
                if (rng < box_chance) // rolled a lootbox!
                {
                    it2.startColor = legendary;
                    it2.endColor = legendary;
                    m2.material = mat_legendary;
                    i2.sprite = box;
                    globalVars.lootboxes_left++;
                }
                else // rolled another rare item!
                {
                    it2.startColor = rare;
                    it2.endColor = rare;
                    m2.material = mat_rare;
                    i2.sprite = drink;
                    globalVars.drinks++;
                }
                if (rng < double_box_chance)
                {
                    it1.startColor = legendary;
                    it1.endColor = legendary;
                    m1.material = mat_legendary;
                    i1.sprite = box;
                    globalVars.lootboxes_left++;
                }
                else
                {
                    rng = Random.Range(0, 3);
                    if (rng == 0) // borger
                    {
                        i1.sprite = borg;
                        globalVars.borgers++;
                    }
                    else if (rng == 1) // chip
                    {
                        i1.sprite = chip;
                        globalVars.chips++;
                    }
                    else //book
                    {
                        i1.sprite = book;
                        globalVars.books++;
                    }
                }
                rng = Random.Range(0, 3);
                if (rng == 0) // borger
                {
                    i3.sprite = borg;
                    globalVars.borgers++;
                }
                else if (rng == 1) // chip
                {
                    i3.sprite = chip;
                    globalVars.chips++;
                }
                else //book
                {
                    i3.sprite = book;
                    globalVars.books++;
                }
                break;

            case 2:
                if (rng < box_chance) // rolled a lootbox!
                {
                    it3.startColor = legendary;
                    it3.endColor = legendary;
                    m3.material = mat_legendary;
                    i3.sprite = box;
                    globalVars.lootboxes_left++;
                }
                else // rolled another rare item!
                {
                    it3.startColor = rare;
                    it3.endColor = rare;
                    m3.material = mat_rare;
                    i3.sprite = drink;
                    globalVars.drinks++;
                }
                if (rng < double_box_chance)
                {
                    it2.startColor = legendary;
                    it2.endColor = legendary;
                    m2.material = mat_legendary;
                    i2.sprite = box;
                    globalVars.lootboxes_left++;
                }
                else
                {
                    rng = Random.Range(0, 3);
                    if (rng == 0) // borger
                    {
                        i2.sprite = borg;
                        globalVars.borgers++;
                    }
                    else if (rng == 1) // chip
                    {
                        i2.sprite = chip;
                        globalVars.chips++;
                    }
                    else //book
                    {
                        i2.sprite = book;
                        globalVars.books++;
                    }
                }
                rng = Random.Range(0, 3);
                if (rng == 0) // borger
                {
                    i1.sprite = borg;
                    globalVars.borgers++;
                }
                else if (rng == 1) // chip
                {
                    i1.sprite = chip;
                    globalVars.chips++;
                }
                else //book
                {
                    i1.sprite = book;
                    globalVars.books++;
                }
                break;

        }

        counter_txt.SetText(globalVars.lootboxes_left.ToString());

        yield return new WaitForSeconds(secs);
        i1.gameObject.SetActive(true);
        i2.gameObject.SetActive(true);
        i3.gameObject.SetActive(true);

       // i1.sprite = borg;
      //  i2.sprite = drink;
      //  i3.sprite = box;

        //it1.startColor = normal;
        //it1.endColor = normal;
        //it2.startColor = rare;
        //it2.endColor = rare;
        //it3.startColor = legendary;
        //it3.endColor = legendary;

        back.gameObject.SetActive(true);
        counter.gameObject.SetActive(true);
        bgm.UnPause();

        if (globalVars.lootboxes_left > 0)
        {
            yield return new WaitForSeconds(1);
            reset.gameObject.SetActive(true);
        }
    }
}
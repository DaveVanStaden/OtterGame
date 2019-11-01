using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OtterCollector : MonoBehaviour
{
    private int points;
    private float MaxPoints;

    [SerializeField] private GameObject foodStuff;
    [SerializeField] private Text pointText;
    [SerializeField] private Camera camera;
    private void Start()
    {
        MaxPoints = StaticVariable.MaxScore;
        print(MaxPoints);
    }
    void Update()
    {
        pointText.text = "= " + points.ToString();
        if(points == MaxPoints)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Food")
        {
            var foodstuffs = Instantiate(foodStuff, new Vector2(Random.Range(-8.3f, -6.7f), Random.Range(4.5f, 3.25f)), Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            foodstuffs.GetComponent<SpriteRenderer>().sprite = collider.GetComponent<SpriteRenderer>().sprite;
            foodstuffs.GetComponent<SpriteRenderer>().sortingOrder += points;
            points++;
            Destroy(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "Hoop")
        {
            points += 5;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds;
    [SerializeField] private List<GameObject> objectFrames;
    [SerializeField] private Vector2 spawnPosition;

    private float stopTime = 5f;
    private float startTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        if (startTime >= stopTime)
        {
            startTime = 0f;
            SpawnBackgroundAndObjects();
        }
    }

    private void SpawnBackgroundAndObjects()
    {
        var TempWall = Instantiate(backgrounds[Random.Range(0, backgrounds.Count)], spawnPosition, Quaternion.identity);
        var TempObjectFrame = Instantiate(objectFrames[Random.Range(0, backgrounds.Count)], spawnPosition, Quaternion.identity);
        var TempRigid = TempWall.GetComponent<Rigidbody2D>();
        var TempFrameRigid = TempObjectFrame.GetComponent<Rigidbody2D>();
        TempRigid.velocity = new Vector2(-4, 0);
        TempFrameRigid.velocity = new Vector4(-4, 0);
    }
}

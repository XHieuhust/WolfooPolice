using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListHouse : MonoBehaviour
{
    [SerializeField] List<Sprite> spritesHouse;
    [SerializeField] List<GameObject> houses = new List<GameObject>();
    [SerializeField] Transform endHouse;
    private void Awake()
    {
        GameScene12Manager.ins.endPosition = endHouse;
        int cnt_sprite = spritesHouse.Count;
        int cnt = 0;
        float centerPositionY = GameScene12Manager.ins.road.transform.position.y;
        float sizeRoad = GameScene12Manager.ins.road.GetComponent<SpriteRenderer>().size.y / 2;
        foreach (GameObject house in houses)
        {
            house.GetComponent<SpriteRenderer>().sprite = spritesHouse[(cnt++) % cnt_sprite];
            house.transform.position = new Vector3(house.transform.position.x, centerPositionY + sizeRoad);
        }
    }
}

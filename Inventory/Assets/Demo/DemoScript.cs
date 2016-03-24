using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Spade.Item;

public enum ItemType { WHITE=0, RED=1, BLUE=2, GREEN=3 };

public class DemoScript : MonoBehaviour
{

    List<SampleItem> allitemlist = null;
    List<SampleItem> whiteitemlist = null;
    List<SampleItem> reditemlist = null;
    List<SampleItem> blueitemlist = null;
    List<SampleItem> greenitemlist = null;

    void Start()
    {
        Inventory.instance.Initialize();
    }

	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 50), "Setup"))
        {
            Clear();

            Locker locker = new Locker();

            for (int i = 0; i < 20; i++)
            {
                LockerItem litem = new LockerItem();
                litem.id = i;
                litem.base_item_id = i * i;
                litem.status = "Test_" + i;
                litem.type = Random.Range(0, 4);

                locker.weapon_map.Add(i.ToString(), litem);
            }

            Inventory.instance.ClearAllBucket();
            Inventory.instance.UpdateLocker(locker);

            GreatBucket bucket = Inventory.GetBucket<GreatBucket>();

            allitemlist = bucket.GetItemList();
        }

        if (allitemlist != null)
        {
            if (GUI.Button(new Rect(200, 0, 200, 50), "White"))
            {
                WhiteBucket bucket = Inventory.GetBucket<WhiteBucket>();
                whiteitemlist = bucket.GetItemList();
            }
            if (GUI.Button(new Rect(400, 0, 200, 50), "Red"))
            {
                RedBucket bucket = Inventory.GetBucket<RedBucket>();
                reditemlist = bucket.GetItemList();
            }
            if (GUI.Button(new Rect(600, 0, 200, 50), "Blue"))
            {
                BlueBucket bucket = Inventory.GetBucket<BlueBucket>();
                blueitemlist = bucket.GetItemList();
            }
            if (GUI.Button(new Rect(800, 0, 200, 50), "Green"))
            {
                GreenBucket bucket = Inventory.GetBucket<GreenBucket>();
                greenitemlist = bucket.GetItemList();
            }
        }

        if (GUI.Button(new Rect(0, 50, 200, 50), "Clear"))
        {
            Clear();
        }
        
        if (allitemlist != null)
        {
            DrawItem(0, allitemlist);
        }
        if (whiteitemlist != null)
        {
            DrawItem(1, whiteitemlist);
        }
        if (reditemlist != null)
        {
            DrawItem(2, reditemlist);
        }
        if (blueitemlist != null)
        {
            DrawItem(3, blueitemlist);
        }
        if (greenitemlist != null)
        {
            DrawItem(4, greenitemlist);
        }
    }

    void Clear()
    {
        Inventory.instance.ClearAllBucket();
        allitemlist = null;
        whiteitemlist = null;
        reditemlist = null;
        blueitemlist = null;
        greenitemlist = null;
    }

    void DrawItem(int line,List<SampleItem> itemlist)
    {
        Color current = GUI.color;
        for (int j = 0; j < itemlist.Count; j++)
        {
            Color back = Color.white;
            switch (itemlist[j].Type)
            {
                case ItemType.WHITE: back = Color.white; break;
                case ItemType.RED: back = Color.red; break;
                case ItemType.BLUE: back = Color.blue; break;
                case ItemType.GREEN: back = Color.green; break;
            }
            GUI.color = back;
            GUI.Label(new Rect(line * 200, 120 + (20 * j), 200, 20), itemlist[j].Name);
        }
        GUI.color = current;
    }
}
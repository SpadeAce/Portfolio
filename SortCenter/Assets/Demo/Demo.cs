using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SAL.Sort;

public class Demo : MonoBehaviour
{

    public int MinNumber = 0;
    public int MaxNumber = 100;

    public int ListCount = 20;

    private List<CustomObject> list = null;
    private List<CustomObject> sortlist = null;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        #region Create
        if(GUI.Button(new Rect(0,0,200,100),"Create List"))
        {
            list = new List<CustomObject>();
            sortlist = null;

            for (int i=0;i<ListCount;i++)
            {
                CustomObject co = new CustomObject();
                co.CompareVar = Random.Range(MinNumber, MaxNumber);
                co.FakeVar = i;
                co.Name = "Object" + i;
                list.Add(co);
            }
        }
        #endregion

        #region Sequence
        if (list != null && list.Count > 0 && GUI.Button(new Rect(250, 0, 150, 30), "Sequence(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(250,30,150,30),"Sequence(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region Bubble
        if (list != null && list.Count > 0 && GUI.Button(new Rect(400, 0, 150, 30), "Bubble(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeBubble, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(400, 30, 150, 30), "Bubble(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeBubble, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region Selection
        if (list != null && list.Count > 0 && GUI.Button(new Rect(550, 0, 150, 30), "Selection(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeSelection, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(550, 30, 150, 30), "Selection(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeSelection, CustomObject>(list, CompareFunc);
        }
        #endregion    

        #region Insertion
        if (list != null && list.Count > 0 && GUI.Button(new Rect(700, 0, 150, 30), "Insertion(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeInsertion, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(700, 30, 150, 30), "Insertion(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeInsertion, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region Shell
        if (list != null && list.Count > 0 && GUI.Button(new Rect(850, 0, 150, 30), "Shell(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeShell, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(850, 30, 150, 30), "Shell(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeShell, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region Quick
        if (list != null && list.Count > 0 && GUI.Button(new Rect(1000, 0, 150, 30), "Quick(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeQuick, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(1000, 30, 150, 30), "Quick(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeQuick, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region sort
        if (list != null && list.Count > 0 && GUI.Button(new Rect(250, 70, 150, 30), "(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(250, 100, 150, 30), "(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region sort
        if (list != null && list.Count > 0 && GUI.Button(new Rect(400, 70, 150, 30), "(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(400, 100, 150, 30), "(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region sort
        if (list != null && list.Count > 0 && GUI.Button(new Rect(550, 70, 150, 30), "(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(550, 100, 150, 30), "(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region sort
        if (list != null && list.Count > 0 && GUI.Button(new Rect(700, 70, 150, 30), "(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(700, 100, 150, 30), "(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region sort
        if (list != null && list.Count > 0 && GUI.Button(new Rect(850, 70, 150, 30), "(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(850, 100, 150, 30), "(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }
        #endregion    
        
        #region sort
        if (list != null && list.Count > 0 && GUI.Button(new Rect(1000, 70, 150, 30), "(Original)"))
        {
            sortlist = SortCenter.instance.SyncOriginalSorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }

        if (list != null && list.Count > 0 && GUI.Button(new Rect(1000, 100, 150, 30), "(Copy)"))
        {
            sortlist = SortCenter.instance.SyncCopySorting<SortModeSequence, CustomObject>(list, CompareFunc);
        }
        #endregion

        #region ListView
        if (list != null && list.Count > 0)
        {
            for(int i=0;i< list.Count;i++)
            {
                GUI.Label(new Rect(30 * i, 160, 30, 20), list[i].FakeVar.ToString());
                GUI.TextField(new Rect(30 * i, 180, 30, 20), list[i].CompareVar.ToString());
            }
        }

        if(sortlist!=null && sortlist.Count>0)
        {
            for(int i=0;i< sortlist.Count;i++)
            {
                GUI.Label(new Rect(30 * i, 230, 30, 20), sortlist[i].FakeVar.ToString());
                GUI.TextField(new Rect(30 * i, 250, 30, 20), sortlist[i].CompareVar.ToString());
            }
        }
        #endregion
    }

    public bool CompareFunc(CustomObject com1, CustomObject com2)
    {
        return com1.CompareVar > com2.CompareVar;
    }
}

public class CustomObject
{
    public int CompareVar;
    public int FakeVar;
    public string Name;
}
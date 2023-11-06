using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrangPhucCanhSat : DragSprite
{

    public override void CorrectDrag()
    {
        base.CorrectDrag();
        QuanLyPolice.ins.AddPoliceDaMacDo(firstTrueObject);

    }

    public override void ChangeScale()
    {
        transform.localScale = new Vector2(scaleNormal.x * 1.2f, scaleNormal.x * 1.2f);
    }
}

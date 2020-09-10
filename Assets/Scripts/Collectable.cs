﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected;

    protected override void OnCollie(Collider2D coll)
    {
        if (coll.name == "Player") {
            OnCollect();
        }
    }

    protected virtual void OnCollect() {
        
    }
}

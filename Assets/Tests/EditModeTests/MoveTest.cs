using System.Collections;
using System.Collections.Generic;
using Infrastructure.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MoveTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void MoveTestSimplePasses()
    {
        var v = new PlayerMovementDirectionService().GetDirection(Vector2.zero);

        Assert.AreEqual(0, v.x);

    }

    [Test]
    public void MoveTestSimpleNoPasses()
    {
        var v = new PlayerMovementDirectionService().GetDirection(Vector2.zero);

        Assert.AreEqual(1, v.x);

    }
}

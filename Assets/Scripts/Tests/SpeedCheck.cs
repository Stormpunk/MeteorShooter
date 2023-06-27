using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpeedCheck
{

    private GameObject playerPrefab;
    private GameObject playerInstance;
    private Movement movement;

    [SetUp]
    public void Setup()
    {
        playerPrefab = Resources.Load<GameObject>("Prefab/Spacer");
        playerInstance = GameObject.Instantiate(playerPrefab);
        movement = playerInstance.GetComponent<Movement>();
    }
    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(playerInstance);
    }
    [UnityTest]
    public IEnumerator CheckSpeed()
    {
        movement.Start();
        yield return null;
        Assert.AreEqual(0.1, movement.moveSpeed, 0.001f);
    }
}

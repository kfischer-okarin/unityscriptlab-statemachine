using System.Collections;

using NUnit.Framework;

using UnityEngine;
using UnityEngine.TestTools;

using UnityScriptLab.StateMachine;

namespace Tests.StateMachine {
  public class StatefulBehaviourTests {
    public enum Color {
      Red,
      Blue
    }
    class TestComponent : StatefulBehaviour<Color> {
      protected override Color InitialState { get { return Color.Red; } }

      public bool handleStateCalled;

      public override void HandleState(Color color) {
        handleStateCalled = true;
      }
    }

    GameObject go;
    TestComponent behaviour;

    void PrepareObject() {
      go = new GameObject("Object");
      behaviour = go.AddComponent<TestComponent>();
    }

    [UnityTest]
    public IEnumerator AddsStateMachineRunnerTest() {
      PrepareObject();
      Assert.That(go.GetComponent<StateMachineRunner>(), Is.Not.Null);
      yield return null;
    }

    [UnityTest]
    public IEnumerator ComponentHandlesStateChangeTest() {
      PrepareObject();
      Assert.That(behaviour.handleStateCalled, Is.False);
      yield return null;
      Assert.That(behaviour.handleStateCalled, Is.True);
    }
  }
}

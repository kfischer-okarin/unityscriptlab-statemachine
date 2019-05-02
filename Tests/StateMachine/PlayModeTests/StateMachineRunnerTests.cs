using System;
using System.Collections;

using NSubstitute;

using NUnit.Framework;

using UnityEngine;
using UnityEngine.TestTools;

using UnityScriptLab;
using UnityScriptLab.StateMachine;

namespace Tests.StateMachine {
  public class StateMachineRunnerTests {
    class TestComponent : MonoBehaviour, StateMachineProvider {
      public static Updatable stateMachine;
      public Updatable StateMachine { get { return stateMachine; }  }
    }

    [UnityTest]
    public IEnumerator RunsStateMachinesOnSameGameObjectTest() {
      TestComponent.stateMachine = Substitute.For<Updatable>();
      GameObject go = new GameObject("Object");
      go.AddComponent<TestComponent>();
      go.AddComponent<StateMachineRunner>();
      yield return null;
      TestComponent.stateMachine.Received().Update();
    }
  }
}

using System.Collections.Generic;

using UnityEngine;

namespace UnityScriptLab.StateMachine {
  /// <summary>
  /// Executes StateMachines in the same GameObject.
  /// </summary>
  public class StateMachineRunner : MonoBehaviour {
    List<Updatable> stateMachines = new List<Updatable>();
    void Start() {
      foreach(StateMachineProvider p in GetComponents<StateMachineProvider>()) {
        stateMachines.Add(p.StateMachine);
      }
    }

    void Update() {
      foreach(Updatable stateMachine in stateMachines) {
        stateMachine.Update();
      }
    }
  }
}

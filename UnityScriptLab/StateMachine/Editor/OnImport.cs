#if UNITY_EDITOR && (UNITYSCRIPTLAB_STATEMACHINE == false)

using UnityEditor;

using UnityEngine;

namespace UnityScriptLab.StateMachine {
  [InitializeOnLoad]
  public class Autorun {
    static Autorun() {
      BuildTargetGroup buildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
      string definedSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
      PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, $"{definedSymbols};UNITYSCRIPTLAB_STATEMACHINE");
    }
  }
}
#endif

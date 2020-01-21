using Boo.Lang;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace DeveGames.Tools.SceneOpener.Editor
{
    public class SceneOpenerWindow : OdinMenuEditorWindow
    {
        private readonly ButtonSizes _buttonSize = ButtonSizes.Small;
        private readonly Vector2 _windowSize = new Vector2(10f, 10f);
        
        [TableList(IsReadOnly = true, AlwaysExpanded = true), ShowInInspector]
        public List<SceneOpenerButton> _sceneOpenerButtons;
        
        [MenuItem("DeveGames/Tools/Scene Opener")]
        private static void OpenWindow()
        {
            var window = GetWindow<SceneOpenerWindow>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);  
        }
        
        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(true);
            tree.DefaultMenuStyle.IconSize = 28.00f;
            tree.Config.DrawSearchToolbar = true;

            for (int i = 0; i < 5; i++)
            {
                tree.Add("Characters", _sceneOpenerButtons);                
            }
            return tree;
        }        
    }
    
    public class SceneOpenerButton
    {
        
    }
}

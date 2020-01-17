/*The MIT License (MIT)
Copyright (c) 2019 PhaxeNor (@PhaxeNor)
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

/*
Credit to https://gist.github.com/edwardrowe/acda1ee53eb037b31d54d583afc13973
*/

using UnityEngine;
using UnityEditor;
using VRC.Udon;


namespace PhaxeNor
{
    [InitializeOnLoad]
    public class UdonHierarchy
    {
        private static readonly Texture2D icon;
        private const float iconWidth = 12;

        static UdonHierarchy()
        {
            icon = AssetDatabase.LoadAssetAtPath("Assets/Resources/PhaxeNor/UdonHierarchy/Editor/Resources/UdonIcon.png", typeof(Texture2D)) as Texture2D; 

            if(icon == null) return;

            EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
        }

        static void HierarchyItemCB(int instanceID, Rect  rect)
        {
            if(icon == null) return;

            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if(gameObject == null) return;

            var udonBehaviour = gameObject.GetComponent<UdonBehaviour>();

            if(udonBehaviour != null)
            {
                EditorGUIUtility.SetIconSize(new Vector2(iconWidth, iconWidth));
                var padding = new Vector2(2, 1);
                var iconDrawRect = new Rect(
                    rect.xMax - (iconWidth + padding.x),
                    rect.yMin + padding.y,
                    rect.width,
                    rect.height);

                    var iconGUIContent = new GUIContent(icon);
                    EditorGUI.LabelField(iconDrawRect, iconGUIContent);
                    EditorGUIUtility.SetIconSize(Vector2.zero);
            }
        }
    }
}
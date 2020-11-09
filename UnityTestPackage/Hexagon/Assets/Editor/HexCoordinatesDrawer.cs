/*
 * 讓HeCell能在Inspector上顯示座標，且只能讀取不能改寫。
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(HexCoordinates))]
public class HexCoordinatesDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //取得HexCell自身座標。
        HexCoordinates coordinates = new HexCoordinates(
            property.FindPropertyRelative("x").intValue,
            property.FindPropertyRelative("z").intValue
        );

        //讓Inspector的座標前面加上coordinates這個名稱。
        position = EditorGUI.PrefixLabel(position, label);

        //顯示在Inspector上。
        GUI.Label(position, coordinates.ToString());
    }

}//HexCoordinatesDrawer

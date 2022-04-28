// NOTE: Put in a Editor folder. //

using UnityEditor;
using UnityEngine;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(NoteAttribute))]
    public class NoteDecoratorDrawer : DecoratorDrawer
    {
        NoteAttribute noteAttribute;
        readonly float _padding = 10f;
        private float _height;

        public override float GetHeight()
        {
            noteAttribute = attribute as NoteAttribute;

            GUIStyle style = EditorStyles.helpBox;
            style.alignment = TextAnchor.MiddleLeft;
            style.clipping = TextClipping.Clip;
            style.wordWrap = true;
            style.padding = new RectOffset(10, 10, 10, 10);
            style.margin = new RectOffset(0, 5, 0, 5);
            style.fontSize = 12;

            GUIContent content = new GUIContent(noteAttribute.Text + "\n\n");
            _height = style.CalcHeight(content, Screen.width);

            return _height + _padding;
        }

        public override void OnGUI(Rect position)
        {
            position.height = _height;
            position.y += _padding * 0.5f;
            EditorGUI.HelpBox(position, noteAttribute.Text, (MessageType)noteAttribute.Message);
        }
    }
}
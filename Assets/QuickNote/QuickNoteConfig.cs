using UnityEngine;

namespace QuickNote
{
    [CreateAssetMenu(fileName = "QuickNoteConfig", menuName = "QuickNote/Config")]
    public class QuickNoteConfig : ScriptableObject
    {
        ////////////////////
        /// This class will allow the user to define a config for their notes: Color, default height, font-size
        ////////////////////
        [Tooltip("The color for the header text.")]
        [SerializeField] public Color headerColor = Color.cyan;
        [Tooltip("Set the color for the text of the note (body text).")]
        [SerializeField] public Color fontColor = Color.green;
        [Tooltip("The input height for your note (vertical scale)")]
        [SerializeField] public float defaultHeight = 60f;
        [Tooltip("The size of the text for your note.")]
        [SerializeField] public int fontSize = 14;

        [Header("Runtime exclusive variables")]
        [Tooltip
            (
                "Makes for a cleaner runtime version if true. Every instance of 'QuickNote' will be removed at runtime (will not have an effect on editor use). " +
                "This is preferred to save on memory, although the notes themselves will only consume in the kilobytes of memory with thousands of instances. " +
                "The difference is mostly negligible."
            )
        ]
        [SerializeField] public bool removeFromRuntime = true;
    }
}
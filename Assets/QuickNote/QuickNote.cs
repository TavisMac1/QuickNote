using UnityEngine;

namespace QuickNote
{
    public class QuickNote : MonoBehaviour
    {
#nullable enable
#pragma warning disable CS0414
        [SerializeField] private string? noteHeader = new("Quick Note");
        [SerializeField] private string note = new("Type your note here");
        [SerializeField] private string lastModifiedDate = new(string.Empty);
        [SerializeField] private string lastModifiedBy = new(string.Empty);
#pragma warning restore CS0414

        private void Awake()
        {
            var quickNoteConfig = Resources.Load<QuickNoteConfig>("QuickNoteConfig");

            if (quickNoteConfig == null)
            {
                Debug.LogError
                (
                    string.Concat
                    (
                         "Object of type <QuickNoteConfig> is null. ",
                         "Please ensure there is an instance of <QuickNoteConfig> in the 'QuickNote/Assets' directory."
                    )
                );
                return;
            }

            if ((bool)quickNoteConfig.removeFromRuntime)
                Destroy(this);
        }
    }
}
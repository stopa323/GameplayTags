using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Tag")]
public class Tag : ScriptableObject {
    [SerializeField]
    private string _tagName;

    [SerializeField]
    private Tag _parent;

    [SerializeField]
    private Tag[] _children;

    public string GetTagName() => _tagName;

    public Tag GetDirectParent() => _parent;

    public TagContainer GetChildrenContainer() => new TagContainer(_children);

    public bool MatchesAny(TagContainer containerToCheck) {
        if (containerToCheck == null) return false;

        foreach(var tag in containerToCheck.GameplayTags) {
            if (MatchesTag(tag)) return true;
        }
        
        return false;
    }

    public bool MatchesAnyExact(TagContainer containerToCheck) {
        if (containerToCheck == null) return false;

        foreach(var tag in containerToCheck.GameplayTags) {
            if (MatchesTagExact(tag)) return true;
        }
        
        return false;
    }

    public bool MatchesTag(Tag tagToCheck) { 
        if (tagToCheck == null) return false;

        if (_tagName == tagToCheck.GetTagName()) return true;
        
        if (_parent == null) return false;

        return _parent.MatchesTag(tagToCheck);
    }

    public bool MatchesTagExact(Tag tagToCheck) {
        return _tagName == tagToCheck.GetTagName();
    }

    void OnEnable() {
        SetDefaultName();
    }

    void OnValidate() {
        SetDefaultName();
    }

    private void SetDefaultName() {
        if (_tagName == string.Empty) { _tagName = name; }
    }
}

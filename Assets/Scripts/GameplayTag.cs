using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Tag")]
public class GameplayTag : ScriptableObject {
    [SerializeField]
    private string _tagName;

    [SerializeField]
    private GameplayTag _parent;

    [SerializeField]
    private GameplayTag[] _children;

    public string GetTagName() => _tagName;

    public GameplayTag GetDirectParent() => _parent;

    public GameplayTagContainer GetChildrenContainer() => new GameplayTagContainer(_children);

    public bool MatchesAny(GameplayTagContainer containerToCheck) {
        if (containerToCheck == null) return false;

        foreach(var tag in containerToCheck.GameplayTags) {
            if (MatchesTag(tag)) return true;
        }
        
        return false;
    }

    public bool MatchesAnyExact(GameplayTagContainer containerToCheck) {
        if (containerToCheck == null) return false;

        foreach(var tag in containerToCheck.GameplayTags) {
            if (MatchesTagExact(tag)) return true;
        }
        
        return false;
    }

    public bool MatchesTag(GameplayTag tagToCheck) { 
        if (tagToCheck == null) return false;

        if (_tagName == tagToCheck.GetTagName()) return true;
        
        if (_parent == null) return false;

        return _parent.MatchesTag(tagToCheck);
    }

    public bool MatchesTagExact(GameplayTag tagToCheck) {
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


public class GameplayTagContainer {
    public GameplayTag[] GameplayTags { get; private set; }

    public GameplayTagContainer(GameplayTag[] children) {
        GameplayTags = children;
    }

    public bool HasTag(GameplayTag tagToCheck) {
        foreach(var tag in GameplayTags) {
            if (tag.MatchesTag(tagToCheck)) return true;
        }

        return false;
    }
    
    public bool HasTagExact(GameplayTag tagToCheck) {
        foreach(var tag in GameplayTags) {
            if (tag.MatchesTagExact(tagToCheck)) return true;
        }

        return false;
    }
}

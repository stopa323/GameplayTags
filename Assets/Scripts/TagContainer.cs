public class TagContainer {
    public Tag[] GameplayTags { get; private set; }

    public TagContainer(Tag[] children) {
        GameplayTags = children;
    }

    public bool HasTag(Tag tagToCheck) {
        foreach(var tag in GameplayTags) {
            if (tag.MatchesTag(tagToCheck)) return true;
        }

        return false;
    }
    
    public bool HasTagExact(Tag tagToCheck) {
        foreach(var tag in GameplayTags) {
            if (tag.MatchesTagExact(tagToCheck)) return true;
        }

        return false;
    }
}

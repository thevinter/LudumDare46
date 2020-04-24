
public class SampleQuest : Quest
{
    public override bool IsCompleted() {
        if (WorldState.isDoorOpen) {
            return true;
        }
        else return false;
    }
}

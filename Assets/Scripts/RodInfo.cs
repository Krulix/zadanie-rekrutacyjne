public class RodInfo
{
    public string rodName;
    public int quality;
    public int level;
    public int cardsAmount;
    public int rodId;
    public int category;

    public int nextLevelCards
    {
        get
        {
            return level * 4;
        }
    }
}

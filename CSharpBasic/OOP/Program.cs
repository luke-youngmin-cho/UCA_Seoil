namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Eagle eagle = new Eagle();
            Pigeon pigeon = new Pigeon();
            Human human = new Human();
            eagle.Fall();

            ITwoLeggedWalker[] twoLeggedWalkers = new ITwoLeggedWalker[3];
            twoLeggedWalkers[0] = eagle;
            twoLeggedWalkers[1] = pigeon;
            twoLeggedWalkers[2] = human;

            ITwoLeggedWalker twoLeggedWalker = new Eagle(); // Eagle 을 생성했으나, 현재는 이족보행기능만 상호작용할것이다.

            for (int i = 0; i < twoLeggedWalkers.Length; i++)
            {
                twoLeggedWalkers[i].TwoLeggedWalk();
            }
        }
    }
}

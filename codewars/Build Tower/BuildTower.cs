public class BuildTower
{
    public static string[] TowerBuilder(int nFloors)
    {
        var result = new string[nFloors];
        for (int i=0;i<nFloors;i++)
        result[i] = string.Concat(new string(' ',nFloors - i - 1), new string('*',i * 2 + 1), new string(' ',nFloors - i - 1));
        return result;
    }
        
}
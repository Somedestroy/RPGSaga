using System;
public class FunWithTree
{
    public static int MaxSum(TreeNode root)
      {
        if (root == null) return 0;
        return (root.value + Math.Max(MaxSum(root.left), MaxSum(root.right)));
      }
}
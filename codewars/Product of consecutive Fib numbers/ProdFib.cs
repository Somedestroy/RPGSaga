public class ProdFib {
  public static ulong[] productFib(ulong prod) 
    {
      ulong previous = 0;
      ulong current = 1;
      ulong multiply = previous * current;
      while (multiply < prod)
        {
          ulong temp = current;
          current += previous;
          previous = temp;
          multiply = previous * current;
        }
    return new ulong [] {previous, current, multiply == prod? 1UL : 0UL}; 
    }
}
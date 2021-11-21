
using System;
public class Veci
{
    public int x, y;

    public Veci() : this(0,0){
        
    }
    public Veci(int x, int y){
        this.x = x;
        this.y = y;
    }

    public override bool Equals(Object obj){
        if (obj == null || !GetType().Equals(obj.GetType()))
            return false;
        Veci v = (Veci) obj;
        return v.x == x && v.y == y;
    } 
}

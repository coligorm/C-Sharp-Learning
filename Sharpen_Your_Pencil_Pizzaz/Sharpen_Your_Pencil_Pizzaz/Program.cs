Pizzaz foxtrot = new Pizzaz() { Zippo = 2 };            // foxtrot.Zippo = 2
foxtrot.Bamboo(foxtrot.Zippo);                          // foxtrot.Zippo = 4 (Bamboo(2) => 2 += 2)

Pizzaz november = new Pizzaz() { Zippo = 3 };           // november.Zippo = 3
Abracadabra tango = new Abracadabra() { Vavavoom = 4 }; // tango.Vavavoom = 4

while (tango.Lala(november.Zippo)) // L1:true (tango.Lala(3) => 3 < 4 => tango.Vavavoom = 7 | L2:false (tango.Lala(4) => 4 < -1
{
    november.Zippo *= -1;               // L1: november.Zippo = -3
    november.Bamboo(tango.Vavavoom);    // L1: november.Zippo = 4 (-3 + 7)
    foxtrot.Bamboo(november.Zippo);     // L1: foxtrot.Zippo = 8 (4 + 4)
    tango.Vavavoom -= foxtrot.Zippo;    // L1: tango.Vavavoom = -1 (7 - 8)
}

Console.WriteLine("november.Zippo = " + november.Zippo);    // 4
Console.WriteLine("foxtrot.Zippo = " + foxtrot.Zippo);      // 8
Console.WriteLine("tango.Vavavoom = " + tango.Vavavoom);    // -1

class Abracadabra
{
    public int Vavavoom;

    public bool Lala(int floq)
    {
        if (floq < Vavavoom)
        {
            Vavavoom += floq;
            return true;
        }
        return false;
    }
}

class Pizzaz
{
    public int Zippo;

    public void Bamboo(int eek)
    {
        Zippo += eek;
    }
}
Pizzaz foxtrot = new Pizzaz() { Zippo = 2 };
foxtrot.Bamboo(foxtrot.Zippo);

Pizzaz november = new Pizzaz() { Zippo = 3 };
Abracadabra tango = new Abracadabra() { Vavavoom = 4 };

while (tango.Lala(november.Zippo))
{
    november.Zippo *= -1;
    november.Bamboo(tango.Vavavoom);
    foxtrot.Bamboo(november.Zippo);
    tango.Vavavoom -= foxtrot.Zippo;
}

Console.WriteLine("november.Zippo = " + november.Zippo);
Console.WriteLine("foxtrot.Zippo = " + foxtrot.Zippo);
Console.WriteLine("tango.Vavavoom = " + tango.Vavavoom);

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
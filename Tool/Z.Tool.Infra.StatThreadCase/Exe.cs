namespace Z.Tool.StatThreadCaseSourceGen;




class Exe : Any
{
    static int Main()
    {
        Gen gen;

        gen = new Gen();

        gen.Init();



        int o;

        o = gen.Execute();


        return o;
    }
}
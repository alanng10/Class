namespace Z.Tool.Infra.StatStreamKind;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "StreamKind";



        this.ScopeName = "";



        this.ScopeSeparator = "";
        



        this.ItemListFileName = "ToolData/ItemListStreamKind.txt";


        this.MethodFileName = "ToolData/MethodStreamKind.txt";




        int o;
        
        o = base.Execute();


        return o;
    }




    protected override string GetItemMethod(string method, Iter iter, int index)
    {
        return base.GetItemMethod(method, iter, index + 1);
    }




    protected override string GetShareVarList()
    {
        return "";
    }
}
namespace Z.Tool.System.DrawCompList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Namespace = "System.Draw";
        this.ClassName = "CompList";
        this.BaseClassName = "Any";
        this.AnyClassName = "Any";
        this.ItemClassName = "Comp";
        this.ArrayClassName = "Array";
        this.Export = true;
        this.StatItemClassName = "Comp";
        this.ItemListFileName = this.GetStatItemListFileName();
        return true;
    }
}
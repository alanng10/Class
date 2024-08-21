namespace Class.Console;

public class ImportGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.StorageInfra = StorageInfra.This;

        this.InitSourceTemplate();
        return true;
    }

    public virtual Table ClassImportName { get; set; }
    public virtual string Source { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual string SourceTemplate { get; set; }

    protected virtual bool InitSourceTemplate()
    {
        string k;
        k = this.InfraInfra.PathCombine;

        this.SourceTemplate = this.StorageInfra.TextReadAny("Class.Console.data" + k + "Import.txt", true);
        return true;
    }

    public virtual bool Execute()
    {
        StringJoin k;
        k = new StringJoin();
        k.Init();

        Iter iter;
        iter = this.ClassImportName.IterCreate();
        this.ClassImportName.IterSet(iter);
        while (iter.Next())
        {
            ClassClass c;
            c = (ClassClass)iter.Index;

            string name;
            name = (string)iter.Value;

            string moduleName;
            moduleName = c.Module.Ref.Name;

            string ka;
            ka = this.Namespace(moduleName);

            this.Append(k, "global using ");
            this.Append(k, "_");
            this.Append(k, name);
            this.Append(k, " = ");
            this.Append(k, ka);
            this.Append(k, ".");
            this.Append(k, c.Name);
            this.Append(k, ";");
            this.Append(k, "\n");
        }

        string kk;
        kk = k.Rest();

        string o;
        o = this.SourceTemplate;
        
        o = o.Replace("#Import#", kk);

        this.Source = o;
        return true;
    }

    protected virtual string Namespace(string moduleName)
    {
        string ka;
        ka = "System.";
        if (moduleName.StartsWith(ka))
        {
            string kaa;
            kaa = moduleName.Substring(ka.Length);

            string kab;
            kab = "Avalon." + kaa;
            return kab;   
        }

        if (moduleName.StartsWith("Class."))
        {
            return moduleName;
        }

        string kb;
        kb = "C.";

        string a;
        a = kb + moduleName;
        return a;
    }

    protected virtual bool Append(StringJoin h, string text)
    {
        this.InfraInfra.StringJoinString(h, text);
        return true;
    }
}
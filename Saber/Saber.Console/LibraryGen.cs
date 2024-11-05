namespace Saber.Console;

public class LibraryGen : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;
        this.StorageComp = StorageComp.This;

        this.ClassBaseGen = this.CreateClassBaseGen();

        this.ClassCompGen = this.CreateClassCompGen();

        this.ClassGen = this.CreateClassGen();

        this.StringValueTraverse = this.CreateStringValueTraverse();

        this.ModuleGen = this.CreateModuleGen();

        this.ProjectGen = this.CreateProjectGen();

        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);

        this.SSystemDotInfra = this.S("System.Infra");
        this.SIntern = this.S("Intern");
        this.SExtern = this.S("Extern");
        this.SC = this.S("c");
        this.SPro = this.S("pro");
        this.SModule = this.S("Module");
        return true;
    }

    public virtual ClassModule Module { get; set; }
    public virtual String ModuleRefString { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ImportClass { get; set; }
    public virtual SystemClass SystemClass { get; set; }
    public virtual long Status { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual ClassBaseGen ClassBaseGen { get; set; }
    protected virtual ClassCompGen ClassCompGen { get; set; }
    protected virtual ClassGen ClassGen { get; set; }
    protected virtual StringValueTraverse StringValueTraverse { get; set; }
    protected virtual ModuleGen ModuleGen { get; set; }
    protected virtual ProjectGen ProjectGen { get; set; }
    protected virtual Array ClassBaseArray { get; set; }
    protected virtual Array ClassCompArray { get; set; }
    protected virtual String ModuleProjectText { get; set; }
    protected virtual String GenModuleFoldPath { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual String SSystemDotInfra { get; set; }
    protected virtual String SIntern { get; set; }
    protected virtual String SExtern { get; set; }
    protected virtual String SC { get; set; }
    protected virtual String SPro { get; set; }
    protected virtual String SModule { get; set; }

    protected virtual ClassBaseGen CreateClassBaseGen()
    {
        ClassBaseGen a;
        a = new ClassBaseGen();
        a.Init();
        return a;
    }

    protected virtual ClassCompGen CreateClassCompGen()
    {
        ClassCompGen a;
        a = new ClassCompGen();
        a.Init();
        return a;
    }

    protected virtual ClassGen CreateClassGen()
    {
        ClassGen a;
        a = new ClassGen();
        a.Init();
        return a;
    }

    protected virtual StringValueTraverse CreateStringValueTraverse()
    {
        StringValueTraverse a;
        a = new StringValueTraverse();
        a.Init();
        return a;
    }

    protected virtual ModuleGen CreateModuleGen()
    {
        ModuleGen a;
        a = new ModuleGen();
        a.Init();
        return a;
    }

    protected virtual ProjectGen CreateProjectGen()
    {
        ProjectGen a;
        a = new ProjectGen();
        a.Init();
        return a;
    }

    public virtual bool Load()
    {
        this.ModuleProjectText = this.StorageInfra.TextRead(this.S("Saber.Console.data/ModuleProject.txt"));

        if (this.ModuleProjectText == null)
        {
            return false;
        }

        return true;
    }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.GenModuleFoldPath = null;
        this.ModuleRef.Name = null;

        return b;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;

        String genFoldPath;
        genFoldPath = this.S("Saber.Console.Data/Gen");

        String combine;
        combine = this.TextInfra.PathCombine;

        this.GenModuleFoldPath = this.AddClear().Add(genFoldPath).Add(combine).Add(this.ModuleRefString).AddResult();

        this.ExecuteBase();

        this.ExecuteClassComp();

        bool ba;
        ba = this.ExecuteGenClassSource();
        if (!ba)
        {
            return false;
        }

        bool bb;
        bb = this.ExecuteGenModuleSource();
        if (!bb)
        {
            return false;
        }

        bool bc;
        bc = this.ExecuteGenProject();
        if (!bc)
        {
            return false;
        }

        bool bd;
        bd = this.ExecuteGenMake();
        if (!bd)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteBase()
    {
        long count;
        count = this.Module.Class.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        this.ClassBaseArray = array;

        Iter iter;
        iter = this.Module.Class.IterCreate();

        this.Module.Class.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = iter.Value as ClassClass;

            this.ClassBaseGen.Class = varClass;

            this.ClassBaseGen.Execute();

            Array a;
            a = this.ClassBaseGen.Result;

            this.ClassBaseGen.Result = null;
            this.ClassBaseGen.Class = null;

            array.SetAt(i, a);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteClassComp()
    {
        long count;
        count = this.Module.Class.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        this.ClassCompArray = array;

        Iter iter;
        iter = this.Module.Class.IterCreate();

        this.Module.Class.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = iter.Value as ClassClass;
        
            Array baseArray;
            baseArray = this.ClassBaseArray.GetAt(i) as Array;

            this.ClassCompGen.Class = varClass;
            this.ClassCompGen.BaseArray = baseArray;

            this.ClassCompGen.Execute();

            ClassComp a;
            a = this.ClassCompGen.Result;

            this.ClassCompGen.Result = null;
            this.ClassCompGen.BaseArray = null;
            this.ClassCompGen.Class = null;

            array.SetAt(i, a);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteGenClassSource()
    {
        ClassModule systemInfraModule;
        systemInfraModule = null;

        bool b;
        b = this.TextSame(this.TA(this.Module.Ref.Name), this.TB(this.SSystemDotInfra));

        if (b)
        {
            systemInfraModule = this.Module;
        }

        if (!b)
        {
            this.ModuleRef.Name = this.SSystemDotInfra;
            this.ModuleRef.Ver = 0;

            systemInfraModule = (ClassModule)this.ModuleTable.Get(this.ModuleRef);
        }

        ClassClass internClass;
        ClassClass externClass;
        internClass = (ClassClass)systemInfraModule.Class.Get(this.SIntern);
        externClass = (ClassClass)systemInfraModule.Class.Get(this.SExtern);

        this.ClassGen.InternClass = internClass;
        this.ClassGen.ExternClass = externClass;
        this.ClassGen.System = this.SystemClass;
        this.ClassGen.ImportClass = this.ImportClass;

        this.StorageComp.FoldDelete(this.GenModuleFoldPath);

        bool baa;
        baa = this.StorageComp.FoldCreate(this.GenModuleFoldPath);

        if (!baa)
        {
            this.Status = 10;
            return false;
        }

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);

        long count;
        count = this.Module.Class.Count;
        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            NodeClass nodeClass;
            nodeClass = varClass.Any as NodeClass;

            this.StringValueTraverse.Class = nodeClass;

            this.StringValueTraverse.Execute();

            Array stringValueArray;
            stringValueArray = this.StringValueTraverse.Array;

            this.StringValueTraverse.Array = null;
            this.StringValueTraverse.Class = null;

            this.ClassGen.Class = varClass;
            this.ClassGen.StringValue = stringValueArray;

            this.ClassGen.Execute();

            String k;
            k = this.ClassGen.Result;

            this.ClassGen.Result = null;
            this.ClassGen.StringValue = null;
            this.ClassGen.Class = null;

            String ka;
            ka = this.StringIntHex(i);

            String combine;
            combine = this.TextInfra.PathCombine;

            String fileName;
            fileName = this.AddClear().AddChar('C').Add(ka).Add(this.ClassInfra.Dot).Add(this.SC).AddResult();

            String filePath;
            filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(combine).Add(fileName).AddResult();

            bool bab;
            bab = this.StorageInfra.TextWrite(filePath, k);

            if (!bab)
            {
                this.Status = 20;
                return false;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteGenModuleSource()
    {
        this.ModuleGen.Gen = this.ClassGen;
        this.ModuleGen.Module = this.Module;

        this.ModuleGen.Execute();
        String k;
        k = this.ModuleGen.Result;

        this.ModuleGen.Result = null;
        this.ModuleGen.Module = null;
        this.ModuleGen.Gen = null;

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.Dot).Add(this.SC).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, k);

        if (!b)
        {
            this.Status = 30;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteGenProject()
    {
        Array moduleRefStringArray;
        moduleRefStringArray = this.ModuleRefStringArray();

        this.ProjectGen.Gen = this.ClassGen;
        this.ProjectGen.ModuleRefString = moduleRefStringArray;

        this.ProjectGen.Execute();

        String import;
        import = this.ProjectGen.Result;

        this.ProjectGen.Result = null;
        this.ProjectGen.ModuleRefString = null;
        this.ProjectGen.Gen = null;

        Text k;
        k = this.TA(this.ModuleProjectText);
        k = this.Place(k, "#Import#", import);

        String ka;
        ka = this.StringCreate(k);

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.Dot).Add(this.SPro).AddResult();

        String filePath;
        filePath = this.AddClear().Add(this.GenModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, ka);

        if (!b)
        {
            this.Status = 40;
            return false;
        }

        return true;
    }

    protected virtual Array ModuleRefStringArray()
    {
        long count;
        count = this.ModuleTable.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = this.ModuleTable.IterCreate();
        this.ModuleTable.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ModuleRef k;
            k = (ModuleRef)iter.Index;

            String verString;
            verString = this.ClassInfra.VerString(k.Ver);

            String a;
            a = this.ClassInfra.ModuleRefString(k.Name, verString);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    protected virtual bool ExecuteGenMake()
    {
        List list;
        list = new List();
        list.Init();
        list.Add(this.S("/c"));
        list.Add(this.AddClear().AddS("Make.cmd ").Add(this.ModuleRefString).AddResult());

        Program program;
        program = new Program();
        program.Init();
        program.Name = this.S("cmd.exe");
        program.Argue = list;
        program.WorkFold = this.S("Saber.Console.data");
        program.Environ = null;

        program.Execute();

        program.Wait();

        long k;
        k = program.Status;

        program.Final();

        if (!(k == 0))
        {
            this.Status = 50;
            return false;
        }

        return true;
    }
}
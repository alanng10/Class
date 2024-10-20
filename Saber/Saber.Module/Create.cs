namespace Saber.Module;

public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();

        this.ErrorKind = this.CreateErrorKindList();
        this.Count = this.CreateCountList();

        this.SystemClass = new SystemClass();
        this.SystemClass.Init();

        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);

        this.InitNullClass();

        this.SSystemInfra = this.S("System.Infra");
        return true;
    }

    public virtual Array Source { get; set; }
    public virtual Array RootNode { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ClassTable { get; set; }
    public virtual Result Result { get; set; }
    public virtual SystemClass SystemClass { get; set; }
    public virtual ErrorKindList ErrorKind { get; set; }
    public virtual CountList Count { get; set; }
    public virtual ClassClass NullClass { get; set; }
    protected virtual List ErrorList { get; set; }
    protected virtual Table BaseTable { get; set; }
    protected virtual Table RangeTable { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual bool SystemInfraModule { get; set; }
    protected virtual String SSystemInfra { get; set; }

    protected virtual bool InitNullClass()
    {
        ClassClass a;
        a = new ClassClass();
        a.Init();
        a.Name = this.S("_");
        this.NullClass = a;
        return true;
    }

    public override bool Execute()
    {
        this.Result = new Result();
        this.Result.Init();

        this.ErrorList = new List();
        this.ErrorList.Init();

        this.SystemInfraModule = this.IsSystemInfraModule();
        
        this.ExecuteInit();
        this.ExecuteClass();
        this.ExecuteBase();
        this.ExecuteComp();
        this.ExecuteExport();
        this.ExecuteEntry();
        this.ExecuteState();

        this.Result.Module = this.Module;
        this.Result.Error = this.ListInfra.ArrayCreateList(this.ErrorList);
        this.ErrorList = null;
        return true;
    }

    protected virtual bool SystemClassSet()
    {
        ClassModule d;
        d = null;

        if (this.SystemInfraModule)
        {
            d = this.Module;
        }
        if (!this.SystemInfraModule)
        {
            d = this.ModuleGet(this.SSystemInfra);
        }

        this.SystemClass.Any = this.ModuleClassGet(d, this.S("Any"));
        this.SystemClass.Bool = this.ModuleClassGet(d, this.S("Bool"));
        this.SystemClass.Int = this.ModuleClassGet(d, this.S("Int"));
        this.SystemClass.String = this.ModuleClassGet(d, this.S("String"));
        return true;
    }

    protected virtual ClassModule ModuleGet(String moduleName)
    {
        this.ModuleRef.Name = moduleName;
        ClassModule a;
        a = (ClassModule)this.ModuleTable.Get(this.ModuleRef);
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, String className)
    {
        return (ClassClass)module.Class.Get(className);
    }

    protected virtual bool IsSystemInfraModule()
    {
        return this.TextSame(this.TA(this.Module.Ref.Name), this.TB(this.SSystemInfra));
    }

    protected virtual ErrorKindList CreateErrorKindList()
    {
        return ErrorKindList.This;
    }

    protected virtual CountList CreateCountList()
    {
        return CountList.This;
    }

    public virtual Info CreateInfo()
    {
        Info a;
        a = new Info();
        a.Init();
        return a;
    }

    protected virtual bool ExecuteInit()
    {
        Traverse traverse;
        traverse = this.InitTraverse();
        this.ExecuteRootTraverse(traverse);
        return true;
    }

    protected virtual Traverse InitTraverse()
    {
        InitTraverse a;
        a = new InitTraverse();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteClass()
    {
        Traverse traverse;
        traverse = this.ClassTraverse();
        this.ExecuteRootTraverse(traverse);

        this.SystemClassSet();
        return true;
    }

    protected virtual Traverse ClassTraverse()
    {
        ClassTraverse a;
        a = new ClassTraverse();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteBase()
    {
        this.SetBaseTable();

        this.AddBaseList();

        this.BaseTable = null;
        return true;
    }

    protected virtual bool SetBaseTable()
    {
        this.BaseTable = this.ClassInfra.TableCreateRefLess();

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Value;
            this.BaseMapAdd(varClass);
        }
        return true;
    }

    protected virtual bool BaseMapAdd(ClassClass varClass)
    {
        NodeClass nodeClass;
        nodeClass = (NodeClass)varClass.Any;

        ClassName nodeBase;
        nodeBase = nodeClass.Base;

        String baseName;
        baseName = null;
        if (!(nodeBase == null))
        {
            baseName = nodeBase.Value;
        }

        ClassClass varBase;
        varBase = null;
        if (!(baseName == null))
        {
            varBase = this.Class(baseName);
        }

        bool b;
        b = false;

        bool ba;
        ba = (varBase == null);
        if (ba)
        {
            this.Error(this.ErrorKind.BaseUndefined, nodeClass, this.SourceGet(varClass.Index));
            b = true;
        }

        if (!ba)
        {
            if (!this.ValidBase(varBase))
            {
                this.Error(this.ErrorKind.BaseUndefined, nodeClass, this.SourceGet(varClass.Index));
                b = true;
            }
        }

        ClassClass a;
        a = varBase;

        if (b)
        {
            a = this.SystemClass.Any;
        }

        this.ListInfra.TableAdd(this.BaseTable, varClass, a);
        return true;
    }

    protected virtual bool ValidBase(ClassClass varClass)
    {
        SystemClass d;
        d = this.SystemClass;

        if (varClass == d.Bool | varClass == d.Int | varClass == d.String)
        {
            return false;
        }
        return true;
    }

    protected virtual bool AddBaseList()
    {
        ClassClass anyClass;
        anyClass = this.SystemClass.Any;

        Iter iter;
        iter = this.BaseTable.IterCreate();
        this.BaseTable.IterSet(iter);

        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Index;

            bool b;
            b = false;

            bool ba;
            ba = (varClass == anyClass);

            if (ba)
            {
                b = true;
            }

            if (!ba)
            {
                b = this.ValidClassDependency(varClass);
            }

            ClassClass a;
            a = null;

            if (!b)
            {
                NodeClass nodeClass;
                nodeClass = (NodeClass)varClass.Any;

                this.Error(this.ErrorKind.BaseUndefined, nodeClass, this.SourceGet(varClass.Index));

                a = anyClass;
            }
            if (b)
            {
                a = (ClassClass)iter.Value;
            }
            varClass.Base = a;
        }
        return true;
    }

    protected virtual bool ValidClassDependency(ClassClass varClass)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ClassModule module;
        module = this.Module;

        Table baseTable;
        baseTable = this.BaseTable;

        Table table;
        table = this.ClassInfra.TableCreateRefLess();

        listInfra.TableAdd(table, varClass, varClass);

        ClassClass a;
        a = (ClassClass)baseTable.Get(varClass);

        while (a.Module == module)
        {
            if (table.Valid(a))
            {
                return false;
            }

            listInfra.TableAdd(table, a, a);

            a = (ClassClass)baseTable.Get(a);
        }
        return true;
    }

    protected virtual bool ExecuteComp()
    {
        Traverse traverse;
        traverse = this.CompTraverse();
        this.ExecuteClassTraverse(traverse);

        this.SetClassRange();
        return true;
    }

    protected virtual Traverse CompTraverse()
    {
        CompTraverse a;
        a = new CompTraverse();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual bool SetClassRange()
    {
        Table table;
        table = this.Module.Class;

        this.RangeTable = this.ClassInfra.TableCreateRefLess();

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            ClassClass a;
            a = (ClassClass)iter.Value;

            this.SetClassRangeClass(a);
        }

        this.RangeTable = null;
        return true;
    }

    protected virtual bool SetClassRangeClass(ClassClass varClass)
    {
        Table k;
        k = this.RangeTable;

        if (k.Valid(varClass))
        {
            return true;
        }

        if (!(varClass.Module == this.Module))
        {
            return true;
        }

        ClassClass baseClass;
        baseClass = varClass.Base;

        this.SetClassRangeClass(baseClass);

        this.SetClassRangeOne(varClass.FieldRange, baseClass.FieldRange, varClass.Field.Count);

        this.SetClassRangeOne(varClass.MaideRange, baseClass.MaideRange, varClass.Maide.Count);

        this.ListInfra.TableAdd(k, varClass, varClass);

        return true;
    }

    protected virtual bool SetClassRangeOne(Range ka, Range kb, long count)
    {
        ka.Index = kb.Index + kb.Count;
        ka.Count = count;
        return true;
    }

    public virtual bool VirtualField(Field a)
    {
        ClassClass varClass;
        varClass = a.Parent;

        object ka;
        ka = this.CompDefined(varClass.Base, a.Name);

        if (ka == null)
        {
            return true;
        }

        if (ka is Maide)
        {
            return false;
        }

        Field k;
        k = (Field)ka;

        bool b;
        b = false;

        if (!b)
        {
            if (!(a.Class == k.Class))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(a.Count == k.Count))
            {
                b = true;
            }
        }

        if (b)
        {
            return false;
        }

        Field h;
        h = k;
        if (!(k.Virtual == null))
        {
            h = k.Virtual;
        }

        a.Virtual = h;
        return true;
    }

    public virtual bool VirtualMaide(Maide a)
    {
        ClassClass varClass;
        varClass = a.Parent;

        object ka;
        ka = this.CompDefined(varClass.Base, a.Name);

        if (ka == null)
        {
            return true;
        }

        if (ka is Field)
        {
            return false;
        }

        Maide k;
        k = (Maide)ka;

        bool b;
        b = false;

        if (!b)
        {
            if (!(a.Class == k.Class))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!(a.Count == k.Count))
            {
                b = true;
            }
        }

        if (!b)
        {
            if (!this.VarSameClass(a.Param, k.Param))
            {
                b = true;
            }
        }

        if (b)
        {
            return false;
        }

        Maide h;
        h = k;
        if (!(k.Virtual == null))
        {
            h = k.Virtual;
        }

        a.Virtual = h;
        return true;
    }

    protected virtual bool VarSameClass(Table varA, Table varB)
    {
        if (!(varA.Count == varB.Count))
        {
            return false;
        }

        Iter iterA;
        iterA = varA.IterCreate();
        varA.IterSet(iterA);

        Iter iterB;
        iterB = varB.IterCreate();
        varB.IterSet(iterB);

        long count;
        count = varA.Count;
        long i;
        i = 0;
        while (i < count)
        {
            iterA.Next();
            iterB.Next();

            Var aa;
            Var ab;
            aa = (Var)iterA.Value;
            ab = (Var)iterB.Value;

            bool b;
            b = (aa.Class == ab.Class);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual bool ExecuteState()
    {
        Traverse traverse;
        traverse = this.StateTraverse();
        this.ExecuteClassTraverse(traverse);
        return true;
    }

    protected virtual Traverse StateTraverse()
    {
        StateTraverse a;
        a = new StateTraverse();
        a.Create = this;
        a.Init();
        return a;
    }

    protected virtual bool ExecuteExport()
    {
        List list;
        list = new List();
        list.Init();

        ClassModule module;
        module = this.Module;
        Table table;
        table = module.Export;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            String name;
            name = (String)iter.Index;

            ClassClass varClass;
            varClass = this.ModuleClassGet(module, name);

            bool b;
            b = (varClass == null);
            if (b)
            {
                this.ErrorModule(this.ErrorKind.ExportUndefined, name);
            }
            if (!b)
            {
                this.CheckExport(varClass);

                list.Add(varClass);
            }
        }

        iter = list.IterCreate();
        list.IterSet(iter);
        while (iter.Next())
        {
            ClassClass d;
            d = (ClassClass)iter.Value;
            table.Set(d.Name, d);
        }
        return true;
    }

    protected virtual bool CheckExport(ClassClass varClass)
    {
        Source source;
        source = this.SourceGet(varClass.Index);

        if (!this.CheckIsExport(varClass.Base))
        {
            NodeClass aa;
            aa = (NodeClass)varClass.Any;
            this.Error(this.ErrorKind.ClassUnexportable, aa, source);
        }

        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);
        while (iter.Next())
        {
            Field field;
            field = (Field)iter.Value;
            if (!this.CheckIsExport(field.Class))
            {
                NodeField ab;
                ab = (NodeField)field.Any;
                this.Error(this.ErrorKind.FieldUnexportable, ab, source);
            }
        }

        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);
        while (iter.Next())
        {
            Maide maide;
            maide = (Maide)iter.Value;
            bool b;
            b = false;
            if (!this.CheckIsExport(maide.Class))
            {
                b = true;
            }
            if (!b)
            {
                Iter iterA;
                iterA = maide.Param.IterCreate();
                maide.Param.IterSet(iterA);
                while (!b & iterA.Next())
                {
                    Var varVar;
                    varVar = (Var)iterA.Value;
                    if (!this.CheckIsExport(varVar.Class))
                    {
                        b = true;
                    }
                }
            }
            if (b)
            {
                NodeMaide ac;
                ac = (NodeMaide)maide.Any;
                this.Error(this.ErrorKind.MaideUnexportable, ac, source);
            }
        }
        return true;
    }

    protected virtual bool CheckIsExport(ClassClass varClass)
    {
        ClassModule module;
        module = this.Module;

        if (!(varClass.Module == module))
        {
            return true;
        }

        bool a;
        a = module.Export.Valid(varClass.Name);
        return a;
    }

    protected virtual bool ExecuteEntry()
    {
        ClassModule module;
        module = this.Module;

        String entry;
        entry = module.Entry;
        if (entry == null)
        {
            return true;
        }

        ClassClass varClass;
        varClass = this.ModuleClassGet(module, entry);
        if (varClass == null)
        {
            this.ErrorModule(this.ErrorKind.EntryUndefined, null);
            return true;
        }

        ClassModule h;
        h = this.ModuleGet(this.S("System.Entry"));
        ClassClass entryClass;
        entryClass = this.ModuleClassGet(h, this.S("Entry"));

        bool b;
        b = false;
        if (!b)
        {
            if (!(this.ClassInfra.ValidClass(varClass, entryClass, this.SystemClass.Any, this.NullClass)))
            {
                b = true;
            }
        }
        if (b)
        {
            NodeClass aa;
            aa = (NodeClass)varClass.Any;
            this.Error(this.ErrorKind.EntryUnachievable, aa, this.SourceGet(varClass.Index));
        }
        return true;
    }

    protected virtual bool ExecuteRootTraverse(Traverse traverse)
    {
        long count;
        count = this.Source.Count;
        long i;
        i = 0;
        while (i < count)
        {
            NodeNode root;
            root = (NodeNode)this.RootNode.GetAt(i);

            Source source;
            source = this.SourceGet(i);

            if (!(root == null))
            {
                NodeClass nodeClass;
                nodeClass = (NodeClass)root;
                this.ExecuteTraverse(traverse, nodeClass, source);
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteClassTraverse(Traverse traverse)
    {
        Table table;
        table = this.Module.Class;
        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        while (iter.Next())
        {
            ClassClass varClass;
            varClass = (ClassClass)iter.Value;
            Source source;
            source = this.SourceGet(varClass.Index);
            NodeClass nodeClass;
            nodeClass = (NodeClass)varClass.Any;

            this.ExecuteTraverse(traverse, nodeClass, source);
        }
        return true;
    }

    protected virtual bool ExecuteTraverse(Traverse traverse, NodeClass nodeClass, Source source)
    {
        traverse.Source = source;
        traverse.ExecuteClass(nodeClass);
        return true;
    }

    public virtual ClassClass Class(String name)
    {
        ClassClass a;
        a = (ClassClass)this.ClassTable.Get(name);
        return a;
    }

    public virtual bool MemberNameDefined(ClassClass varClass, String name)
    {
        bool ba;
        ba = varClass.Field.Valid(name);
        bool bb;
        bb = varClass.Maide.Valid(name);

        bool a;
        a = ba | bb;
        return a;
    }

    public virtual object CompDefined(ClassClass varClass, String name)
    {
        return this.ClassInfra.CompDefined(varClass, name, this.Module, this.SystemClass.Any);
    }

    protected virtual Source SourceGet(long index)
    {
        return (Source)this.Source.GetAt(index);
    }

    public virtual bool Error(ErrorKind kind, NodeNode node, Source source)
    {
        Error a;
        a = new Error();
        a.Init();
        a.Stage = this.Stage;
        a.Kind = kind;
        a.Range = node.Range;
        a.Source = source;

        this.ErrorList.Add(a);
        return true;
    }

    public virtual bool ErrorModule(ErrorKind kind, String name)
    {
        Error a;
        a = new Error();
        a.Init();
        a.Stage = this.Stage;
        a.Kind = kind;
        a.Name = name;

        this.ErrorList.Add(a);
        return true;
    }
}
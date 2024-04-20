namespace Class.Console;

public class ModuleCreate : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.CountList = CountList.This;
        this.ModuleRefA = this.ClassInfra.ModuleRefCreate(null, 0);
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }
    public virtual ModuleRef ModuleRef { get; set; }
    public virtual ClassModule Module { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountList CountList { get; set; }
    protected virtual BinaryBinary Binary { get; set; }
    protected virtual Array ClassArray { get; set; }
    protected virtual Array ImportArray { get; set; }
    protected virtual bool HasSystemClass { get; set; }
    protected virtual Data ClassFlagData { get; set; }
    protected virtual ClassClass AnyClass { get; set; }
    protected virtual ModuleRef ModuleRefA { get; set; }

    public virtual bool Execute()
    {
        ModuleRef o;
        o = this.ModuleRef;
        if (this.ModuleTable.Contain(o))
        {
            return false;
        }

        ClassModule a;
        a = new ClassModule();
        a.Init();
        a.Ref = this.ClassInfra.ModuleRefCreate(o.Name, o.Version);

        this.Module = a;

        BinaryBinary binary;
        binary = (BinaryBinary)this.BinaryTable.Get(this.Module.Ref);
        this.Binary = binary;

        string moduleName;
        moduleName = this.Module.Ref.Name;
        this.HasSystemClass = moduleName.StartsWith("System.") | moduleName.StartsWith("Class.");

        this.SetClassList();

        this.SetImportList();

        this.SetBaseList();

        this.SetPartList();

        this.SetVirtualList();

        this.Binary = null;
        this.ClassArray = null;
        this.ImportArray = null;

        return true;
    }

    protected virtual bool SetClassList()
    {
        Table classTable;
        classTable = this.ClassInfra.TableCreateStringCompare();
        
        this.Module.Class = classTable;

        Array array;
        array = this.Binary.Class;
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryClass o;
            o = (BinaryClass)array.Get(i);

            string name;
            name = o.Name;

            ClassClass a;
            a = new ClassClass();
            a.Init();
            a.Index = classTable.Count;
            a.Name = name;
            a.Module = this.Module;

            this.ListInfra.TableAdd(classTable, a.Name, a); 

            i = i + 1;
        }

        Array classArray;
        classArray = this.ListInfra.ArrayCreate(classTable.Count);

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);

        count = classArray.Count;
        i = 0;
        while (i < count)
        {
            iter.Next();
            ClassClass oa;
            oa = (ClassClass)iter.Value;

            classArray.Set(i, oa);
            i = i + 1;
        }

        this.ClassArray = classArray;
        return true;
    }
    
    protected virtual bool SetImportList()
    {
        Table importTable;
        importTable = this.ClassInfra.TableCreateModuleRefCompare();

        this.Module.Import = importTable;
        
        int importTotal;
        importTotal = 0;

        Array array;
        array = this.Binary.Import;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryImport o;
            o = (BinaryImport)array.Get(i);

            ModuleRef moduleRef;
            moduleRef = o.Module;

            if (importTable.Contain(moduleRef))
            {
                global::System.Console.Error.Write("Class.Console:ModuleCreate.SetImportList import module ref duplicate\n");
                global::System.Environment.Exit(120);
            }

            Table ol;
            ol = this.ClassInfra.TableCreateStringCompare();
            this.ListInfra.TableAdd(importTable, moduleRef, ol);
            
            Table classTable;
            classTable = (Table)importTable.Get(moduleRef);

            ClassModule module;
            module = this.ModuleGet(moduleRef);

            BinaryBinary oo;
            oo = (BinaryBinary)this.BinaryTable.Get(moduleRef);

            Array oa;
            oa = o.Class;
            int countA;
            countA = oa.Count;
            int iA;
            iA = 0;
            while (iA < countA)
            {
                BinaryClassIndex oe;
                oe = (BinaryClassIndex)oa.Get(iA);

                BinaryClass of;
                of = (BinaryClass)oo.Class.Get(oe.Value);

                string className;
                className = of.Name;

                if (classTable.Contain(className))
                {
                    global::System.Console.Error.Write("Class.Console:ModuleCreate.SetImportList import class name duplicate\n");
                    global::System.Environment.Exit(121);
                }

                ClassClass varClass;
                varClass = this.ModuleClassGet(module, className);

                this.ListInfra.TableAdd(classTable, className, varClass);

                iA = iA + 1;
            }

            importTotal = importTotal + countA;

            i = i + 1;
        }

        Array importArray;
        importArray = this.ListInfra.ArrayCreate(importTotal);

        int oi;
        oi = 0;
        Iter iter;
        iter = importTable.IterCreate();
        importTable.IterSet(iter);
        while (iter.Next())
        {
            Table ooo;
            ooo = (Table)iter.Value;

            Iter iterA;
            iterA = ooo.IterCreate();
            ooo.IterSet(iterA);
            while(iterA.Next())
            {
                ClassClass ooa;
                ooa = (ClassClass)iterA.Value;

                importArray.Set(oi, ooa);

                oi = oi + 1;
            }
        }

        this.ImportArray = importArray;
        return true;
    }

    protected virtual bool SetBaseList()
    {
        Array array;
        array = this.Binary.Base;

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);
        
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            BinaryClassIndex a;
            a = (BinaryClassIndex)array.Get(i);

            ClassClass baseClass;
            baseClass = this.ClassGetIndex(a.Value);

            varClass.Base = baseClass;            

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartList()
    {
        Array array;
        array = this.Binary.Part;

        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            BinaryPart a;
            a = (BinaryPart)array.Get(i);

            this.SetPart(varClass, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPart(ClassClass varClass, BinaryPart part)
    {
        this.SetPartField(varClass, part.Field);
        this.SetPartMaide(varClass, part.Maide);
        return true;
    }

    protected virtual bool SetPartField(ClassClass varClass, Array binaryField)
    {
        Table fieldTable;
        fieldTable = this.ClassInfra.TableCreateStringCompare();
        varClass.Field = fieldTable;

        int count;
        count = binaryField.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryField ua;
            ua = (BinaryField)binaryField.Get(i);

            Field a;
            a = new Field();
            a.Init();
            a.Index = fieldTable.Count;
            a.Name = ua.Name;
            a.Class = this.ClassGetIndex(ua.Class);
            a.SystemClass = this.SystemClassCreate(ua.SystemClass);
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            this.ListInfra.TableAdd(fieldTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartMaide(ClassClass varClass, Array binaryMaide)
    {
        Table maideTable;
        maideTable = this.ClassInfra.TableCreateStringCompare();
        varClass.Maide = maideTable;

        int count;
        count = binaryMaide.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryMaide ua;
            ua = (BinaryMaide)binaryMaide.Get(i);

            Maide a;
            a = new Maide();
            a.Init();
            a.Index = maideTable.Count;
            a.Name = ua.Name;
            a.Class = this.ClassGetIndex(ua.Class);
            a.SystemClass = this.SystemClassCreate(ua.SystemClass);
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            this.SetPartParam(a, ua.Param);

            this.ListInfra.TableAdd(maideTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartParam(Maide maide, Array binaryVar)
    {
        Table varTable;
        varTable = this.ClassInfra.TableCreateStringCompare();
        maide.Param = varTable;

        int count;
        count = binaryVar.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryVar ua;
            ua = (BinaryVar)binaryVar.Get(i);

            Var a;
            a = new Var();
            a.Init();
            a.Name = ua.Name;
            a.Class = this.ClassGetIndex(ua.Class);
            a.SystemClass = this.SystemClassCreate(ua.SystemClass);
            
            this.ListInfra.TableAdd(varTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetVirtualList()
    {
        this.ModuleRefA.Name = "System.Infra";
        this.AnyClass = this.ClassGet(this.ModuleRefA, "Any");
        
        Array array;
        array = this.ClassArray;

        int count;
        count = array.Count;
        Data data;
        data = new Data();
        data.Count = count;
        data.Init();
        this.ClassFlagData = data;

        int i;
        i = 0;
        while (i < count)
        {
            ClassClass a;
            a = (ClassClass)array.Get(i);
            
            this.SetVirtualClass(a);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool SetVirtualClass(ClassClass varClass)
    {
        int u;
        u = this.ClassFlagData.Get(varClass.Index);

        if (!(u == 0))
        {
            return true;
        }

        if (!(varClass == this.AnyClass))
        {
            if (varClass.Base.Module == this.Module)
            {
                this.SetVirtualClass(varClass.Base);
            }
        }

        this.SetVirtualFieldTable(varClass.Field);



        this.ClassFlagData.Set(varClass.Index, 1);

        return true;
    }

    protected virtual bool SetVirtualFieldTable(Table fieldTable)
    {
        Iter iter;
        iter = fieldTable.IterCreate();
        fieldTable.IterSet(iter);

        while (iter.Next())
        {
            Field a;
            a = (Field)iter.Value;
            this.SetVirtualField(a);
        }
        return true;
    }

    protected virtual bool SetVirtualField(Field field)
    {
        string name;
        name = field.Name;

        ClassClass f;
        f = field.Parent;
        Field v;
        v = null;
        bool b;
        b = false;
        ClassClass a;
        a = f.Base;
        while (!b & !(a == null))
        {
            bool ba;
            ba = a.Field.Contain(name);
            bool bb;
            bb = a.Maide.Contain(name);
            if (bb)
            {
                b = true;
            }
            if (ba)
            {
                Field o;
                o = (Field)a.Field.Get(name);
                if (o.Class == field.Class & o.Count == field.Count)
                {
                    v = o;
                }
                b = true;
            }

            bool bc;
            bc = (a == this.AnyClass);
            if (bc)
            {
                a = null;
            }
            if (!bc)
            {
                a = a.Base;
            }
        }

        Field k;
        k = null;
        if (!(v == null))
        {
            bool be;
            be = !(v.Virtual == null);
            if (be)
            {
                k = v.Virtual;
            }
            if (!be)
            {
                k = v;
            }
        }

        field.Virtual = k;
        return true;
    }

    protected virtual SystemClass SystemClassCreate(int binaryValue)
    {
        if (!this.HasSystemClass)
        {
            return null;
        }

        bool b;
        b = !((binaryValue & 0x80) == 0);

        int e;
        e = binaryValue & 0x7f;

        SystemClass a;
        a = new SystemClass();
        a.Init();
        a.Value = e;
        a.HasNull = b;
        return a;
    }

    protected virtual ClassClass ClassGetIndex(int index)
    {
        Array classArray;
        classArray = this.ClassArray;

        ClassClass a;
        a = null;
        bool b;
        b = (index < classArray.Count);
        if (b)
        {
            a = (ClassClass)classArray.Get(index);
        }
        if (!b)
        {
            int oa;
            oa = index - classArray.Count;
            a = (ClassClass)this.ImportArray.Get(oa);
        }

        if (a == null)
        {
            global::System.Console.Error.Write("Class.Console:ModuleCreate.ClassGetIndex class none, index: " + index + "\n");
            global::System.Environment.Exit(125);
        }
        return a;
    }

    protected virtual ClassModule ModuleGet(ModuleRef moduleRef)
    {
        ClassModule a;
        a = (ClassModule)this.ModuleTable.Get(moduleRef);
        if (a == null)
        {
            global::System.Console.Error.Write("Class.Console:ModuleCreate.ModuleGet module not found, module: " + moduleRef.Name + "\n");
            global::System.Environment.Exit(122);
        }
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, string className)
    {
        ClassClass a;
        a = (ClassClass)module.Class.Get(className);
        if (a == null)
        {
            global::System.Console.Error.Write("Class.Console:ModuleCreate.ModuleClassGet module class not found, class: " + className + ", module: " + module.Ref.Name + "\n");
            global::System.Environment.Exit(123);
        }
        return a;
    }

    protected virtual ClassClass ClassGet(ModuleRef moduleRef, string className)
    {
        ClassModule ae;
        ae = this.ModuleGet(moduleRef);
        ClassClass a;
        a = this.ModuleClassGet(ae, className);
        return a;
    }
}
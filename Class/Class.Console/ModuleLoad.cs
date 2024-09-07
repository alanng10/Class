namespace Class.Console;

public class ModuleLoad : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.CountList = CountList.This;

        this.SSystemDotInfra = this.S("System.Infra");
        this.SAny = this.S("Any");
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }
    public virtual ModuleRef ModuleRef { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual long Status { get; set; }
    public virtual NameCheck NameCheck { get; set; }
    protected virtual CountList CountList { get; set; }
    protected virtual BinaryBinary Binary { get; set; }
    protected virtual Array ClassArray { get; set; }
    protected virtual Array ImportArray { get; set; }
    protected virtual ClassClass AnyClass { get; set; }
    protected virtual String SSystemDotInfra { get; set; }
    protected virtual String SAny { get; set; }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.Binary = null;
        this.ClassArray = null;
        this.ImportArray = null;

        if (!b)
        {
            this.Module = null;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;

        ModuleRef o;
        o = this.ModuleRef;

        if (this.ModuleTable.Valid(o))
        {
            this.Status = 1;
            return false;
        }

        if (!this.NameCheck.IsModuleName(this.TA(o.Name)))
        {
            this.Status = 2;
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

        bool b;
        
        b = this.SetClassList();
        if (!b)
        {
            return false;
        }

        b = this.SetImportList();
        if (!b)
        {
            return false;
        }

        b = this.SetBaseList();
        if (!b)
        {
            return false;
        }

        b = this.SetPartList();
        if (!b)
        {
            return false;
        }

        b = this.SetVirtualList();
        if (!b)
        {
            return false;
        }

        b = this.SetEntry();
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool SetClassList()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table classTable;
        classTable = this.ClassInfra.TableCreateStringLess();
        
        this.Module.Class = classTable;

        Array array;
        array = this.Binary.Class;
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryClass o;
            o = (BinaryClass)array.GetAt(i);

            String name;
            name = o.Name;

            if (!this.CheckName(name))
            {
                this.Status = 10;
                return false;
            }

            if (classTable.Valid(name))
            {
                this.Status = 11;
                return false;
            }

            ClassClass a;
            a = new ClassClass();
            a.Init();
            a.Index = classTable.Count;
            a.Name = name;
            a.Module = this.Module;

            listInfra.TableAdd(classTable, name, a); 

            i = i + 1;
        }

        if (this.TextSame(this.TA(this.Module.Ref.Name), this.TB(this.SSystemDotInfra)))
        {
            ClassClass oo;
            oo = (ClassClass)classTable.Get(this.SAny);
            if (oo == null)
            {
                this.Status = 12;
                return false;
            }
            this.AnyClass = oo;
        }

        Array classArray;
        classArray = listInfra.ArrayCreate(classTable.Count);

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

            classArray.SetAt(i, oa);
            i = i + 1;
        }

        this.ClassArray = classArray;
        return true;
    }
    
    protected virtual bool SetImportList()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Table binaryTable;
        binaryTable = this.BinaryTable;

        Table importTable;
        importTable = classInfra.TableCreateModuleRefLess();

        this.Module.Import = importTable;
        
        long importTotal;
        importTotal = 0;

        Array array;
        array = this.Binary.Import;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryImport o;
            o = (BinaryImport)array.GetAt(i);

            ModuleRef moduleRef;
            moduleRef = o.Module;

            if (importTable.Valid(moduleRef))
            {
                this.Status = 20;
                return false;
            }

            Table classTable;
            classTable = classInfra.TableCreateRefLess();

            listInfra.TableAdd(importTable, moduleRef, classTable);
            
            ClassModule module;
            module = this.ModuleGet(moduleRef);
            if (module == null)
            {
                this.Status = 21;
                return false;
            }

            BinaryBinary oo;
            oo = (BinaryBinary)binaryTable.Get(moduleRef);
            if (oo == null)
            {
                this.Status = 22;
                return false;
            }

            Array oa;
            oa = o.Class;
            long countA;
            countA = oa.Count;
            long iA;
            iA = 0;
            while (iA < countA)
            {
                InfraValue oe;
                oe = (InfraValue)oa.GetAt(iA);

                BinaryClass of;
                of = (BinaryClass)oo.Class.GetAt(oe.Int);
                if (of == null)
                {
                    this.Status = 23;
                    return false;
                }

                String className;
                className = of.Name;

                ClassClass varClass;
                varClass = this.ModuleClassGet(module, className);
                if (varClass == null)
                {
                    this.Status = 24;
                    return false;
                }

                if (classTable.Valid(varClass))
                {
                    this.Status = 25;
                    return false;
                }

                listInfra.TableAdd(classTable, varClass, varClass);

                iA = iA + 1;
            }

            importTotal = importTotal + countA;

            i = i + 1;
        }

        Array importArray;
        importArray = listInfra.ArrayCreate(importTotal);

        long oi;
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

                importArray.SetAt(oi, ooa);

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

        Array classArray;
        classArray = this.ClassArray;

        int count;
        count = array.Count;
        if (!(count == classArray.Count))
        {
            this.Status = 30;
            return false;
        }

        int i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)classArray.GetAt(i);

            InfraValue a;
            a = (InfraValue)array.GetAt(i);

            ClassClass baseClass;
            baseClass = this.ClassGetIndex(a.Mid);

            if (baseClass == null)
            {
                this.Status = 31;
                return false;
            }

            varClass.Base = baseClass;            

            i = i + 1;
        }

        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)classArray.GetAt(i);

            if (!this.CheckBaseDepend(varClass))
            {
                this.Status = 32;
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool CheckBaseDepend(ClassClass varClass)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ClassClass anyClass;
        anyClass = this.AnyClass;

        ClassModule module;
        module = this.Module;

        Table table;
        table = this.ClassInfra.TableCreateRefLess();

        while (!(varClass == null))
        {
            if (!(varClass.Module == module))
            {
                return true;
            }
            
            if (table.Valid(varClass))
            {
                return false;
            }

            listInfra.TableAdd(table, varClass, varClass);

            ClassClass a;
            a = null;
            if (!(varClass == anyClass))
            {
                a = varClass.Base;
            }
            varClass = a;
        }

        return true;
    }

    protected virtual bool SetPartList()
    {
        Array array;
        array = this.Binary.Part;

        Array classArray;
        classArray = this.ClassArray;

        int count;
        count = array.Count;
        if (!(count == classArray.Count))
        {
            this.Status = 40;
            return false;
        }

        int i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)classArray.GetAt(i);

            BinaryPart a;
            a = (BinaryPart)array.GetAt(i);

            bool b;
            b = this.SetPart(varClass, a);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPart(ClassClass varClass, BinaryPart part)
    {
        varClass.FieldRange = this.CreateRange(part.FieldRange);

        varClass.MaideRange = this.CreateRange(part.MaideRange);

        bool b;
        
        b = this.SetPartField(varClass, part.Field);
        if (!b)
        {
            return false;
        }
        b = this.SetPartMaide(varClass, part.Maide);
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool SetPartField(ClassClass varClass, Array binaryField)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table fieldTable;
        fieldTable = this.ClassInfra.TableCreateStringLess();

        varClass.Field = fieldTable;

        int count;
        count = binaryField.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryField ua;
            ua = (BinaryField)binaryField.GetAt(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }

            string name;
            name = ua.Name;
            if (!this.CheckName(name))
            {
                return false;
            }

            if (this.MemberNameDefined(varClass, name))
            {
                return false;
            }

            Field a;
            a = new Field();
            a.Init();
            a.Index = fieldTable.Count;
            a.BinaryIndex = ua.Index;
            a.Name = name;
            a.Class = c;
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            listInfra.TableAdd(fieldTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartMaide(ClassClass varClass, Array binaryMaide)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table maideTable;
        maideTable = this.ClassInfra.TableCreateStringLess();
        
        varClass.Maide = maideTable;

        int count;
        count = binaryMaide.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryMaide ua;
            ua = (BinaryMaide)binaryMaide.GetAt(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }

            string name;
            name = ua.Name;
            if (!this.CheckName(name))
            {
                return false;
            }

            if (this.MemberNameDefined(varClass, name))
            {
                return false;
            }

            Maide a;
            a = new Maide();
            a.Init();
            a.Index = maideTable.Count;
            a.BinaryIndex = ua.Index;
            a.Name = name;
            a.Class = c;
            a.Count = this.CountList.Get(ua.Count);
            a.Parent = varClass;

            bool b;
            b = this.SetPartParam(a, ua.Param);
            if (!b)
            {
                return false;
            }

            listInfra.TableAdd(maideTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetPartParam(Maide varMaide, Array binaryVar)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table varTable;
        varTable = this.ClassInfra.TableCreateStringLess();
        
        varMaide.Param = varTable;

        int count;
        count = binaryVar.Count;
        int i;
        i = 0;
        while (i < count)
        {
            BinaryVar ua;
            ua = (BinaryVar)binaryVar.GetAt(i);

            ClassClass c;
            c = this.ClassGetIndex(ua.Class);
            if (c == null)
            {
                return false;
            }

            string name;
            name = ua.Name;
            if (!this.CheckName(name))
            {
                return false;
            }

            if (varTable.Valid(name))
            {
                return false;
            }
            
            Var a;
            a = new Var();
            a.Init();
            a.Name = name;
            a.Class = c;

            listInfra.TableAdd(varTable, a.Name, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetVirtualList()
    {
        Array array;
        array = this.Binary.Part;

        Array classArray;
        classArray = this.ClassArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ClassClass varClass;
            varClass = (ClassClass)classArray.GetAt(i);

            BinaryPart a;
            a = (BinaryPart)array.GetAt(i);

            bool b;
            b = this.SetVirtual(varClass, a);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetVirtual(ClassClass varClass, BinaryPart part)
    {
        bool b;
        b = this.SetVirtualField(varClass, part.Field);
        if (!b)
        {
            return false;
        }
        b = this.SetVirtualMaide(varClass, part.Maide);
        if (!b)
        {
            return false;
        }
        return true;
    }

    protected virtual bool SetVirtualField(ClassClass varClass, Array binaryField)
    {
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        ClassClass anyClass;
        anyClass = this.AnyClass;

        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);

        while (iter.Next())
        {
            Field a;
            a = (Field)iter.Value;

            Field k;
            k = null;

            object kk;
            kk = classInfra.CompDefined(varClass.Base, a.Name, anyClass);
            if (!(kk == null))
            {
                if (!(kk is Field))
                {
                    return false;
                }

                k = (Field)kk;
            }

            BinaryField ae;
            ae = (BinaryField)binaryField.GetAt(a.Index);

            bool ba;
            ba = (k == null);
            bool bb;
            bb = (ae.Virtual == -1);

            if (!(ba == bb))
            {
                return false;
            }

            if (!ba)
            {
                ClassClass af;
                af = this.ClassGetIndex(ae.Virtual);
                
                if (af == null)
                {
                    return false;
                }

                if (!(af == k.Parent))
                {
                    return false;
                }

                if (!(a.Count == k.Count))
                {
                    return false;
                }

                if (!(a.Class == k.Class))
                {
                    return false;
                }
            }

            a.Virtual = k;
        }
        return true;
    }

    protected virtual bool SetVirtualMaide(ClassClass varClass, Array binaryMaide)
    {
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        ClassClass anyClass;
        anyClass = this.AnyClass;

        Iter iter;
        iter = varClass.Maide.IterCreate();
        varClass.Maide.IterSet(iter);

        while (iter.Next())
        {
            Maide a;
            a = (Maide)iter.Value;

            Maide k;
            k = null;

            object kk;
            kk = classInfra.CompDefined(varClass.Base, a.Name, anyClass);
            if (!(kk == null))
            {
                if (!(kk is Maide))
                {
                    return false;
                }

                k = (Maide)kk;
            }

            BinaryMaide ae;
            ae = (BinaryMaide)binaryMaide.GetAt(a.Index);

            bool ba;
            ba = (k == null);
            bool bb;
            bb = (ae.Virtual == -1);

            if (!(ba == bb))
            {
                return false;
            }

            if (!ba)
            {
                ClassClass af;
                af = this.ClassGetIndex(ae.Virtual);

                if (af == null)
                {
                    return false;
                }

                if (!(af == k.Parent))
                {
                    return false;
                }

                if (!(a.Count == k.Count))
                {
                    return false;
                }

                if (!(a.Class == k.Class))
                {
                    return false;
                }

                if (!this.ValidVirtualMaideParam(a.Param, k.Param))
                {
                    return false;
                }
            }

            a.Virtual = k;
        }
        return true;
    }
    
    protected virtual bool SetEntry()
    {
        String entry;
        entry = null;

        long f;
        f = this.Binary.Entry;
        if (!(f == -1))
        {
            ClassClass a;
            a = (ClassClass)this.ClassArray.GetAt(f);
            if (a == null)
            {
                return false;
            }

            entry = a.Name;
        }

        this.Module.Entry = entry;
        return true;
    }

    protected virtual bool MemberNameDefined(ClassClass varClass, String name)
    {
        return (varClass.Field.Valid(name) | varClass.Maide.Valid(name));
    }

    protected virtual bool ValidVirtualMaideParam(Table param, Table virtualParam)
    {
        long count;
        count = param.Count;

        if (!(count == virtualParam.Count))
        {
            return false;
        }

        Iter iter;
        iter = param.IterCreate();
        param.IterSet(iter);

        Iter iterA;
        iterA = virtualParam.IterCreate();
        virtualParam.IterSet(iterA);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();
            iterA.Next();

            Var varVar;
            varVar = (Var)iter.Value;

            Var varA;
            varA = (Var)iterA.Value;

            if (!(varVar.Class == varA.Class))
            {
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual InfraRange CreateRange(InfraRange range)
    {
        InfraRange a;
        a = new InfraRange();
        a.Init();
        a.Index = range.Index;
        a.Count = range.Count;
        return a;
    }

    protected virtual bool CheckName(String o)
    {
        return this.NameCheck.IsName(this.TA(o));
    }

    protected virtual ClassClass ClassGetIndex(long index)
    {
        Array classArray;
        classArray = this.ClassArray;

        ClassClass a;
        a = null;
        bool b;
        b = (classArray.ValidAt(index));
        if (b)
        {
            a = (ClassClass)classArray.GetAt(index);
        }
        if (!b)
        {
            long oa;
            oa = index - classArray.Count;
            if (!this.ImportArray.ValidAt(oa))
            {
                return null;
            }
            a = (ClassClass)this.ImportArray.GetAt(oa);
        }
        return a;
    }

    protected virtual ClassModule ModuleGet(ModuleRef moduleRef)
    {
        ClassModule a;
        a = (ClassModule)this.ModuleTable.Get(moduleRef);
        return a;
    }

    protected virtual ClassClass ModuleClassGet(ClassModule module, String className)
    {
        ClassClass a;
        a = (ClassClass)module.Class.Get(className);
        return a;
    }

    protected virtual ClassClass ClassGet(ModuleRef moduleRef, String className)
    {
        ClassModule ae;
        ae = this.ModuleGet(moduleRef);
        ClassClass a;
        a = this.ModuleClassGet(ae, className);
        return a;
    }
}
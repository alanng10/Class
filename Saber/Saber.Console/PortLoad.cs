namespace Saber.Console;

public class PortLoad : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;

        this.ErrorKind = ErrorKindList.This;

        this.StoragePathCheck = new StoragePathCheck();
        this.StoragePathCheck.Init();

        this.SystemModuleSingle = this.S("System");
        this.SystemModulePre = this.AddClear().Add(this.SystemModuleSingle).Add(this.ClassInfra.Dot).AddResult();
        this.ClassModuleSingle = this.S("Class");
        this.ClassModulePre = this.AddClear().Add(this.ClassModuleSingle).Add(this.ClassInfra.Dot).AddResult();

        this.SDotRef = this.S(".ref");
        return true;
    }
    public virtual PortPort Port { get; set; }
    public virtual bool SystemModule { get; set; }
    public virtual ClassModule Module { get; set; }
    public virtual long Status { get; set; }
    public virtual Array Error { get; set; }
    public virtual ModuleLoad ModuleLoad { get; set; }
    public virtual BinaryRead BinaryRead { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ImportClass { get; set; }
    public virtual NameCheck NameCheck { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ErrorKindList ErrorKind { get; set; }
    protected virtual StoragePathCheck StoragePathCheck { get; set; }
    protected virtual Array ImportModuleRefArray { get; set; }
    protected virtual Table BinaryTable { get; set; }
    protected virtual Table ImportDependTable { get; set; }
    protected virtual Table BinaryDependTable { get; set; }
    protected virtual List ErrorList { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual String SystemModuleSingle { get; set; }
    protected virtual String SystemModulePre { get; set; }
    protected virtual String ClassModuleSingle { get; set; }
    protected virtual String ClassModulePre { get; set; }
    protected virtual String SDotRef { get; set; }

    public virtual bool Execute()
    {
        bool b;
        b = this.ExecuteAll();

        this.Error = this.ListInfra.ArrayCreateList(this.ErrorList);

        this.ImportModuleRefArray = null;
        this.ImportDependTable = null;
        this.BinaryDependTable = null;
        this.ModuleLoad.BinaryTable = null;
        this.ModuleLoad.ModuleTable = null;
        this.ErrorList = null;
        this.ModuleRef = null;
        return b;
    }

    protected virtual bool ExecuteAll()
    {
        this.Status = 0;

        PortPort port;
        port = this.Port;

        this.ErrorList = new List();
        this.ErrorList.Init();

        bool b;

        b = this.CheckModuleRef(port.Module);
        if (!b)
        {
            return false;
        }

        b = this.CheckImportArrayModuleRef(port.Import);
        if (!b)
        {
            return false;
        }

        b = this.SetModuleRef();
        if (!b)
        {
            return false;
        }

        b = this.SetImportModuleRef();
        if (!b)
        {
            return false;
        }

        b = this.CheckImportUnique();
        if (!b)
        {
            return false;
        }

        b = this.ImportBinaryLoad();
        if (!b)
        {
            return false;
        }

        b = this.ImportDepend();
        if (!b)
        {
            return false;
        }

        b = this.ImportModuleLoad();
        if (!b)
        {
            return false;
        }

        b = this.CreateModule();
        if (!b)
        {
            return false;
        }

        b = this.SetModuleImport();
        if (!b)
        {
            return false;
        }

        b = this.SetModuleExport();
        if (!b)
        {
            return false;
        }

        b = this.SetModuleStorage();
        if (!b)
        {
            return false;
        }

        b = this.SetModuleEntry();
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool SetModuleRef()
    {
        ModuleRef ka;
        ka = this.Port.Module;

        ModuleRef a;
        a = this.ClassInfra.ModuleRefCreate(ka.Name, ka.Ver);

        if (this.SystemModule)
        {
            a.Ver = 0;
        }

        this.ModuleRef = a;
        return true;
    }

    protected virtual bool SetImportModuleRef()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Array import;
        import = this.Port.Import;

        Array array;
        array = listInfra.ArrayCreate(import.Count);

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortImport o;
            o = (PortImport)import.GetAt(i);

            ModuleRef aa;
            aa = o.Module;

            String name;
            name = aa.Name;
            long version;
            version = aa.Ver;
            if (version == -1)
            {
                version = 0;
            }

            ModuleRef a;
            a = classInfra.ModuleRefCreate(name, version);

            array.SetAt(i, a);

            i = i + 1;
        }

        this.ImportModuleRefArray = array;
        return true;
    }

    protected virtual bool CheckImportUnique()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table table;
        table = this.ClassInfra.TableCreateModuleRefLess();

        Array array;
        array = this.ImportModuleRefArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef a;
            a = (ModuleRef)array.GetAt(i);

            if (table.Valid(a))
            {
                this.Status = 30;
                return false;
            }

            listInfra.TableAdd(table, a, a);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool CheckModuleRef(ModuleRef module)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        String name;
        name = module.Name;
        long version;
        version = module.Ver;

        if (!(this.NameCheck.IsModuleName(this.TA(name))))
        {
            this.Status = 1;
            return false;
        }

        if (!this.SystemModule)
        {
            if (version == -1)
            {
                this.Status = 2;
                return false;
            }

            if (this.IsBuiltinModuleRef(module))
            {
                this.Status = 3;
                return false;
            }
        }

        return true;
    }

    protected virtual bool CheckImportArrayModuleRef(Array array)
    {
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortImport a;
            a = (PortImport)array.GetAt(i);

            if (!this.CheckImportModuleRef(a.Module))
            {
                this.Status = 10;
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool CheckImportModuleRef(ModuleRef moduleRef)
    {
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        String name;
        name = moduleRef.Name;
        long version;
        version = moduleRef.Ver;

        if (!(this.NameCheck.IsModuleName(this.TA(name))))
        {
            return false;
        }

        bool isBuiltin;
        isBuiltin = this.IsBuiltinModuleRef(moduleRef);

        bool b;
        b = (version == -1);

        bool a;
        a = (isBuiltin == b);
        return a;
    }

    protected virtual bool ImportBinaryLoad()
    {
        this.BinaryTable = this.ClassInfra.TableCreateModuleRefLess();

        Array array;
        array = this.ImportModuleRefArray;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef a;
            a = (ModuleRef)array.GetAt(i);

            bool b;
            b = this.BinaryLoadRecursive(a);
            if (!b)
            {
                String k;
                k = this.ModuleRefString(a);

                this.ErrorAdd(this.ErrorKind.ModuleInvalid, k);

                this.Status = 50;
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual bool BinaryLoadRecursive(ModuleRef moduleRef)
    {
        if (this.BinaryTable.Valid(moduleRef))
        {
            return true;
        }

        BinaryBinary binary;
        binary = (BinaryBinary)this.BinaryTable.Get(moduleRef);

        Array array;
        array = binary.Import;
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            BinaryImport import;
            import = (BinaryImport)array.GetAt(i);

            bool ba;
            ba = this.BinaryLoadRecursive(import.Module);
            if (!ba)
            {
                return false;
            }

            i = i + 1;
        }

        bool b;
        b = this.BinaryLoad(moduleRef);
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool BinaryLoad(ModuleRef moduleRef)
    {
        String moduleRefString;
        moduleRefString = this.ModuleRefString(moduleRef);

        String filePath;
        filePath = this.AddClear().Add(moduleRefString).Add(this.SDotRef).AddResult();

        Data data;
        data = this.StorageInfra.DataRead(filePath);

        if (data == null)
        {
            return false;
        }

        long kk;
        kk = data.Count;

        InfraRange range;
        range = new InfraRange();
        range.Init();
        range.Count = kk;

        BinaryRead read;
        read = this.BinaryRead;

        read.Data = data;
        read.Range = range;

        read.Execute();

        BinaryBinary binary;
        binary = read.Binary;

        if (binary == null)
        {
            return false;
        }

        read.Binary = null;

        this.ListInfra.TableAdd(this.BinaryTable, binary.Ref, binary);
        return true;
    }

    protected virtual bool ImportDepend()
    {
        ModuleRef ka;
        ka = this.ModuleRef;

        if (this.BinaryTable.Valid(ka))
        {
            String k;
            k = this.ModuleRefString(ka);

            this.ErrorAdd(this.ErrorKind.ModuleUndefined, k);

            this.Status = 60;
            return false;
        }

        return true;
    }

    protected virtual bool ImportModuleLoad()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ModuleLoad moduleLoad;
        moduleLoad = this.ModuleLoad;

        moduleLoad.BinaryTable = this.BinaryTable;
        moduleLoad.ModuleTable = this.ModuleTable;

        Table table;
        table = this.ModuleTable;

        Iter iter;
        iter = this.BinaryTable.IterCreate();
        this.BinaryTable.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef moduleRef;
            moduleRef = (ModuleRef)iter.Index;

            moduleLoad.ModuleRef = moduleRef;

            bool b;
            b = moduleLoad.Execute();

            if (!b)
            {
                long o;
                o = moduleLoad.Status;

                String k;
                k = this.ModuleRefString(moduleRef);

                this.ErrorAdd(this.ErrorKind.ModuleUndefined, k);

                this.Status = 200 + o;
                return false;
            }

            ClassModule a;
            a = moduleLoad.Module;

            moduleLoad.Module = null;
            moduleLoad.ModuleRef = null;

            listInfra.TableAdd(table, a.Ref, a);
        }

        return true;
    }

    protected virtual bool CreateModule()
    {
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        ClassModule module;
        module = new ClassModule();
        module.Init();
        module.Ref = this.ModuleRef;
        module.Class = classInfra.TableCreateStringLess();
        module.Import = classInfra.TableCreateModuleRefLess();
        module.Export = classInfra.TableCreateStringLess();
        module.Storage = classInfra.TableCreateStringLess();

        this.Module = module;
        return true;
    }

    protected virtual bool SetModuleImport()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Table moduleTable;
        moduleTable = this.ModuleTable;

        NameCheck nameCheck;
        nameCheck = this.NameCheck;

        Array importModuleRef;
        importModuleRef = this.ImportModuleRefArray;

        Array array;
        array = this.Port.Import;

        bool b;
        b = false;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef kk;
            kk = (ModuleRef)importModuleRef.GetAt(i);

            ClassModule k;
            k = (ClassModule)moduleTable.Get(kk);

            Table a;
            a = classInfra.TableCreateRefLess();

            listInfra.TableAdd(this.Module.Import, kk, a);

            PortImport kkk;
            kkk = (PortImport)array.GetAt(i);

            Array importClassArray;
            importClassArray = kkk.Class;

            long countA;
            countA = importClassArray.Count;
            long iA;
            iA = 0;
            while (iA < countA)
            {
                PortImportClass importClass;
                importClass = (PortImportClass)importClassArray.GetAt(iA);

                String className;
                className = importClass.Class;

                ClassClass varClass;
                varClass = null;

                bool ba;
                ba = false;

                if (!ba)
                {
                    if (!nameCheck.IsName(this.TA(className)))
                    {
                        ba = true;
                    }
                }

                if (!ba)
                {
                    varClass = (ClassClass)k.Class.Get(className);

                    if (varClass == null)
                    {
                        ba = true;
                    }
                }

                if (ba)
                {
                    this.ErrorAdd(this.ErrorKind.ImportClassUndefined, className);
                    b = true;
                }

                if (!ba)
                {
                    listInfra.TableAdd(a, varClass, varClass);
                }

                String name;
                name = importClass.Name;

                bool bb;
                bb = false;

                if (!bb)
                {
                    if (!nameCheck.IsName(this.TA(name)))
                    {
                        bb = true;
                    }
                }

                if (!bb)
                {
                    if (this.ImportClass.Valid(name))
                    {
                        bb = true;
                    }
                }

                if (bb)
                {
                    this.ErrorAdd(this.ErrorKind.ImportNameUnavailable, name);
                    b = true;
                }

                if (!ba & !bb)
                {
                    listInfra.TableAdd(this.ImportClass, name, varClass);
                }


                iA = iA + 1;
            }

            i = i + 1;
        }

        if (b)
        {
            this.Status = 80;
            return false;
        }

        return true;
    }

    protected virtual bool SetModuleExport()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table exportTable;
        exportTable = this.Module.Export;

        NameCheck nameCheck;
        nameCheck = this.NameCheck;

        Array array;
        array = this.Port.Export;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortExport a;
            a = (PortExport)array.GetAt(i);

            String name;
            name = a.Class;

            if (!nameCheck.IsName(this.TA(name)))
            {
                this.Status = 85;
                return false;
            }

            if (this.ImportClass.Valid(name))
            {
                this.Status = 86;
                return false;
            }

            if (exportTable.Valid(name))
            {
                this.Status = 87;
                return false;
            }

            listInfra.TableAdd(exportTable, name, null);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetModuleStorage()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        StoragePathCheck pathCheck;
        pathCheck = this.StoragePathCheck;

        Table table;
        table = this.Module.Storage;

        Array array;
        array = this.Port.Storage;

        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            PortStorage a;
            a = (PortStorage)array.GetAt(i);

            String sourcePath;
            String destPath;
            sourcePath = a.SourcePath;
            destPath = a.Path;

            if (!pathCheck.IsValidSourcePath(this.TA(sourcePath)))
            {
                this.Status = 90;
                return false;
            }

            if (!pathCheck.IsValidDestPath(this.TA(destPath)))
            {
                this.Status = 91;
                return false;
            }

            if (table.Valid(destPath))
            {
                this.Status = 92;
                return false;
            }

            PortStorage m;
            m = new PortStorage();
            m.Init();
            m.Path = destPath;
            m.SourcePath = sourcePath;

            listInfra.TableAdd(table, destPath, m);

            i = i + 1;
        }

        return true;
    }

    protected virtual bool SetModuleEntry()
    {
        String entry;
        entry = this.Port.Entry;

        if (entry == null)
        {
            return true;
        }

        this.Module.Entry = entry;
        return true;
    }

    protected virtual String ModuleRefString(ModuleRef k)
    {
        String verString;
        verString = this.ClassInfra.VerString(k.Ver);

        String a;
        a = this.ClassInfra.ModuleRefString(k.Name, verString);

        return a;
    }

    protected virtual bool ErrorAdd(ErrorKind kind, String name)
    {
        Error a;
        a = new Error();
        a.Init();
        a.Kind = kind;
        a.Name = name;

        this.ErrorList.Add(a);
        return true;
    }

    protected virtual bool IsBuiltinModuleRef(ModuleRef moduleRef)
    {
        String name;
        name = moduleRef.Name;

        Text textName;
        textName = this.TA(name);

        bool b;
        b = false;

        if (!b)
        {
            if (this.TextSame(textName, this.TB(this.SystemModuleSingle)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextStart(textName, this.TB(this.SystemModulePre)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(textName, this.TB(this.ClassModuleSingle)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextStart(textName, this.TB(this.ClassModulePre)))
            {
                b = true;
            }
        }

        return b;
    }
}
namespace Avalon.Storage;

public class Arrange : Any
{
    public static Arrange This { get; } = ShareCreate();

    private static Arrange ShareCreate()
    {
        Arrange share;
        share = new Arrange();
        Any a;
        a = share;
        a.Init();
        return share;
    }
    
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.Intern = Extern.StorageArrange_New();
        Extern.StorageArrange_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.StorageArrange_Final(this.Intern);
        Extern.StorageArrange_Delete(this.Intern);
        return true;
    }

    public virtual string ModuleFoldPath
    {
        get
        {
            return this.InternIntern.ModuleFoldPath;
        }
        set
        {
        }
    }
    public virtual string ExecuteFoldPath
    {
        get
        {
            return this.InternIntern.ExecuteFoldPath;
        }
        set
        {
        }
    }
    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Rename(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Data.Value);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath.Data.Value);

        ulong o;
        o = Extern.StorageArrange_Rename(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FileCopy(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Data.Value);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath.Data.Value);

        ulong o;
        o = Extern.StorageArrange_FileCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FileRemove(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Data.Value);

        ulong o;
        o = Extern.StorageArrange_FileRemove(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FoldCreate(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Data.Value);

        ulong o;
        o = Extern.StorageArrange_FoldCreate(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FoldCopy(String path, String destPath)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Data.Value);
        ulong destPathU;
        destPathU = this.InternInfra.StringCreate(destPath.Data.Value);

        ulong o;
        o = Extern.StorageArrange_FoldCopy(this.Intern, pathU, destPathU);

        this.InternInfra.StringDelete(destPathU);
        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool FoldRemove(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Data.Value);

        ulong o;
        o = Extern.StorageArrange_FoldRemove(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }

    public virtual bool Exist(String path)
    {
        ulong pathU;
        pathU = this.InternInfra.StringCreate(path.Data.Value);

        ulong o;
        o = Extern.StorageArrange_Exist(this.Intern, pathU);

        this.InternInfra.StringDelete(pathU);

        bool a;
        a = (!(o == 0));
        return a;
    }
}
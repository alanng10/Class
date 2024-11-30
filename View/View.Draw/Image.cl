class Image : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InfraInfra : share InfraInfra;
        this.DrawInfra : share Infra;

        var Extern extern;
        extern : this.Extern;
        
        this.Size : new Size;
        this.Size.Init();

        this.InternData : extern.Data_New();
        extern.Data_Init(this.InternData);

        this.InternSize : extern.Size_New();
        extern.Size_Init(this.InternSize);

        this.Intern : extern.Image_New();
        extern.Image_DataSet(this.Intern, this.InternData);
        extern.Image_SizeSet(this.Intern, this.InternSize);
        extern.Image_Init(this.Intern);
        this.Ident : this.Intern;
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Image_Final(this.Intern);
        extern.Image_Delete(this.Intern);

        extern.Size_Final(this.Intern);
        extern.Size_Delete(this.Intern);

        extern.Data_Final(this.Intern);
        extern.Data_Delete(this.Intern);
        return true;
    }
    
    field prusate Size Size { get { return data; } set { data : value; } }

    field prusate Any Out
    {
        get
        {
            return this.Extern.Image_VideoOut(this.Intern);
        }
        set
        {
        }
    }

    field prusate Any Ident { get { return data; } set { data : value; } }
    field private Intern InternIntern { get { return data; } set { data : value; } }    
    field private Extern Extern { get { return data; } set { data : value; } }    
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate Infra DrawInfra { get { return data; } set { data : value; } }
    field pronate Int Intern { get { return data; } set { data : value; } }
    field private Int InternSize { get { return data; } set { data : value; } }
    field private Int InternData { get { return data; } set { data : value; } }
    
    maide prusate Bool DataCreate()
    {
        var Int wed;
        var Int het;
        wed : this.Size.Wed;
        het : this.Size.Het;
        
        var Extern extern;
        extern : this.Extern;

        extern.Size_WedSet(this.InternSize, wed);
        extern.Size_HetSet(this.InternSize, het);
        
        extern.Image_DataCreate(this.Intern);
        return true;
    }
}
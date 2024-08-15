namespace Avalon.View;

public class Size : Comp
{
    public override bool Init()
    {
        base.Init();
        this.WidthField = this.CreateWidthField();
        this.HeightField = this.CreateHeightField();
        return true;
    }

    protected virtual Field CreateWidthField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateHeightField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public override bool Change(Field varField, Change change)
    {
        if (this.WidthField == varField)
        {
            this.ChangeWidth(change);
        }
        if (this.HeightField == varField)
        {
            this.ChangeHeight(change);
        }
        return true;
    }

    public virtual Field WidthField { get; set; }

    public virtual long Width
    {
        get
        {
            return this.WidthField.GetInt();
        }

        set
        {
            this.WidthField.SetInt(value);
        }
    }

    protected virtual bool ChangeWidth(Change change)
    {
        this.Event(this.WidthField);
        return true;
    }

    public virtual Field HeightField { get; set; }

    public virtual long Height
    {
        get
        {
            return this.HeightField.GetInt();
        }

        set
        {
            this.HeightField.SetInt(value);
        }
    }

    protected virtual bool ChangeHeight(Change change)
    {
        this.Event(this.HeightField);
        return true;
    }
}
namespace Class.Node;

public class CreateOperate : Any
{
    public virtual Create Create { get; set; }

    public virtual Node Execute()
    {
        return null;
    }

    public virtual int ExecuteListNew()
    {
        return 0;
    }

    public virtual Array ExecuteListGet(int index)
    {
        return null;
    }

    public virtual bool ExecuteListSetItem(int index, int itemIndex, object item)
    {
        return true;
    }

    public virtual bool ExecuteListCount(int index, int count)
    {
        return true;
    }
    
    public virtual bool ExecuteError(ErrorKind kind, int start, int end)
    {
        return true;
    }

    public virtual string ExecuteNameValue(Text text)
    {
        return null;
    }

    public virtual string ExecuteStringValue(Text text)
    {
        return null;
    }
}
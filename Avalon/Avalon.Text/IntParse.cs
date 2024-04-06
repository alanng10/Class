namespace Avalon.Text;

public class IntParse : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = Infra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra TextInfra { get; set; }

    public virtual long Execute(Span span, int varBase, bool upperCase)
    {
        if (varBase < 2 | 32 < varBase)
        {
            return -1;
        }

        long capValue;
        capValue = this.InfraInfra.IntCapValue;
        Infra textInfra;
        textInfra = this.TextInfra;
        long m;
        m = 0;
        long h;
        h = 1;
        long oo;
        oo = 0;
        int digitValue;
        digitValue = 0;
        Data data;
        data = span.Data;
        InfraRange range;
        range = span.Range;
        int count;
        count = range.Count;
        int index;
        index = 0;
        int start;
        start = range.Index;
        char oc;
        oc = (char)0;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + count - 1 - i;
            oc = textInfra.DataCharGet(data, index);
            
            digitValue = this.DigitValue(oc, varBase, upperCase);
            if (digitValue == -1)
            {
                return -1;
            }

            oo = h * digitValue;
            
            m = m + oo;

            if (!(m < capValue))
            {
                return -1;
            }

            h = h * varBase;

            i = i + 1;
        }

        long a;
        a = m;
        return a;
    }

    protected virtual int DigitValue(char oc, int varBase, bool upperCase)
    {
        int oa;
        oa = 0;
        bool b;
        b = (varBase < 10);
        if (b)
        {
            oa = varBase;
        }
        if (!b)
        {
            oa = 10;
        }
        int oaa;
        oaa = 0;
        if (!b)
        {
            oaa = varBase - 10;
        }
        char oca;
        oca = 'a';
        if (upperCase)
        {
            oca = 'A';
        }

        Infra textInfra;
        textInfra = this.TextInfra;
        
        if (textInfra.IsDigit(oc))
        {
            int ooa;
            ooa = oc - '0';
            if (!(ooa < oa))
            {
                return -1;
            }

            return ooa;
        }

        bool ba;
        ba = false;
        if (upperCase)
        {
            if (textInfra.IsUpperLetter(oc))
            {
                ba = true;
            }
        }
        if (!upperCase)
        {
            if (textInfra.IsLowerLetter(oc))
            {
                ba = true;
            }
        }
        if (!ba)
        {
            return -1;
        }

        int oob;
        oob = oc - oca;
        if (!(oob < oaa))
        {
            return -1;
        }

        return oob + 10;
    }
}
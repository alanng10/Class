namespace Class.Infra;

public class StringValueWrite : Any
{
    public override bool Init()
    {
        base.Init();
        
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = Infra.This;
        this.StringComp = StringComp.This;

        this.CountWriteOperate = new CountWriteOperate();
        this.CountWriteOperate.Write = this;
        this.CountWriteOperate.Init();
        this.AddWriteOperate = new AddWriteOperate();
        this.AddWriteOperate.Write = this;
        this.AddWriteOperate.Init();
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Infra ClassInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    public virtual CountWriteOperate CountWriteOperate { get; set; }
    public virtual AddWriteOperate AddWriteOperate { get; set; }

    public virtual WriteOperate WriteOperate { get; set; }

    public virtual Data Data { get; set; }
    public virtual long Index { get; set; }

    public virtual String Value(Text text)
    {
        bool b;
        b = this.CheckValueString(text);
        if (!b)
        {
            return null;
        }

        this.WriteOperate = this.CountWriteOperate;
        this.Index = 0;
        this.ExecuteValueString(text);

        long count;
        count = this.Index;
        
        long k;
        k = count;
        k = k * sizeof(uint);
        this.Data = new Data();
        this.Data.Count = k;
        this.Data.Init();

        this.WriteOperate = this.AddWriteOperate;
        this.Index = 0;
        this.ExecuteValueString(text);

        String a;
        a = this.StringComp.CreateData(this.Data, null);

        this.Data = null;
        this.WriteOperate = null;
        return a;
    }

    public virtual bool CheckValueString(Text text)
    {
        InfraRange range;
        range = text.Range;
        int kk;
        kk = range.Count;
        if (kk < 2)
        {
            return false;
        }

        Data data;
        data = text.Data;
        int rangeStart;
        rangeStart = range.Index;
        int rangeEnd;
        rangeEnd = range.Index + range.Count;

        char quote;
        quote = this.ClassInfra.Quote[0];

        TextInfra textInfra;
        textInfra = this.TextInfra;

        char oc;
        oc = textInfra.DataCharGet(data, rangeStart);
        if (!(oc == quote))
        {
            return false;
        }
        oc = textInfra.DataCharGet(data, rangeEnd - 1);
        if (!(oc == quote))
        {
            return false;
        }

        char backSlash;
        backSlash = this.ClassInfra.BackSlash[0];
        char tab;
        tab = this.ClassInfra.Tab[0];
        char newLine;
        newLine = this.ClassInfra.NewLine[0];

        int countA;
        countA = 4;

        int count;
        count = kk - 2;
        int start;
        start = rangeStart + 1;
        int index;
        int indexA;
        char c;
        bool b;
        bool bb;
        bool bba;
        int j;
        char u;
        int i;
        i = 0;
        while (i < count)
        {
            index = start + i;

            c = textInfra.DataCharGet(data, index);

            b = (c == backSlash);
            if (b)
            {
                j = i + 1;
                bb = (j < count);
                if (!bb)
                {
                    return false;
                }
                indexA = start + j;

                u = textInfra.DataCharGet(data, indexA);

                bba = false;                
                if (u == quote)
                {
                    bba = true;
                }
                if (u == 'n')
                {
                    bba = true;
                }
                if (u == backSlash)
                {
                    bba = true;
                }
                if (u == 'u')
                {
                    int k;
                    k = j + countA;
                    if (!(k < count))
                    {
                        return false;
                    }
                    int indexAa;
                    indexAa = start + j + 1;
                    int iA;
                    iA = 0;
                    while (iA < countA)
                    {
                        int oa;
                        oa = indexAa + iA;
                        char ua;
                        ua = textInfra.DataCharGet(data, oa);

                        if (!(textInfra.IsDigit(ua) | textInfra.IsHexLetter(ua, false)))
                        {
                            return false;
                        }

                        iA = iA + 1;
                    }

                    i = i + countA;
                    bba = true;
                }
                if (!bba)
                {
                    return false;
                }
                i = i + 1;
            }
            if (!b)
            {
                bb = (c == quote);
                if (bb)
                {
                    return false;
                }                
            }
            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteValueString(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        Infra classInfra;
        classInfra = this.ClassInfra;
        StringComp stringComp;
        stringComp = this.StringComp;

        Data data;
        data = text.Data;
        InfraRange range;
        range = text.Range;
        long kk;
        kk = range.Count;

        uint backSlash;
        backSlash = (uint)stringComp.Char(classInfra.BackSlash, 0);
        uint quote;
        quote = (uint)stringComp.Char(classInfra.Quote, 0);
        uint newLine;
        newLine = (uint)stringComp.Char(classInfra.NewLine, 0);
        uint uuu;
        uuu = 0;
        
        long countA;
        countA = 4;
        long count;
        count = kk - 2;
        long start;
        start = range.Index + 1;
        uint u;
        uint escapeValue;
        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = start + i;

            uint c;
            c = textInfra.DataCharGet(data, index);

            bool b;
            b = (c == backSlash);
            if (b)
            {
                long j;
                j = i + 1;

                bool bb;
                bb = (j < count);
                if (bb)
                {
                    long indexA;
                    indexA = start + j;
                    u = textInfra.DataCharGet(data, indexA);

                    escapeValue = uuu;                    
                    if (u == quote)
                    {
                        escapeValue = u;
                    }
                    if (u == 'n')
                    {
                        escapeValue = newLine;
                    }
                    if (u == backSlash)
                    {
                        escapeValue = u;
                    }
                    if (u == 'u')
                    {
                        int ka;
                        ka = 0;
                        int indexAa;
                        indexAa = start + j + 1;
                        int iA;
                        iA = 0;
                        while (iA < countA)
                        {
                            int oa;
                            oa = indexAa + iA;
                            char ua;
                            ua = textInfra.DataCharGet(data, oa);

                            int od;
                            od = textInfra.DigitValue(ua, 16, false);

                            int na;
                            na = countA - 1 - iA;

                            int nn;
                            nn = od << (na * 4);

                            ka = ka | nn;

                            iA = iA + 1;
                        }

                        char uu;
                        uu = (char)ka;
                        escapeValue = uu;

                        i = i + countA;
                    }
                    this.ExecuteValueChar(escapeValue);
                    i = i + 1;
                }
            }
            if (!b)
            {
                this.ExecuteValueChar(c);
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteValueChar(uint oc)
    {
        this.WriteOperate.ExecuteChar(oc);
        return true;
    }
}
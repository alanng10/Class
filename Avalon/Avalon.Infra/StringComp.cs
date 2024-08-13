namespace Avalon.Infra;

public class StringComp : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = Infra.This;
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual Infra InfraInfra { get; set; }

    public virtual String CreateChar(uint c, long count)
    {
        Infra infraInfra;
        infraInfra = this.InfraInfra;

        if (count < 0)
        {
            return null;
        }

        int ko;
        ko = sizeof(uint);

        long ka;
        ka = count * ko;
        
        Data data;
        data = new Data();
        data.Count = ka;
        data.Init();

        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * ko;

            infraInfra.DataMidSet(data, index, c);

            i = i + 1;
        }

        String a;
        a = new String();
        a.Data = data;
        a.Count = count;
        a.Init();
        
        return a;
    }

    public virtual String CreateData(Data data, Range range)
    {
        Infra infraInfra;
        infraInfra = this.InfraInfra;

        int kka;
        kka = sizeof(uint);

        long dataCount;
        dataCount = data.Count;
        long totalCount;
        totalCount = dataCount / kka;

        long index;
        long count;
        index = 0;
        count = 0;
        bool b;
        b = (range == null);
        if (b)
        {
            index = 0;
            count = totalCount;
        }
        if (!b)
        {
            index = range.Index;
            count = range.Count;
            if (!infraInfra.ValidRange(totalCount, index, count))
            {
                return null;
            }
        }

        Data dest;
        dest = new Data();
        dest.Count = count * kka;
        dest.Init();

        Data sourceData;
        sourceData = null;

        bool ba;
        ba = (data is StringData);

        if (!ba)
        {
            sourceData = data;
        }

        if (ba)
        {
            StringData stringData;
            stringData = (StringData)data;

            String koo;
            koo = stringData.ValueString;

            sourceData = koo.DataData;
        }

        long i;
        i = 0;
        while (i < count)
        {
            long kea;
            long keb;
            kea = (i + index) * kka;
            keb = i * kka;

            uint aa;
            aa = infraInfra.DataCharGet(sourceData, kea);

            infraInfra.DataCharSet(dest, keb, aa);

            i = i + 1;
        }


        String a;
        a = new String();
        a.DataData = dest;
        a.CountData = count;
        a.Init();
        
        return a;
    }
}
namespace Avalon.Time;

public class Time : Any
{
    public override bool Init()
    {
        base.Init();
        this.Intern = Extern.Time_New();
        Extern.Time_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Time_Final(this.Intern);
        Extern.Time_Delete(this.Intern);
        return true;
    }

    private ulong Intern { get; set; }

    public virtual int Year
    {
        get
        {
            ulong u;
            u = Extern.Time_YearGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int Month
    {
        get
        {
            ulong u;
            u = Extern.Time_MonthGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int Day
    {
        get
        {
            ulong u;
            u = Extern.Time_DayGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int Hour
    {
        get
        {
            ulong u;
            u = Extern.Time_HourGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int Min
    {
        get
        {
            ulong u;
            u = Extern.Time_MinGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int Sec
    {
        get
        {
            ulong u;
            u = Extern.Time_SecGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int Millisec
    {
        get
        {
            ulong u;
            u = Extern.Time_MillisecGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int Pos
    {
        get
        {
            ulong u;
            u = Extern.Time_PosGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int YearDay
    {
        get
        {
            ulong u;
            u = Extern.Time_YearDayGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int WeekDay
    {
        get
        {
            ulong u;
            u = Extern.Time_WeekDayGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int YearDayCount
    {
        get
        {
            ulong u;
            u = Extern.Time_YearDayCountGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual int MonthDayCount
    {
        get
        {
            ulong u;
            u = Extern.Time_MonthDayCountGet(this.Intern);
            int a;
            a = (int)u;
            return a;
        }
        set
        {
        }
    }

    public virtual long TotalMillisec
    {
        get
        {
            ulong u;
            u = Extern.Time_TotalMillisecGet(this.Intern);
            long a;
            a = (long)u;
            return a;
        }
        set
        {
        }
    }

    public virtual bool This()
    {
        Extern.Time_This(this.Intern);
        return true;
    }

    public virtual bool ToPos(int pos)
    {
        ulong u;
        u = (ulong)pos;
        Extern.Time_ToPos(this.Intern, u);
        return true;
    }

    public virtual bool AddYear(int value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddYear(this.Intern, u);
        return true;
    }

    public virtual bool AddMonth(int value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddMonth(this.Intern, u);
        return true;
    }

    public virtual bool AddDay(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddDay(this.Intern, u);
        return true;
    }

    public virtual bool AddHour(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddHour(this.Intern, u);
        return true;
    }

    public virtual bool AddMin(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddMin(this.Intern, u);
        return true;
    }

    public virtual bool AddSec(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddSec(this.Intern, u);
        return true;
    }

    public virtual bool AddMillisec(long value)
    {
        ulong u;
        u = (ulong)value;
        Extern.Time_AddMillisec(this.Intern, u);
        return true;
    }

    public virtual bool LeapYear(int year)
    {
        ulong ua;
        ua = (ulong)year;
        ulong u;
        u = Extern.Time_LeapYear(ua);

        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool ValidDate(int year, int month, int day)
    {
        ulong yearU;
        ulong monthU;
        ulong dayU;
        yearU = (ulong)year;
        monthU = (ulong)month;
        dayU = (ulong)day;
        ulong u;
        u = Extern.Time_ValidDate(yearU, monthU, dayU);

        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool ValidTime(int hour, int min, int sec, int millisec)
    {
        ulong hourU;
        ulong minU;
        ulong secU;
        ulong millisecU;
        hourU = (ulong)hour;
        minU = (ulong)min;
        secU = (ulong)sec;
        millisecU = (ulong)millisec;
        ulong u;
        u = Extern.Time_ValidTime(hourU, minU, secU, millisecU);

        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool Set(int year, int month, int day, int hour, int min, int sec, int millisec, int pos)
    {
        ulong yearU;
        ulong monthU;
        ulong dayU;
        ulong hourU;
        ulong minU;
        ulong secU;
        ulong millisecU;
        ulong posU;
        yearU = (ulong)year;
        monthU = (ulong)month;
        dayU = (ulong)day;
        hourU = (ulong)hour;
        minU = (ulong)min;
        secU = (ulong)sec;
        millisecU = (ulong)millisec;
        posU = (ulong)pos;

        Extern.Time_Set(this.Intern, yearU, monthU, dayU, hourU, minU, secU, millisecU, posU);
        return true;
    }
}
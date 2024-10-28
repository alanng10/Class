class Format : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InfraInfra : share InfraInfra;
        this.TextInfra : share Infra;
        this.StringComp : share StringComp;

        this.InitCountState();
        this.InitResultState();
        return true;
    }

    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate Infra TextInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate Int KindCount { get { return 4; } set { } }
    field precate Array CountState { get { return data; } set { data : value; } }
    field precate Array ResultState { get { return data; } set { data : value; } }
    field precate Array Array { get { return data; } set { data : value; } }
    field precate Int ArrayIndex { get { return data; } set { data : value; } }

    maide precate Bool InitCountState()
    {
        this.CountState : new Array;
        this.CountState.Count : this.KindCount;
        this.CountState.Init();

        this.Array : this.CountState;
        this.ArrayIndex : 0;

        this.CountStateAdd(new BoolFormatCountState);
        this.CountStateAdd(new IntFormatCountState);
        this.CountStateAdd(new TextFormatCountState);
        return true;
    }

    maide precate Bool InitResultState()
    {
        this.ResultState : new Array;
        this.ResultState.Count : this.KindCount;
        this.ResultState.Init();

        this.Array : this.ResultState;
        this.ArrayIndex : 0;

        this.ResultStateAdd(new BoolFormatResultState);
        this.ResultStateAdd(new IntFormatResultState);
        this.ResultStateAdd(new TextFormatResultState);
        return true;
    }

    maide precate Bool CountStateAdd(var FormatCountState state)
    {
        state.Format : this;
        state.Init();
        this.ArrayAdd(state);
        return true;
    }

    maide precate Bool ResultStateAdd(var FormatResultState state)
    {
        state.Format : this;
        state.Init();
        this.ArrayAdd(state);
        return true;
    }

    maide precate Bool ArrayAdd(var Any item)
    {
        var Int index;
        index : this.ArrayIndex;
        this.Array.Set(index, item);
        index : index + 1;
        this.ArrayIndex : index;
        return true;
    }

    maide prusate Int ExecuteCount(var Text varBase, var Array argList)
    {
        var Int count;
        count : argList.Count;
        var Int k;
        k : 0;
        var Int i;
        i : 0;
        while (i < count)
        {
            var FormatArg arg;
            arg : cast FormatArg(argList.Get(i));

            this.ExecuteArgCount(arg);

            var Int ka;
            ka : arg.Count;

            k : k + ka;

            i : i + 1;
        }

        var Int baseCount;
        baseCount : varBase.Range.Count;

        k : k + baseCount;

        var Int a;
        a : k;
        return a;
    }

    maide prusate Bool ExecuteResult(var Text varBase, var Array argList, var Text result)
    {
        var Infra textInfra;
        textInfra : this.TextInfra;
        inf (~textInfra.ValidRange(varBase))
        {
            return false;
        }
        inf (~textInfra.ValidRange(result))
        {
            return false;
        }

        var Data baseData;
        baseData : varBase.Data;
        var Range baseRange;
        baseRange : varBase.Range;
        var Int baseStart;
        baseStart : baseRange.Index;
        var Int baseCount;
        baseCount : baseRange.Count;

        var Int argCount;
        argCount : argList.Count;

        var Data resultData;
        resultData : result.Data;
        var Range resultRange;
        resultRange : result.Range;
        var Int resultStart;
        resultStart : resultRange.Index;
        var Int resultCount;
        resultCount : resultRange.Count;

        var Int count;
        count : baseCount + 1;
        var Int resultIndex;
        resultIndex : 0;
        var Int argIndex;
        argIndex : 0;
        var Int i;
        i : 0;
        while (i < count)
        {
            var Bool b;
            b : false;

            while ((~b) & (argIndex < argCount))
            {
                var FormatArg arg;
                arg : cast FormatArg(argList.Get(argIndex));

                var Int k;
                k : arg.Pos;

                var Bool ba;
                ba : (i = k);
                inf (ba)
                {
                    var Int countA;
                    countA : arg.Count;

                    var Int oa;
                    oa : resultStart + resultIndex;
                    resultRange.Index : oa;
                    resultRange.Count : countA;
                    
                    this.ExecuteArgResult(arg, result);

                    resultRange.Index : resultStart;
                    resultRange.Count : resultCount;

                    resultIndex : resultIndex + countA;

                    argIndex : argIndex + 1;
                }
                inf (~ba)
                {
                    b : true;
                }
            }

            inf (~(i = baseCount))
            {
                var Int n;
                n : textInfra.DataCharGet(baseData, baseStart + i);

                textInfra.DataCharSet(resultData, resultStart + resultIndex, n);
                
                resultIndex : resultIndex + 1;
            }

            i : i + 1;
        }
        return true;
    }

    maide prusate Bool ExecuteArgCount(var FormatArg arg)
    {
        inf (~this.ValidArg(arg))
        {
            return false;
        }

        var Int kind;
        kind : arg.Kind;
        var FormatCountState state;
        state : cast FormatCountState(this.CountState.Get(kind));

        state.Arg : arg;
        state.Execute();

        state.Arg : null;

        var Int aa;
        aa : cast Int(state.Result);

        var Int valueCount;
        valueCount : aa;

        var Int fieldWidth;
        fieldWidth : arg.FieldWidth;

        var Int maxWidth;
        maxWidth : arg.MaxWidth;

        var Int count;
        count : valueCount;

        inf (count < fieldWidth)
        {
            count : fieldWidth;
        }

        inf (~(maxWidth = null))
        {
            inf (maxWidth < count)
            {
                count : maxWidth;
            }
        }

        arg.ValueCount : valueCount;
        arg.Count : count;
        return true;
    }

    maide prusate Bool ExecuteArgResult(var FormatArg arg, var Text result)
    {
        inf (~this.ValidArg(arg))
        {
            return false;
        }
        inf (~this.TextInfra.ValidRange(result))
        {
            return false;
        }
        inf (result.Range.Count < arg.Count)
        {
            return false;
        }

        var Int kind;
        kind : arg.Kind;
        var FormatResultState state;
        state : cast FormatResultState(this.ResultState.Get(kind));

        var FormatResultArg ke;
        ke : cast FormatResultArg(state.Arg);
        ke.Arg : arg;
        ke.Result : result;

        state.Execute();

        ke.Result: null;
        ke.Arg : null;
        return true;
    }

    maide prusate Bool ResultBool(var Text result, var Form form, var Bool value, var Int valueWriteCount, var Int valueStart, var Int valueIndex)
    {
        var Infra textInfra;
        textInfra : this.TextInfra;

        var CharForm charForm;
        charForm : this.CharForm;

        var Data destData;
        destData : result.Data;
        var Int destStart;
        destStart : result.Range.Index;

        var String source;
        inf (~value)
        {
            source : textInfra.BoolFalseString;
        }
        inf (value)
        {
            source : textInfra.BoolTrueString;
        }

        var Int destIndex;
        destIndex : destStart + valueStart;
        var Int ouc;
        ouc : 0;
        var Int oc;
        oc : 0;
        var Int aa;
        aa : 0;
        var Int index;
        index : 0;
        var Int lowerLetterA;
        lowerLetterA : textInfra.LetterLowerA;
        var Int upperLetterA;
        upperLetterA : textInfra.LetterUpperA;
        var Int count;
        count : valueWriteCount;
        var Int i;
        i : 0;
        while (i < count)
        {
            index : i + valueIndex;

            ouc : source.Char(index);
            aa : ouc;

            inf (varCase = 1)
            {
                inf (index = 0)
                {
                    aa : ouc - lowerLetterA + upperLetterA;
                }
            }
            inf (varCase = 2)
            {
                aa : ouc - lowerLetterA + upperLetterA;
            }
            oc : aa;

            oc : charForm.Execute(oc);

            textInfra.DataCharSet(destData, destIndex + i, oc);

            i : i + 1;
        }
        return true;
    }

    maide prusate Bool ResultInt(var Text result, var Int value, var Int varBase, var Int varCase, var Int valueCount, var Int valueWriteCount, var Int valueStart, var Int valueIndex)
    {
        var Infra textInfra;
        textInfra : this.TextInfra;

        var CharForm charForm;
        charForm : this.CharForm;

        var Data destData;
        destData : result.Data;
        var Int destStart;
        destStart : result.Range.Index;

        var Int destIndex;
        destIndex : destStart + valueStart;

        inf (value = 0)
        {
            inf (~(valueWriteCount = 0))
            {
                var Int occ;
                occ : "0".Char(0);

                occ : charForm.Execute(occ);

                textInfra.DataCharSet(destData, destIndex, occ);
            }
            return true;
        }

        var Int end;
        end : valueIndex + valueWriteCount;

        var Bool upperCase;
        upperCase : ~(varCase = 0);
        var Int letterDigitStart;
        letterDigitStart : "a".Char(0);
        inf (upperCase)
        {
            letterDigitStart : "A".Char(0);
        }
        var Int k;
        k : value;
        var Int j;
        j : 0;
        var Int ka;
        ka : 0;
        var Int digit;
        digit : 0;
        var Int oa;
        oa : 0;
        var Int c;
        c : 0;

        var Int index;
        index : 0;
        var Int count;
        count : valueCount;
        var Int i;
        i : 0;
        while (i < count)
        {
            j : k / varBase;

            index : (count - 1) - i;

            inf ((~(index < valueIndex)) & index < end)
            {
                ka : k - j * varBase;

                digit : ka;

                c : textInfra.DigitChar(digit, letterDigitStart);

                c : charForm.Execute(c);

                oa : index - valueIndex;

                textInfra.DataCharSet(destData, destIndex + oa, c);
            }

            k : j;

            i : i + 1;
        }
        return true;
    }

    maide prusate Bool ResultText(var Text result, var Text value, var Int varCase, var Int valueWriteCount, var Int valueStart, var Int valueIndex)
    {
        var Infra textInfra;
        textInfra : this.TextInfra;

        var CharForm charForm;
        charForm : this.CharForm;

        var Data sourceData;
        sourceData : value.Data;
        var Int sourceStart;
        sourceStart : value.Range.Index;

        var Data destData;
        destData : result.Data;
        var Int destStart;
        destStart : result.Range.Index;

        var Int sourceIndex;
        sourceIndex : sourceStart + valueIndex;
        var Int destIndex;
        destIndex : destStart + valueStart;
        var Int lowerLetterA;
        lowerLetterA : "a".Char(0);
        var Int upperLetterA;
        upperLetterA : "A".Char(0);
        var Int ouc;
        ouc : 0;
        var Int oc;
        oc : 0;
        var Int aa;
        aa : 0;
        var Int count;
        count : valueWriteCount;
        var Int i;
        i : 0;
        while (i < count)
        {
            ouc : textInfra.DataCharGet(sourceData, sourceIndex + i);

            aa : ouc;

            inf (varCase = 1)
            {
                inf (textInfra.IsLetter(ouc, true))
                {
                    aa : ouc - upperLetterA + lowerLetterA;
                }
            }
            inf (varCase = 2)
            {
                inf (textInfra.IsLetter(ouc, false))
                {
                    aa : ouc - lowerLetterA + upperLetterA;
                }
            }
            oc : aa;

            oc : charForm.Execute(oc);

            textInfra.DataCharSet(destData, destIndex + i, oc);

            i : i + 1;
        }
        return true;
    }

    maide prusate Bool ResultFill(var Text dest, var Int fillIndex, var Int fillCount, var Int fillChar)
    {
        var Infra textInfra;
        textInfra : this.TextInfra;
        var Data destData;
        destData : dest.Data;
        var Int destStart;
        destStart : dest.Range.Index;
        var Int destIndex;
        destIndex : destStart + fillIndex;
        var Int index;
        index : 0;
        var Int count;
        count : fillCount;
        var Int i;
        i : 0;
        while (i < count)
        {
            index : destIndex + i;
            textInfra.DataCharSet(destData, index, fillChar);
            i : i + 1;
        }
        return true;
    }

    maide prusate Int IntDigitCount(var Int value, var Int varBase)
    {
        var Int digitCount;
        digitCount : 0;

        var Int oa;
        oa : value;
        while (0 < oa)
        {
            oa : oa / varBase;
            digitCount : digitCount + 1;
        }

        inf (digitCount = 0)
        {
            digitCount : 1;
        }

        var Int a;
        a : digitCount;
        return a;
    }

    maide prusate Bool ValidArg(var FormatArg arg)
    {
        var Int kind;
        kind : arg.Kind;

        inf (~this.ValidKind(kind))
        {
            return false;
        }
        
        inf (arg.Value = null)
        {
            return false;
        }
        
        inf (kind = 0)
        {
            var Bool aaa;
            aaa : cast Bool(arg.Value);
            inf (aaa = null)
            {
                return false;   
            }
        }

        inf (kind = 1 | kind = 2 | kind = 4)
        {
            var Int aab;
            aab : cast Int(arg.Value);
            inf (aab = null)
            {
                return false;   
            }

            inf (kind = 1 | kind = 2)
            {
                inf (~this.ValidIntBase(arg.Base))
                {
                    return false;
                }
            }
        }
        inf (kind = 3)
        {
            var Text aac;
            aac : cast Text(arg.Value);
            inf (aac = null)
            {
                return false;   
            }
            
            inf (~this.TextInfra.ValidRange(aac))
            {
                return false;
            }
        }
        return true;
    }

    maide prusate Bool ValidKind(var Int kind)
    {
        return this.InfraInfra.ValidIndex(this.KindCount, kind);
    }

    maide prusate Bool ValidIntBase(var Int varBase)
    {
        return ~(varBase < 2 | 16 < varBase);
    }
}
#include "Init.h"

Int Intern_Init(Int entryClass)
{
    Main_Init();

    Int ka;
    ka = Intern_InitMainThread();

    Eval* eval;
    eval = CastPointer(ka);

    Intern_New(RefKindAny, entryClass, eval);
}
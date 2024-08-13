#pragma once

#include <Infra/Prudate.h>

#ifdef InfraIntern_Module
#define Intern_Api ExportApi
#else
#define Intern_Api ImportApi
#endif

typedef struct
{
    Int Index;
    Int* Stack;
}
Eval;

typedef Int (*Intern_State)(Eval* eval, Int frame);

Intern_Api extern Int Intern_Any_Class[];
Intern_Api extern Int Intern_Intern_Class[];

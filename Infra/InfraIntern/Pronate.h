#pragma once

#include "Prusate.h"

#include "Pronate_Part.h"

#define RefMaskMemoryClear (0x000fffffffffffff)

#define RefKindAny (0x1ULL)

#define RefKindMaskAny (RefKindAny << 60)


extern Int Intern_Intern_MaideCall[];

Int Intern_Intern_Init(Eval* eval, Int frame);

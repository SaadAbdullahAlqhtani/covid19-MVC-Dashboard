using covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Service

{
    public interface ICaseRepository
    {
        ICollection<Case> GetCases();
        ICollection<Case> GetCuredCases();
        ICollection<Case> GetInfectedCases();
        Case GetCase(int caseId);
        bool CaseExists(int CaseId);

        bool CreateCase(Case caseId);
        bool UpdateCase(Case caseId);
        bool DeleteCase(Case caseId);
        bool Save();
    }
}

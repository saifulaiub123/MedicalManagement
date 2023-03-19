using MH.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.Application.IHelper
{
    public interface IPowerShellHelper
    {
        Task RunPowerShellScript(ScriptViewModel script,int userId);
    }
}

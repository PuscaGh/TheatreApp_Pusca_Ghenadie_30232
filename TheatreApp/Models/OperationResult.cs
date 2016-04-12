using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // This enum will be used to represents the operation results state
    public static class OperationResult
    {
        public enum opResult : int
        {
            OperationLoginFail = 0,
            OperationLoginUser,
            OperationLoginAdmin,
            OperationAddUserFail,
            OperationAddUserSucces,
            OperationAddTicketFail,
            OperationAddTicketSucces,
            OperationAddSpectacleFail,
            OperationAddSpectacleSucces,
            OperationUpdateSpectacleFail,
            OperationUpdateSpectacleSucces,
            OperationDeleteSpectacleFail,
            OperationDeleteSpectacleSucces,
            OperationInsertTicketDuplicate
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FscCore.Core.BusinessEntity;

namespace Core.BusinessServices
{
    public interface ITokenServices
    {
        #region Interface member methods.
  
        TokenEntity GenerateToken(string userId);
   
        bool ValidateToken(string tokenId);
    
        bool Kill(string tokenId);
    
        bool DeleteByUserId(string userId);
        #endregion
    }
}

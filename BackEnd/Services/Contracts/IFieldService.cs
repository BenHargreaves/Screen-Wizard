using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Services.Contracts
{
    public interface IFieldService
    {
        Task<IEnumerable<FieldMetadata>> All(string collectionName);

    }
}

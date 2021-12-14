using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra
{
    public interface IBarRepository
    {
        void saveBar(Bar bar);

        void removeBar(Guid id);

        List<Bar> getAll();

        Bar get(Guid id);
    }
}

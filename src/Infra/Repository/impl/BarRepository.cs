using Domain;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.impl
{
    public class BarRepository : IBarRepository
    {
        private readonly BarContext _context;

        public BarRepository(BarContext context)
        {
            _context = context;
        }


        public Bar get(Guid id)
        {
            return _context.Bar.Where(r => r.Id.Equals(id)).FirstOrDefault();
        }

        public List<Bar> getAll()
        {
            return _context.Bar.ToList();
        }

        public void removeBar(Guid id)
        {
            var bar = _context.Bar.Where(r => r.Id.Equals(id)).FirstOrDefault();

            if (bar == null)
                throw new Exception("Não foi possivel encontrar Bar.");

            _context.Bar.Remove(bar);
            _context.SaveChanges();
        }

        public void saveBar(Bar bar)
        {
            //curl --header "Content-Type: application/json" -k --request POST --data '{"Nome":"Joao"}' https://localhost:44349/bar/save

            _context.Bar.Add(bar);
            _context.SaveChanges();
        }
    }
}

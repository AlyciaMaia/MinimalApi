using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos
{
    public class VeiculoServicos : IVeiculosServicos
    {
        private readonly DbContexto _contexto;

        public VeiculoServicos(DbContexto contexto)
        {
            _contexto = contexto;
        }
        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();

        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo BuscaPorId(int Id)
        {
           return _contexto.Veiculos.Where(v => v.Id == Id).FirstOrDefault();
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> Todos(int? pagina = 1, string? Nome = null, string? Marca = null)
        {
            var query = _contexto.Veiculos.AsQueryable();
            if (!string.IsNullOrEmpty(Nome))
            {
                query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{Nome}%"));
            }

            int ItensPorPagina = 10;

            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * ItensPorPagina).Take(ItensPorPagina);
            }
            

            return query.ToList();
        }
    }
}
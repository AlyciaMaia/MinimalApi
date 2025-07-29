using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Dominio.Interfaces
{
    public interface IVeiculosServicos
    {
        List<Veiculo> Todos(int? pagina = 1, string? Nome = null, string? Marca = null);
        Veiculo? BuscaPorId(int Id);
        void Incluir(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Apagar  (Veiculo veiculo);
    }
}
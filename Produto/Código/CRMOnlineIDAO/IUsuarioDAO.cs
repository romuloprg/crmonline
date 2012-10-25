using System;
using System.Collections.Generic;
using CRMOnlineEntity;

namespace CRMOnlineIDAO
{
    public interface IUsuarioDAO
    {
        bool Inserir(UsuarioEntity usuario);
        bool InserirContrato(string cpfUsu, string cnpjEmp, int codCar);
        bool Atualizar(UsuarioEntity usuario);
        bool AtualizarContrato(string cpfUsu, string cnpjEmp, int codCar);
        bool Remover(string cpfUsu);
        bool RemoverContrato(string cpfUsu);
        UsuarioEntity Obter(string cpfUsu);
        ContratoEntity ObterContrato(string cpfUsu);
        List<UsuarioEntity> Buscar(string cpfUsu);
        List<ContratoEntity> BuscarContrato(string cpfUsu);
        List<string> Validar(string emaUsu, string senUsu);
    }
}
